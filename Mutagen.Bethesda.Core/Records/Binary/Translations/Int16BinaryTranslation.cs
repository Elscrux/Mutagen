using Mutagen.Bethesda.Records.Binary.Streams;

namespace Mutagen.Bethesda.Records.Binary.Translations
{
    public class Int16BinaryTranslation : PrimitiveBinaryTranslation<short>
    {
        public readonly static Int16BinaryTranslation Instance = new Int16BinaryTranslation();
        public override int ExpectedLength => 2;

        public override short Parse(MutagenFrame reader)
        {
            return reader.Reader.ReadInt16();
        }

        public override void Write(MutagenWriter writer, short item)
        {
            writer.Write(item);
        }
    }
}