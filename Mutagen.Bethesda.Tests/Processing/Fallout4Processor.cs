using Mutagen.Bethesda.Archives;
using Mutagen.Bethesda.Fallout4.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Strings;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Tests;

public class Fallout4Processor : Processor
{
    public Fallout4Processor(bool multithread) : base(multithread)
    {
    }

    public override GameRelease GameRelease => GameRelease.Fallout4;

    protected override void AddDynamicProcessorInstructions()
    {
        base.AddDynamicProcessorInstructions();
        AddDynamicProcessing(RecordTypes.GMST, ProcessGameSettings);
        AddDynamicProcessing(RecordTypes.TRNS, ProcessTransforms);
        AddDynamicProcessing(RecordTypes.RACE, ProcessRaces);
    }

    protected override IEnumerable<Task> ExtraJobs(Func<IMutagenReadStream> streamGetter)
    {
        foreach (var t in base.ExtraJobs(streamGetter))
        {
            yield return t;
        }
        var bsaOrder = Archive.GetIniListings(GameRelease).ToList();
        foreach (var source in EnumExt.GetValues<StringsSource>())
        {
            yield return TaskExt.Run(DoMultithreading, () =>
            {
                return ProcessStringsFilesIndices(
                    streamGetter, 
                    new DirectoryInfo(Path.GetDirectoryName(this.SourcePath)),
                    Language.English, 
                    source, 
                    ModKey.FromNameAndExtension(Path.GetFileName(this.SourcePath)),
                    knownDeadKeys: null,
                    bsaOrder: bsaOrder);
            });
        }
    }

    private void ProcessGameSettings(
        MajorRecordFrame majorFrame,
        long fileOffset)
    {
        if (!majorFrame.TryLocateSubrecordFrame("EDID", out var edidFrame)) return;
        if ((char)edidFrame.Content[0] != 'f') return;

        if (!majorFrame.TryLocateSubrecordPinFrame(RecordTypes.DATA, out var dataRec)) return;
        ProcessZeroFloat(dataRec, fileOffset);
    }

    private void ProcessTransforms(
        MajorRecordFrame majorFrame,
        long fileOffset)
    {
        if (!majorFrame.TryLocateSubrecordPinFrame(RecordTypes.DATA, out var dataRec)) return;
        int offset = 0;
        ProcessZeroFloats(dataRec, fileOffset, ref offset, 9);
    }

    private void ProcessRaces(
        MajorRecordFrame majorFrame,
        long fileOffset)
    {
        if (!majorFrame.TryLocateSubrecordPinFrame(RecordTypes.MLSI, out var mlsi)) return;

        if (majorFrame.TryLocateSubrecord(RecordTypes.MSID, out _))
        {
            var max = majorFrame.FindEnumerateSubrecords(RecordTypes.MSID)
                .Select(x => x.AsInt32())
                .Max(0);

            var existing = mlsi.AsInt32();
            if (existing == max) return;

            byte[] sub = new byte[4];
            BinaryPrimitives.WriteInt32LittleEndian(sub, max);
            _instructions.SetSubstitution(
                fileOffset + mlsi.Location + mlsi.HeaderLength,
                sub);
        }
        else
        {
            _instructions.SetRemove(RangeInt64.FromLength(fileOffset + mlsi.Location, mlsi.TotalLength));
            ProcessLengths(
                majorFrame,
                -mlsi.TotalLength,
                fileOffset);
        }
    }

    public void GameSettingStringHandler(
        IMutagenReadStream stream,
        MajorRecordHeader major,
        BinaryFileProcessor.ConfigConstructor instr,
        List<KeyValuePair<uint, uint>> processedStrings,
        IStringsLookup overlay,
        ref uint newIndex)
    {
        stream.Position -= major.HeaderLength;
        var majorRec = stream.GetMajorRecordFrame();
        if (!majorRec.TryLocateSubrecordFrame("EDID", out var edidRec)) throw new ArgumentException();
        if (edidRec.Content[0] != (byte)'s') return;
        if (!majorRec.TryLocateSubrecordPinFrame("DATA", out var dataRec)) throw new ArgumentException();
        stream.Position += dataRec.Location;
        AStringsAlignment.ProcessStringLink(stream, instr, processedStrings, overlay, ref newIndex);
    }

    private async Task ProcessStringsFilesIndices(
        Func<IMutagenReadStream> streamGetter, 
        DirectoryInfo dataFolder, 
        Language language, 
        StringsSource source, 
        ModKey modKey,
        HashSet<uint> knownDeadKeys,
        IEnumerable<FileName> bsaOrder)
    {
        using var stream = streamGetter();
        switch (source)
        {
            case StringsSource.Normal:
                ProcessStringsFiles(
                    GameRelease.Fallout4,
                    modKey,
                    dataFolder,
                    language,
                    StringsSource.Normal,
                    strict: false,
                    knownDeadKeys: knownDeadKeys,
                    bsaOrder: bsaOrder,
                    RenumberStringsFileEntries(
                        GameRelease.Fallout4,
                        modKey,
                        stream,
                        dataFolder,
                        language,
                        StringsSource.Normal,
                        new StringsAlignmentCustom("GMST", GameSettingStringHandler),
                        new RecordType[] { "KYWD", "FULL" },
                        new RecordType[] { "ENCH", "FULL" },
                        new RecordType[] { "SPEL", "FULL" },
                        new RecordType[] { "MGEF", "FULL", "DNAM" },
                        new RecordType[] { "ACTI", "FULL", "ATTX" },
                        new RecordType[] { "RACE", "TTGP", "MPPN" },
                        new RecordType[] { "ACTI", "FULL", "ATTX" },
                        new RecordType[] { "TACT", "FULL" },
                        new RecordType[] { "ARMO", "FULL", "DESC" }
                    ));
                break;
            case StringsSource.DL:
                ProcessStringsFiles(
                    GameRelease.Fallout4,
                    modKey,
                    dataFolder,
                    language,
                    StringsSource.DL,
                    strict: false,
                    knownDeadKeys: knownDeadKeys,
                    bsaOrder: bsaOrder,
                    RenumberStringsFileEntries(
                        GameRelease.Fallout4,
                        modKey,
                        stream,
                        dataFolder,
                        language,
                        StringsSource.DL,
                        new RecordType[] { "RACE", "DESC" }
                    ));
                break;
            //case StringsSource.IL:
            //    ProcessStringsFiles(
            //        modKey,
            //        dataFolder,
            //        language,
            //        StringsSource.IL,
            //        strict: true,
            //        RenumberStringsFileEntries(
            //            modKey,
            //            stream,
            //            dataFolder,
            //            language,
            //            StringsSource.IL,
            //            new RecordType[] { "DIAL" },
            //            new RecordType[] { "INFO", "NAM1" }
            //        ));
            //    break;
        }
    }

}