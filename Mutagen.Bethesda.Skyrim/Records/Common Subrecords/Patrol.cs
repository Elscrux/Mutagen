using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;
using Mutagen.Bethesda.Skyrim.Internals;

namespace Mutagen.Bethesda.Skyrim;

partial class PatrolBinaryCreateTranslation
{
    public static partial ParseResult FillBinaryPatrolScriptMarkerCustom(MutagenFrame frame, IPatrol item, PreviousParse lastParsed)
    {
        if (frame.ReadSubrecord().Content.Length != 0)
        {
            throw new ArgumentException($"Marker had unexpected length.");
        }

        return lastParsed;
    }

    public static partial void FillBinaryTopicsCustom(MutagenFrame frame, IPatrol item, PreviousParse lastParsed)
    {
        item.Topics.SetTo(ATopicReferenceBinaryCreateTranslation.Factory(frame));
    }
}

partial class PatrolBinaryWriteTranslation
{
    public static partial void WriteBinaryPatrolScriptMarkerCustom(MutagenWriter writer, IPatrolGetter item)
    {
        using (HeaderExport.Subrecord(writer, RecordTypes.XPPA)) { }
    }

    public static partial void WriteBinaryTopicsCustom(MutagenWriter writer, IPatrolGetter item)
    {
        ATopicReferenceBinaryWriteTranslation.Write(writer, item.Topics);
    }
}

partial class PatrolBinaryOverlay
{
    public IReadOnlyList<IATopicReferenceGetter> Topics { get; private set; } = Array.Empty<IATopicReferenceGetter>();

    public partial ParseResult PatrolScriptMarkerCustomParse(OverlayStream stream, int offset, PreviousParse lastParsed)
    {
        if (stream.ReadSubrecord().Content.Length != 0)
        {
            throw new ArgumentException($"Marker had unexpected length.");
        }

        return lastParsed;
    }

    partial void TopicsCustomParse(
        OverlayStream stream,
        int finalPos,
        int offset,
        RecordType type,
        PreviousParse lastParsed)
    {
        Topics = new List<IATopicReferenceGetter>(
            ATopicReferenceBinaryCreateTranslation.Factory(
                new MutagenFrame(stream)));
    }
}
