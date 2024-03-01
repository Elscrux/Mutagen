using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Noggog;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Skyrim.Internals;

namespace Mutagen.Bethesda.Skyrim;

public partial class PackageBranch
{
    [Flags]
    public enum Flag
    {
        SuccessCompletesPackage = 0x01
    }
}

partial class PackageBranchBinaryCreateTranslation
{
    public static partial void FillBinaryFlagsOverrideCustom(MutagenFrame frame, IPackageBranch item, PreviousParse lastParsed)
    {
        item.FlagsOverride = PackageFlagsOverride.CreateFromBinary(frame);
        if (frame.Reader.TryGetSubrecordHeader(RecordTypes.PFO2, out var rec))
        {
            item.FlagsOverrideUnused = PackageFlagsOverride.CreateFromBinary(frame);
        }
    }
}

partial class PackageBranchBinaryWriteTranslation
{
    public static partial void WriteBinaryFlagsOverrideCustom(MutagenWriter writer, IPackageBranchGetter item)
    {
        item.FlagsOverride?.WriteToBinary(writer);
        item.FlagsOverrideUnused?.WriteToBinary(writer);
    }
}

partial class PackageBranchBinaryOverlay
{
    public IPackageFlagsOverrideGetter? FlagsOverrideUnused { get; private set; }

    private IPackageFlagsOverrideGetter? _flagsOverride;
    public partial IPackageFlagsOverrideGetter? GetFlagsOverrideCustom() => _flagsOverride;

    partial void FlagsOverrideCustomParse(OverlayStream stream, int finalPos, int offset)
    {
        _flagsOverride = PackageFlagsOverride.CreateFromBinary(new MutagenFrame(
            new MutagenInterfaceReadStream(stream, _package.MetaData)));
        if (stream.TryGetSubrecordHeader(RecordTypes.PFO2, out var rec))
        {
            FlagsOverrideUnused = PackageFlagsOverride.CreateFromBinary(new MutagenFrame(
                new MutagenInterfaceReadStream(stream, _package.MetaData)));
        }
    }
}