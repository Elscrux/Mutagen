using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using System;
using static Mutagen.Bethesda.Fallout4.Subgraph;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Subgraph
    {
        public enum SubgraphRole
        {
            MT,
            Weapon,
            Furniture,
            Idle,
            Pipboy
        }
    }

    namespace Internals
    {
        public partial class SubgraphBinaryCreateTranslation
        {
            public static partial ParseResult FillBinaryFlagsParsingCustom(MutagenFrame frame, ISubgraph item, PreviousParse lastParsed)
            {
                item.Role = (SubgraphRole)frame.ReadUInt16();
                item.Perspective = (Perspective)frame.ReadUInt16();
                throw new NotImplementedException();
                return lastParsed;
            }
        }

        public partial class SubgraphBinaryOverlay
        {
            public partial ParseResult FlagsParsingCustomParse(OverlayStream stream, int offset, PreviousParse lastParsed)
            {
                throw new NotImplementedException();
            }

            public Subgraph.SubgraphRole Role => throw new NotImplementedException();
            public Perspective Perspective => throw new NotImplementedException();
        }

        public partial class SubgraphBinaryWriteTranslation
        {
            public static partial void WriteBinaryFlagsParsingCustom(
                MutagenWriter writer,
                ISubgraphGetter item)
            {
                using var header = HeaderExport.Subrecord(writer, RecordTypes.SRAF);
                writer.Write((ushort)item.Role);
                writer.Write((ushort)item.Perspective);
                throw new NotImplementedException();
            }
        }
    }
}