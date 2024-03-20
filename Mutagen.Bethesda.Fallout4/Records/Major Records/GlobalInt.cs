using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Fallout4.Internals;
using Noggog;

namespace Mutagen.Bethesda.Fallout4;

public partial class GlobalInt
{
    public const char TRIGGER_CHAR = 'l';
    char IGlobalGetter.TypeChar => TRIGGER_CHAR;

    public override float? RawFloat
    {
        get => this.Data.HasValue ? (float)this.Data : default;
        set
        {
            if (value.HasValue)
            {
                this.Data = (int)value.Value;
            }
            else
            {
                this.Data = default;
            }
        }
    }
}

partial class GlobalIntBinaryCreateTranslation
{
    public static partial void FillBinaryDataCustom(MutagenFrame frame, IGlobalIntInternal item, PreviousParse lastParsed)
    {
    }
}

partial class GlobalIntBinaryWriteTranslation
{
    public static partial void WriteBinaryDataCustom(MutagenWriter writer, IGlobalIntGetter item)
    {
        if (item.Data is not {} data) return;
        using (HeaderExport.Subrecord(writer, RecordTypes.FLTV))
        {
            writer.Write((float)data);
        }
    }
}

partial class GlobalIntBinaryOverlay
{
    char IGlobalGetter.TypeChar => GlobalInt.TRIGGER_CHAR;
    public override float? RawFloat => this.Data is {} data ? (float)data : default;

    private int? _DataLocation;
    public bool GetDataIsSetCustom() => _DataLocation.HasValue;
    public partial int? GetDataCustom()
    {
        if (!_DataLocation.HasValue) return default;
        return (int)HeaderTranslation.ExtractSubrecordMemory(_recordData, _DataLocation.Value, _package.MetaData.Constants).Float();
    }

    partial void DataCustomParse(OverlayStream stream, int finalPos, int offset)
    {
        _DataLocation = (ushort)(stream.Position - offset);
    }
}
