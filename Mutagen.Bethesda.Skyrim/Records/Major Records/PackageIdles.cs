using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;
using System.Buffers.Binary;
using Mutagen.Bethesda.Skyrim.Internals;

namespace Mutagen.Bethesda.Skyrim;

public partial class PackageIdles
{
    public enum Types
    {
        Random = 8,
        RunInSequence = 9,
        RandomDoOnce = 12,
        RunInSequenceDoOnce = 13,
    }
}

partial class PackageIdlesBinaryCreateTranslation
{
    public static partial void FillBinaryTimerSettingCustom(MutagenFrame frame, IPackageIdles item, PreviousParse lastParsed)
    {
        FillBinaryAnimationsCustom(frame, item, lastParsed);
    }

    public static partial void FillBinaryAnimationsCustom(MutagenFrame frame, IPackageIdles item, PreviousParse lastParsed)
    {
        byte? count = null;
        for (int i = 0; i < 3; i++)
        {
            var subRecord = frame.GetSubrecord();
            if (subRecord.RecordType == RecordTypes.IDLC)
            {
                // Counter start
                if (subRecord.Content.Length != 1)
                {
                    throw new ArgumentException("Unexpected counter length");
                }
                count = subRecord.Content[0];
                frame.Position += subRecord.TotalLength;
            }
            else if (subRecord.RecordType == RecordTypes.IDLA)
            {
                if (count == null)
                {
                    item.Animations.SetTo(
                        ListBinaryTranslation<IFormLinkGetter<IdleAnimation>>.Instance.Parse(
                            reader: frame,
                            triggeringRecord: RecordTypes.IDLA,
                            transl: FormLinkBinaryTranslation.Instance.Parse));
                }
                else
                {
                    item.Animations.SetTo(
                        ListBinaryTranslation<IFormLinkGetter<IdleAnimation>>.Instance.Parse(
                            reader: frame,
                            amount: count.Value,
                            triggeringRecord: RecordTypes.IDLA,
                            transl: FormLinkBinaryTranslation.Instance.Parse));
                }
            }
            else if (subRecord.RecordType == RecordTypes.IDLT)
            {
                item.TimerSetting = subRecord.Content.Float();
                frame.Position += subRecord.TotalLength;
            }
            else
            {
                break;
            }
        }
        if (count.HasValue && count.Value != item.Animations.Count)
        {
            throw new ArgumentException("Idle animation counts did not match.");
        }
    }
}

partial class PackageIdlesBinaryWriteTranslation
{
    public static partial void WriteBinaryAnimationsCustom(MutagenWriter writer, IPackageIdlesGetter item)
    {
        var anims = item.Animations;
        using (HeaderExport.Subrecord(writer, RecordTypes.IDLC))
        {
            writer.Write(anims.Count, 1);
        }

        using (HeaderExport.Subrecord(writer, RecordTypes.IDLT))
        {
            writer.Write(item.TimerSetting);
        }

        using (HeaderExport.Subrecord(writer, RecordTypes.IDLA))
        {
            foreach (var anim in anims)
            {
                FormLinkBinaryTranslation.Instance.Write(
                    writer: writer,
                    item: anim);
            }
        }
    }

    public static partial void WriteBinaryTimerSettingCustom(MutagenWriter writer, IPackageIdlesGetter item)
    {
    }
}

partial class PackageIdlesBinaryOverlay
{
    public IReadOnlyList<IFormLinkGetter<IIdleAnimationGetter>> Animations { get; private set; } = Array.Empty<IFormLinkGetter<IIdleAnimationGetter>>();

    private float _timerSetting;
    public partial Single GetTimerSettingCustom() => _timerSetting;

    partial void TimerSettingCustomParse(OverlayStream stream, int finalPos, int offset)
    {
    }

    partial void AnimationsCustomParse(
        OverlayStream stream,
        int finalPos,
        int offset,
        RecordType type,
        PreviousParse lastParsed)
    {
        byte? count = null;
        for (int i = 0; i < 3; i++)
        {
            var subRecord = stream.GetSubrecord();
            if (subRecord.RecordType == RecordTypes.IDLC)
            {
                // Counter start
                if (subRecord.Content.Length != 1)
                {
                    throw new ArgumentException("Unexpected counter length");
                }
                count = subRecord.Content[0];
                stream.Position += subRecord.TotalLength;
            }
            else if (subRecord.RecordType == RecordTypes.IDLA)
            {
                if (count == null)
                {
                    this.Animations = BinaryOverlayList.FactoryByArray<IFormLinkGetter<IIdleAnimationGetter>>(
                        mem: stream.RemainingMemory,
                        package: _package,
                        getter: (s, p) => new FormLink<IIdleAnimationGetter>(FormKey.Factory(p.MetaData.MasterReferences!, BinaryPrimitives.ReadUInt32LittleEndian(s))),
                        locs: ParseRecordLocations(
                            stream: stream,
                            constants: _package.MetaData.Constants.SubConstants,
                            trigger: type,
                            skipHeader: true));
                }
                else
                {
                    var subMeta = stream.ReadSubrecordHeader();
                    var subLen = subMeta.ContentLength;
                    this.Animations = BinaryOverlayList.FactoryByStartIndex<IFormLinkGetter<IIdleAnimationGetter>>(
                        mem: stream.RemainingMemory.Slice(0, subLen),
                        package: _package,
                        itemLength: 4,
                        getter: (s, p) => new FormLink<IIdleAnimationGetter>(FormKey.Factory(p.MetaData.MasterReferences!, BinaryPrimitives.ReadUInt32LittleEndian(s))));
                    stream.Position += subLen;
                }
            }
            else if (subRecord.RecordType == RecordTypes.IDLT)
            {
                _timerSetting = subRecord.Content.Float();
                stream.Position += subRecord.TotalLength;
            }
            else
            {
                break;
            }
        }
        if (count.HasValue && count.Value != Animations.Count)
        {
            throw new ArgumentException("Idle animation counts did not match.");
        }
    }
}