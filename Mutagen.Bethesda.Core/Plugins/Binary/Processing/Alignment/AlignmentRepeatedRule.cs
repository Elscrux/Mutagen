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
    public List<RecordType> SubTypes; 
 
    public AlignmentRepeatedRule( 
        params RecordType[] types) 
    { 
        SubTypes = types.ToList(); 
    } 
 
    public override RecordType RecordType => SubTypes[0]; 
 
    public override ReadOnlyMemorySlice<byte> GetBytes(IMutagenReadStream inputStream) 
    { 
        var dataList = new List<byte[]>(); 
        MutagenWriter stream; 
        while (!inputStream.Complete) 
        { 
            var subType = HeaderTranslation.ReadNextSubrecordType( 
                inputStream, 
                out var subLen); 
            if (!SubTypes.Contains(subType)) 
            { 
                inputStream.Position -= 6; 
                break; 
            } 
            var data = new byte[subLen + 6]; 
            stream = new MutagenWriter(new MemoryStream(data), inputStream.MetaData.Constants); 
            using (HeaderExport.Subrecord(stream, subType)) 
            { 
                inputStream.WriteTo(stream.BaseStream, subLen); 
            } 
            dataList.Add(data); 
        } 
        byte[] ret = new byte[dataList.Sum((d) => d.Length)]; 
        stream = new MutagenWriter(new MemoryStream(ret), inputStream.MetaData.Constants); 
        foreach (var data in dataList) 
        { 
            stream.Write(data); 
        } 
        return ret; 
    } 
} 