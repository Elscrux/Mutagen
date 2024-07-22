using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Collections;
using Mutagen.Bethesda.Plugins.Assets;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Skyrim.Assets;
using Noggog.StructuredStrings;

namespace Mutagen.Bethesda.Skyrim;

public partial class ArmorAddon
{
    public IGenderedItem<Boolean> WeightSliderEnabled { get; set; } = new GenderedItem<Boolean>(default, default);
    IGenderedItemGetter<Boolean> IArmorAddonGetter.WeightSliderEnabled => this.WeightSliderEnabled;
}

internal class ArmorAddonWeightSliderContainer : IGenderedItem<bool>
{
    internal byte _male;
    public bool Male 
    {
        get => ArmorAddonBinaryCreateTranslation.IsEnabled(_male);
        set => _male = (byte)(value ? 2 : 0);
    }

    internal byte _female;
    public bool Female
    {
        get => ArmorAddonBinaryCreateTranslation.IsEnabled(_female);
        set => _female = (byte)(value ? 2 : 0);
    }

    public bool this[MaleFemaleGender gender]
    {
        get => gender == MaleFemaleGender.Male ? Male : Female;
        set
        {
            if (gender == MaleFemaleGender.Male)
            {
                Male = value;
            }
            else
            {
                Female = value;
            }
        }
    }

    public ArmorAddonWeightSliderContainer(byte male, byte female)
    {
        _male = male;
        _female = female;
    }

    public IEnumerator<bool> GetEnumerator()
    {
        yield return Male;
        yield return Female;
    }

    public void Print(StructuredStringBuilder fg, string? name = null)
    {
        GenderedItem.Print(this, fg, name);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

partial class ArmorAddonCommon
{
    public static partial IEnumerable<IAssetLinkGetter> GetInferredAssetLinks(IArmorAddonGetter obj, Type? assetType)
    {
        if (assetType != null && assetType != typeof(SkyrimModelAssetType)) yield break;
        
        IEnumerable<IAssetLink> TryToAddWeightModel(string path) {
            var otherWeight = GetOtherWeight(path);
            if (otherWeight != null)
            {
                yield return otherWeight;
            }
        }

        if (obj.WorldModel?.Female != null)
        {
            foreach (var assetLink in TryToAddWeightModel(obj.WorldModel.Female.File.GivenPath)) yield return assetLink;
        }

        if (obj.WorldModel?.Male != null)
        {
            foreach (var assetLink in TryToAddWeightModel(obj.WorldModel.Male.File.GivenPath)) yield return assetLink;
        }

        if (obj.FirstPersonModel?.Female != null)
        {
            foreach (var assetLink in TryToAddWeightModel(obj.FirstPersonModel.Female.File.GivenPath))
                yield return assetLink;
        }

        if (obj.FirstPersonModel?.Male != null)
        {
            foreach (var assetLink in TryToAddWeightModel(obj.FirstPersonModel.Male.File.GivenPath))
                yield return assetLink;
        }
    }

    internal static IAssetLink? GetOtherWeight(string path) {
        const string zeroSuffix = "_0";
        const string oneSuffix = "_1";

        var name = Path.GetFileNameWithoutExtension(path);
        if (name.Length < 3) return null;

        if (name.EndsWith(oneSuffix, StringComparison.Ordinal))
        {
            return ReplaceWeightSuffix(zeroSuffix, path, name);
        }

        if (name.EndsWith(zeroSuffix, StringComparison.Ordinal))
        {
            return ReplaceWeightSuffix(oneSuffix, path, name);
        }

        return null;
    }

    internal static IAssetLink ReplaceWeightSuffix(string newFileSuffix, string path, string name)
    {
        var dir = Path.GetDirectoryName(path);
        var newFile = name[..^2] + newFileSuffix + Path.GetExtension(path);
        return dir == null ? new AssetLink<SkyrimModelAssetType>(newFile) : new AssetLink<SkyrimModelAssetType>(Path.Combine(dir, newFile));
    }
}

partial class ArmorAddonSetterCommon
{
    private static partial void RemapInferredAssetLinks(
        IArmorAddon obj,
        IReadOnlyDictionary<IAssetLinkGetter, string> mapping,
        AssetLinkQuery queryCategories)
    {
        // Let the linked asset remap function handle this
    }
}

partial class ArmorAddonBinaryCreateTranslation
{
    public static bool IsEnabled(byte b) => Enums.HasFlag(b, (byte)2);

    public static partial void FillBinaryWeightSliderEnabledCustom(MutagenFrame frame, IArmorAddonInternal item)
    {
        item.WeightSliderEnabled = new ArmorAddonWeightSliderContainer(frame.ReadUInt8(), frame.ReadUInt8());
    }

    public static partial void FillBinaryBodyTemplateCustom(MutagenFrame frame, IArmorAddonInternal item, PreviousParse lastParsed)
    {
        item.BodyTemplate = BodyTemplateBinaryCreateTranslation.Parse(frame);
    }
}

partial class ArmorAddonBinaryWriteTranslation
{
    public static partial void WriteBinaryWeightSliderEnabledCustom(MutagenWriter writer, IArmorAddonGetter item)
    {
        var weightSlider = item.WeightSliderEnabled;
        if (weightSlider is ArmorAddonWeightSliderContainer special)
        {
            writer.Write(special._male);
            writer.Write(special._female);
        }
        else
        {
            writer.Write(weightSlider.Male ? (byte)2 : default(byte));
            writer.Write(weightSlider.Female ? (byte)2 : default(byte));
        }
    }

    public static partial void WriteBinaryBodyTemplateCustom(MutagenWriter writer, IArmorAddonGetter item)
    {
        if (item.BodyTemplate is {} templ)
        {
            BodyTemplateBinaryWriteTranslation.Write(writer, templ);
        }
    }
}

partial class ArmorAddonBinaryOverlay
{
    public IGenderedItemGetter<Boolean> WeightSliderEnabled => GetWeightSliderEnabledCustom();
    
    public IGenderedItemGetter<Boolean> GetWeightSliderEnabledCustom() => new GenderedItem<bool>(
        ArmorAddonBinaryCreateTranslation.IsEnabled(_recordData.Slice(_DNAMLocation!.Value.Min + 2)[0]),
        ArmorAddonBinaryCreateTranslation.IsEnabled(_recordData.Slice(_DNAMLocation!.Value.Min + 3)[0]));

    private int? _BodyTemplateLocation;
    public partial IBodyTemplateGetter? GetBodyTemplateCustom() => _BodyTemplateLocation.HasValue ? BodyTemplateBinaryOverlay.CustomFactory(new OverlayStream(_recordData.Slice(_BodyTemplateLocation!.Value), _package), _package) : default;
    public bool BodyTemplate_IsSet => _BodyTemplateLocation.HasValue;

    partial void BodyTemplateCustomParse(OverlayStream stream, int finalPos, int offset)
    {
        _BodyTemplateLocation = (stream.Position - offset);
    }
}