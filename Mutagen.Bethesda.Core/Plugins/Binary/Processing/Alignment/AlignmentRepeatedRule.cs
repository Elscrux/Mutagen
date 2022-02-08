using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;

namespace Mutagen.Bethesda.Plugins.Binary.Processing.Alignment;

/// <summary> 
/// For use when a set of records is repeated. 
/// Does not currently enforce order within sub-group, but could be upgraded in the future 
/// </summary> 
public class AlignmentRepeatedRule : AlignmentRule 
{ 
    public HashSet<RecordType> SubTypes; 
 
    private AlignmentRepeatedRule( 
        params RecordType[] types) 
    { 
        SubTypes = types.ToHashSet(); 
    } 

    public static AlignmentRule Basic(params RecordType[] recordTypes)
    {
        return new AlignmentRepeatedRule(recordTypes);
    }
 
    public override IEnumerable<RecordType> RecordTypes => SubTypes; 
 
    public override ReadOnlyMemorySlice<byte> GetBytes(IMutagenReadStream inputStream)
    {
        if (inputStream.Complete) return Array.Empty<byte>();
        var dataList = new List<List<ReadOnlyMemorySlice<byte>>>();
        var latestList = new List<ReadOnlyMemorySlice<byte>>();
        var encountered = new HashSet<RecordType>(SubTypes);
        RecordType? lastEncountered = null;
        MutagenWriter stream; 
        while (!inputStream.Complete) 
        { 
            var frame = inputStream.GetSubrecordFrame(readSafe: true);
            var subType = frame.RecordType;
            if (!SubTypes.Contains(subType)) 
            { 
                break; 
            }

            if (lastEncountered == subType
                || encountered.Remove(subType))
            {
            }
            else
            {
                dataList.Add(latestList);
                latestList = new List<ReadOnlyMemorySlice<byte>>();
                encountered.Add(SubTypes);
            }

            lastEncountered = subType;
            latestList.Add(frame.HeaderAndContentData);
            inputStream.Position += frame.TotalLength;
        } 
        dataList.Add(latestList);
        byte[] ret = new byte[dataList.SelectMany(x => x).Sum((d) => d.Length)]; 
        stream = new MutagenWriter(new MemoryStream(ret), inputStream.MetaData.Constants); 
        foreach (var data in dataList.SelectMany(x => x)) 
        { 
            stream.Write(data); 
        } 
        return ret; 
    } 
} 