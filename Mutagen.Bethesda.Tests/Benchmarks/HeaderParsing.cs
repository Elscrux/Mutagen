using BenchmarkDotNet.Attributes;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Meta;
using Noggog;

namespace Mutagen.Bethesda.Tests.Benchmarks;

public class HeaderParsing
{
    static byte[] bytes = new byte[]
    { 
        // WEAP major record header
        0x57, 0x45, 0x41, 0x50,
        0x18, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00,
        0x0C, 0x0C, 0x00, 0x00,
        0x17, 0x23, 0x02, 0x00,

        // EDID
        0x45, 0x44, 0x49, 0x44,
        0x12, 0x00,
        0x57, 0x65, 0x61, 0x70,
        0x49, 0x72, 0x6F, 0x6E,
        0x4C, 0x6F, 0x6E, 0x67,
        0x73, 0x77, 0x6F, 0x72,
        0x64, 0x00
    };
    static GameConstants constants = GameConstants.Oblivion;
    static MutagenFrame frame = new(new MutagenMemoryReadStream(bytes, new ParsingBundle(constants, ModKey.Null, masterReferences: null!)));
    static RecordType type = new("WEAP");

    [Benchmark]
    public (bool, long) MajorRecordHeaderSpan()
    {
        var meta = constants.MajorRecordHeader(frame.RemainingMemory);
        if (meta.RecordType != type) return (false, -1);
        return (true, meta.ContentLength);
    }

    [Benchmark]
    public (bool, long) MajorRecordHeaderGetStream()
    {
        var meta = frame.GetMajorRecordHeader();
        if (meta.RecordType != type) return (false, -1);
        return (true, meta.ContentLength);
    }

    [Benchmark]
    public ReadOnlySpan<byte> MajorRecordFrame()
    {
        var meta = constants.MajorRecord(frame.RemainingMemory);
        return meta.Content;
    }

    [Benchmark]
    public ReadOnlyMemorySlice<byte> MajorRecordMemoryFrame()
    {
        var meta = constants.MajorRecord(frame.RemainingMemory);
        return meta.Content;
    }
}