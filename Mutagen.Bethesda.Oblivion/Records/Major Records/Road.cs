using Mutagen.Bethesda.Oblivion.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;

namespace Mutagen.Bethesda.Oblivion;

partial class RoadBinaryCreateTranslation
{
    public static readonly RecordType PGRP = new("PGRP");
    public static readonly RecordType PGRR = new("PGRR");
    public const int POINT_LEN = 16;

    public static partial void FillBinaryPointsCustom(MutagenFrame frame, IRoadInternal item, PreviousParse lastParsed)
    {
        if (!frame.Reader.TryReadSubrecordHeader(PGRP, out var subMeta)) return;
        var pointBytes = frame.Reader.ReadSpan(subMeta.ContentLength);

        subMeta = frame.ReadSubrecordHeader();
        switch (subMeta.RecordType.TypeInt)
        {
            case RecordTypeInts.PGRR:
                var connBytes = frame.Reader.ReadSpan(subMeta.ContentLength);
                var connFloats = connBytes.AsFloatSpan();
                int numPts = pointBytes.Length / POINT_LEN;
                RoadPoint[] points = new RoadPoint[numPts];
                for (int i = 0; i < numPts; i++)
                {
                    var pt = ReadPathGridPoint(pointBytes, out var numConn);
                    pointBytes = pointBytes.Slice(16);
                    P3Float[] conns = new P3Float[numConn];
                    for (int j = 0; j < numConn; j++)
                    {
                        conns[j] = new P3Float(
                            x: connFloats[0],
                            y: connFloats[1],
                            z: connFloats[2]);
                        connFloats = connFloats.Slice(3);
                    }
                    pt.Connections.AddRange(conns);
                    points[i] = pt;
                }
                item.Points = points.ToExtendedList();
                if (connFloats.Length > 0)
                {
                    throw new ArgumentException("Connection reader did not complete as expected.");
                }
                break;
            default:
                frame.Reader.Position -= subMeta.HeaderLength;
                item.Points = new ExtendedList<RoadPoint>();
                while (pointBytes.Length > 0)
                {
                    item.Points.Add(
                        ReadPathGridPoint(pointBytes, out var numConn));
                    pointBytes = pointBytes.Slice(16);
                }
                break;
        }
    }

    public static RoadPoint ReadPathGridPoint(ReadOnlySpan<byte> reader, out byte numConn)
    {
        var pt = new RoadPoint();
        pt.Point = new Noggog.P3Float(
            reader.Float(),
            reader.Slice(4).Float(),
            reader.Slice(8).Float());
        numConn = reader[12];
        pt.NumConnectionsFluffBytes = reader.Slice(13, 3).ToArray();
        return pt;
    }
}

partial class RoadBinaryWriteTranslation
{
    public static partial void WriteBinaryPointsCustom(MutagenWriter writer, IRoadGetter item)
    {
        bool anyConnections = false;
        using (HeaderExport.Subrecord(writer, RoadBinaryCreateTranslation.PGRP))
        {
            foreach (var pt in item.Points.EmptyIfNull())
            {
                writer.Write(pt.Point.X);
                writer.Write(pt.Point.Y);
                writer.Write(pt.Point.Z);
                writer.Write((byte)(pt.Connections.Count));
                writer.Write(pt.NumConnectionsFluffBytes);
                if (pt.Connections.Count > 0)
                {
                    anyConnections = true;
                }
            }
        }

        if (!anyConnections) return;
        using (HeaderExport.Subrecord(writer, RoadBinaryCreateTranslation.PGRR))
        {
            foreach (var pt in item.Points.EmptyIfNull())
            {
                foreach (var conn in pt.Connections)
                {
                    writer.Write(conn.X);
                    writer.Write(conn.Y);
                    writer.Write(conn.Z);
                }
            }
        }
    }
}
    
partial class RoadBinaryOverlay
{
    public IReadOnlyList<IRoadPointGetter>? Points { get; private set; }

    partial void PointsCustomParse(OverlayStream stream, int finalPos, int offset, RecordType type, PreviousParse lastParsed)
    {
        if (stream.Complete) return;
        var subMeta = stream.GetSubrecordHeader();
        if (subMeta.RecordType != RecordTypes.PGRP) return;
        stream.Position += subMeta.HeaderLength;
        var pointBytes = stream.ReadMemory(subMeta.ContentLength);
        subMeta = stream.GetSubrecordHeader();
        switch (subMeta.RecordTypeInt)
        {
            case RecordTypeInts.PGRR:
                stream.Position += subMeta.HeaderLength;
                var connBytes = stream.ReadMemory(subMeta.ContentLength);
                this.Points = BinaryOverlayList.FactoryByLazyParse<IRoadPointGetter>(
                    pointBytes,
                    _package,
                    getter: (s, p) =>
                    {
                        int numPts = pointBytes.Length / RoadBinaryCreateTranslation.POINT_LEN;
                        RoadPoint[] points = new RoadPoint[numPts];
                        var connFloats = connBytes.Span.AsFloatSpan();
                        for (int i = 0; i < numPts; i++)
                        {
                            var pt = RoadBinaryCreateTranslation.ReadPathGridPoint(s, out var numConn);
                            s = s.Slice(RoadBinaryCreateTranslation.POINT_LEN);
                            P3Float[] conns = new P3Float[numConn];
                            for (int j = 0; j < numConn; j++)
                            {
                                conns[j] = new P3Float(
                                    x: connFloats[0],
                                    y: connFloats[1],
                                    z: connFloats[2]);
                                connFloats = connFloats.Slice(3);
                            }
                            pt.Connections.AddRange(conns);
                            points[i] = pt;
                        }
                        return points;
                    });
                break;
            default:
                this.Points = BinaryOverlayList.FactoryByStartIndex<IRoadPointGetter>(
                    pointBytes,
                    _package,
                    itemLength: RoadBinaryCreateTranslation.POINT_LEN,
                    getter: (s, p) => RoadBinaryCreateTranslation.ReadPathGridPoint(s, out var numConn));
                break;
        }
    }
}