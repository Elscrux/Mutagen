using Loqui;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Cache;
using Newtonsoft.Json.Linq;
using Noggog;
using Noggog.WPF;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;
using System.Text.Json;
using Mutagen.Bethesda.Plugins.Records.Mapping;

namespace Mutagen.Bethesda.WPF.Reflection.Fields;

public class FormLinkSettingsVM : SettingsNodeVM, IBasicSettingsNodeVM
{
    private readonly Type[] _targetTypes;
    private readonly IObservable<ILinkCache?> _linkCacheInternal;
    private FormKey _defaultVal;

    private readonly ObservableAsPropertyHelper<ILinkCache?> _linkCache;
    public ILinkCache? LinkCache => _linkCache.Value;

    [Reactive]
    public FormKey Value { get; set; }

    public IEnumerable<Type> ScopedTypes { get; }

    object IBasicSettingsNodeVM.Value => Value;

    [Reactive]
    public bool IsSelected { get; set; }

    [Reactive]
    public Type? ValueType { get; set; }

    private readonly ObservableAsPropertyHelper<string> _displayName;
    public string DisplayName => _displayName.Value;

    public FormLinkSettingsVM(IObservable<ILinkCache?> linkCache, FieldMeta fieldMeta, Type[] targetTypes, FormKey defaultVal) 
        : base(fieldMeta)
    {
        _targetTypes = targetTypes;
        _defaultVal = defaultVal;
        Value = defaultVal;
        _linkCacheInternal = linkCache;
        _linkCache = linkCache
            .ToGuiProperty(this, nameof(LinkCache), default);
        ScopedTypes = targetTypes;
        _displayName = this.WhenAnyValue(x => x.Value)
            .CombineLatest(this.WhenAnyValue(x => x.LinkCache),
                (key, cache) =>
                {
                    if (cache != null
                        && cache.TryResolveIdentifier(key, ScopedTypes, out var edid)
                        && edid != null)
                    {
                        return edid;
                    }
                    return key.ToString();
                })
            .ToGuiProperty(this, nameof(DisplayName), string.Empty, deferSubscription: true);
    }

    public override SettingsNodeVM Duplicate()
    {
        return new FormLinkSettingsVM(_linkCacheInternal, Meta, _targetTypes, _defaultVal);
    }

    public override void Import(JsonElement property, Action<string> logger)
    {
        if (_targetTypes.Length > 1
            && FormLinkInformation.TryFactory(property.GetString(), out var info))
        {
            Value = info.FormKey;
            ValueType = info.Type;
        }
        else
        {
            Value = FormKeySettingsVM.Import(property);
        }
    }

    public override void Persist(JObject obj, Action<string> logger)
    {
        if (_targetTypes.Length > 1 && ValueType != null)
        {
            obj[Meta.DiskName] = JToken.FromObject(IFormLinkIdentifier.GetString(Value, ValueType));
        }
        else
        {
            obj[Meta.DiskName] = JToken.FromObject(FormKeySettingsVM.Persist(Value));
        }
    }

    public override void WrapUp()
    {
        _defaultVal = FormKeySettingsVM.StripOrigin(_defaultVal);
        Value = FormKeySettingsVM.StripOrigin(Value);
        base.WrapUp();
    }

    public static FormLinkSettingsVM Factory(IObservable<ILinkCache?> linkCache, FieldMeta fieldMeta, Type[] targetTypes, object? defaultVal)
    {
        FormKey formKey = FormKey.Null;
        if (defaultVal != null)
        {
            formKey = FormKey.Factory(
                defaultVal.GetType().GetPublicProperties().FirstOrDefault(m => m.Name == "FormKey")!.GetValue(defaultVal)!.ToString());
        }
        return new FormLinkSettingsVM(linkCache, fieldMeta, StripTypes(targetTypes), formKey);
    }

    private static Type[] StripTypes(Type[] types)
    {
        return types.Select(type =>
        {
            // Done by name, as types may not align if from different mutagen versions
            if (!GetterTypeMapping.Instance.TryGetGetterType(type.FullName!, out var getterType))
            {
                throw new ArgumentException($"Can't create a formlink control for type: {type}");
            }

            return getterType;
        }).ToArray();
    }
}