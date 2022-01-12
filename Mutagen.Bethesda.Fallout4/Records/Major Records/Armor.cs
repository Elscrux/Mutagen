using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using System;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Armor
    {
        [Flags]
        public enum MajorFlag
        {
            NonPlayable = 0x0000_0004,
            Shield = 0x0000_0040
        }
    }

    namespace Internals
    {
        public partial class ArmorBinaryCreateTranslation
        {
            public static partial void FillBinaryBodyTemplateCustom(MutagenFrame frame, IArmorInternal item)
            {
                item.BodyTemplate = BodyTemplateBinaryCreateTranslation.Parse(frame);
            }
        }

        public partial class ArmorBinaryWriteTranslation
        {
            public static partial void WriteBinaryBodyTemplateCustom(MutagenWriter writer, IArmorGetter item)
            {
                if (item.BodyTemplate is { } templ)
                {
                    BodyTemplateBinaryWriteTranslation.Write(writer, templ);
                }
            }
        }

        public partial class ArmorBinaryOverlay
        {
            private int? _BodyTemplateLocation;
            public IBodyTemplateGetter? GetBodyTemplateCustom() => _BodyTemplateLocation.HasValue ? BodyTemplateBinaryOverlay.CustomFactory(new OverlayStream(_data.Slice(_BodyTemplateLocation!.Value), _package), _package) : default;
            public bool BodyTemplate_IsSet => _BodyTemplateLocation.HasValue;

            partial void BodyTemplateCustomParse(OverlayStream stream, long finalPos, int offset)
            {
                _BodyTemplateLocation = (stream.Position - offset);
            }
        }
    }
}
