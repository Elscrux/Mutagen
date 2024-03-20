using Loqui;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Cache;
using Newtonsoft.Json.Linq;
using Noggog;
using Noggog.WPF;
using ReactiveUI;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.Json;
using Mutagen.Bethesda.Plugins.Records.Mapping;

namespace Mutagen.Bethesda.WPF.Reflection.Fields;

public class EnumerableFormLinkSettingsVM : SettingsNodeVM
{
    public ObservableCollection<FormKey> Values { get; } = new();

    private FormKey[] _defaultVal;
    private readonly IObservable<ILinkCache?> _linkCacheObs;
    private readonly ObservableAsPropertyHelper<ILinkCache?> _linkCache;
    private readonly string _typeName;
    public ILinkCache? LinkCache => _linkCache.Value;

    public IEnumerable<Type> ScopedTypes { get; private set; } = Enumerable.Empty<Type>();

    public EnumerableFormLinkSettingsVM(
        IObservable<ILinkCache?> linkCache,
        FieldMeta fieldMeta,
        string typeName,
        IEnumerable<FormKey> defaultVal)
        : base(fieldMeta)
    {
        _defaultVal = defaultVal.ToArray();
        _linkCacheObs = linkCache;
        _typeName = typeName;
        _linkCache = linkCache
            .ToGuiProperty(this, nameof(LinkCache), default(ILinkCache?));
    }

    public static SettingsNodeVM Factory(ReflectionSettingsParameters param, FieldMeta fieldMeta, string typeName, object? defaultVal)
    {
        var defaultKeys = new List<FormKey>();
        if (defaultVal is IEnumerable e)
        {
            var targetType = e.GetType().GenericTypeArguments[0];
            var getter = targetType.GetPublicProperties().FirstOrDefault(m => m.Name == "FormKey")!;
            foreach (var item in e)
            {
                defaultKeys.Add(FormKey.Factory(getter.GetValue(item)!.ToString()));
            }
        }
        return new EnumerableFormLinkSettingsVM(
            param.LinkCache,
            fieldMeta: fieldMeta,
            typeName: typeName,
            defaultKeys);
    }

    public override void Import(JsonElement property, Action<string> logger)
    {
        Values.Clear();
        foreach (var elem in property.EnumerateArray())
        {
            if (FormKey.TryFactory(elem.GetString(), out var formKey))
            {
                Values.Add(formKey);
            }
            else
            {
                Values.Add(FormKey.Null);
            }
        }
    }

    public override void Persist(JObject obj, Action<string> logger)
    {
        obj[Meta.DiskName] = new JArray(Values
            .Select(x =>
            {
                if (x.IsNull)
                {
                    return string.Empty;
                }
                else
                {
                    return x.ToString();
                }
            }).ToArray());
    }

    public override SettingsNodeVM Duplicate()
    {
        return new EnumerableFormLinkSettingsVM(
            linkCache: _linkCacheObs,
            typeName: _typeName, 
            fieldMeta: Meta, 
            defaultVal: _defaultVal);
    }

    public override void WrapUp()
    {
        _defaultVal = _defaultVal.Select(x => FormKeySettingsVM.StripOrigin(x)).ToArray();
        Values.SetTo(_defaultVal);

        if (!GetterTypeMapping.Instance.TryGetGetterType(_typeName, out var getterType))
        {
            throw new ArgumentException($"Can't create a formlink control for type: {_typeName}.  No getter type found.");
        }
        
        ScopedTypes = getterType.AsEnumerable();
    }
}