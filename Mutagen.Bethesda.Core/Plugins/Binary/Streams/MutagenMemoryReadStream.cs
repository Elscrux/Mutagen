using Noggog;
using Noggog.Streams.Binary;

namespace Mutagen.Bethesda.Plugins.Binary.Streams;

/// <summary>
/// A class that wraps an array or span directly with Mutagen-specific binary reading functionality
/// </summary>
public sealed class MutagenMemoryReadStream : LittleEndianBinaryMemoryReadStream, IMutagenReadStream
{
    /// <inheritdoc/>
    public long OffsetReference { get; }

    /// <inheritdoc/>
    public ParsingMeta MetaData { get; }

    /// <summary>
    /// Constructor that wraps a memory slice
    /// </summary>
    /// <param name="data">Span to wrap and read from</param>
    /// <param name="metaData">Bundle of all related metadata for parsing</param>
    /// <param name="offsetReference">Optional offset reference position to use</param>
    public MutagenMemoryReadStream(
        ReadOnlyMemorySlice<byte> data,
        ParsingMeta metaData,
        long offsetReference = 0)
        : base(data)
    {
        MetaData = metaData;
        OffsetReference = offsetReference;
    }

    /// <summary>
    /// Reads an amount of bytes into an internal array and returns a new stream wrapping those bytes.
    /// OffsetReference is updated to be aligned to the original source starting position.
    /// This call will advance the source stream by the number of bytes.
    /// The returned stream will be ready to read and start at its Position 0.
    /// </summary>
    /// <param name="length">Number of bytes to read and reframe</param>
    /// <returns>A new stream wrapping an internal array, set to position 0.</returns>
    public IMutagenReadStream ReadAndReframe(int length)
    {
        return new MutagenMemoryReadStream(
            Data, 
            MetaData, 
            offsetReference: OffsetReference + Position);
    }
}