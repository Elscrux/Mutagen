using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Translations.Binary;

namespace Mutagen.Bethesda.Oblivion;

partial class LeveledItemBinaryCreateTranslation
{
    public static partial ParseResult FillBinaryVestigialCustom(MutagenFrame frame, ILeveledItemInternal item, PreviousParse lastParsed)
    {
        var rec = HeaderTranslation.ReadNextSubrecordType(frame.Reader, out var length);
        if (length != 1)
        {
            throw new ArgumentException($"Unexpected length: {length}");
        }
        if (ByteBinaryTranslation<MutagenFrame, MutagenWriter>.Instance.Parse(
                frame,
                out var parseVal)
            && parseVal > 0)
        {
            if (!item.Flags.HasValue)
            {
                item.Flags = default(LeveledFlag);
            }
            item.Flags |= LeveledFlag.CalculateForEachItemInCount;
        }

        return null;
    }
}

partial class LeveledItemBinaryWriteTranslation
{
    public static partial void WriteBinaryVestigialCustom(MutagenWriter writer, ILeveledItemGetter item)
    {
    }
}

partial class LeveledItemBinaryOverlay
{
    private bool _vestigialMarker;

    private int? _FlagsLocation;
    bool GetFlagsIsSetCustom() => _FlagsLocation.HasValue || _vestigialMarker;
    public partial LeveledFlag? GetFlagsCustom()
    {
        var ret = _FlagsLocation.HasValue ? (LeveledFlag)HeaderTranslation.ExtractSubrecordMemory(_recordData, _FlagsLocation.Value, _package.MetaData.Constants)[0] : default(LeveledFlag?);
        if (_vestigialMarker)
        {
            if (ret.HasValue)
            {
                ret |= LeveledFlag.CalculateForEachItemInCount;
            }
            else
            {
                ret = LeveledFlag.CalculateForEachItemInCount;
            }
        }
        return ret;
    }
    partial void FlagsCustomParse(OverlayStream stream, int finalPos, int offset)
    {
        _FlagsLocation = (ushort)(stream.Position - offset);
    }

    public partial ParseResult VestigialCustomParse(OverlayStream stream, int offset, PreviousParse lastParsed)
    {
        var subMeta = stream.ReadSubrecordHeader();
        if (subMeta.ContentLength != 1)
        {
            throw new ArgumentException($"Unexpected length: {subMeta.ContentLength}");
        }
        if (stream.ReadUInt8() > 0)
        {
            this._vestigialMarker = true;
        }

        return null;
    }
}