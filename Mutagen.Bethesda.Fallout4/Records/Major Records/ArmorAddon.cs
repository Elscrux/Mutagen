using Loqui;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ArmorAddon
    {
        [Flags]
        public enum MajorFlag
        {
            NoUnderarmorScaling = 0x0000_0040,
            HiRes1stPersonOnly = 0x40000000
        }

        public IGenderedItem<Boolean> WeightSliderEnabled { get; set; } = new GenderedItem<Boolean>(default, default);
        IGenderedItemGetter<Boolean> IArmorAddonGetter.WeightSliderEnabled => this.WeightSliderEnabled;
    }

    namespace Internals
    {
        public class ArmorAddonWeightSliderContainer : IGenderedItem<bool>
        {
            internal byte _male;
            public bool Male
            {
                get => ArmorAddonBinaryCreateTranslation.IsEnabled(_male);
                set => _male = (byte)(value ? 2 : 0);
            }

            internal byte _female;
            public bool Female
            {
                get => ArmorAddonBinaryCreateTranslation.IsEnabled(_female);
                set => _female = (byte)(value ? 2 : 0);
            }

            public ArmorAddonWeightSliderContainer(byte male, byte female)
            {
                _male = male;
                _female = female;
            }

            public IEnumerator<bool> GetEnumerator()
            {
                yield return Male;
                yield return Female;
            }

            public void ToString(FileGeneration fg, string? name = null)
            {
                GenderedItem.ToString(this, fg, name);
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public partial class ArmorAddonBinaryCreateTranslation
        {
            public static bool IsEnabled(byte b) => EnumExt.HasFlag(b, (byte)2);

            public static partial void FillBinaryWeightSliderEnabledCustom(MutagenFrame frame, IArmorAddonInternal item)
            {
                item.WeightSliderEnabled = new ArmorAddonWeightSliderContainer(frame.ReadUInt8(), frame.ReadUInt8());
            }

            public static partial void FillBinaryBodyTemplateCustom(MutagenFrame frame, IArmorAddonInternal item)
            {
                item.BodyTemplate = BodyTemplateBinaryCreateTranslation.Parse(frame);
            }
        }

        public partial class ArmorAddonBinaryWriteTranslation
        {
            public static partial void WriteBinaryWeightSliderEnabledCustom(MutagenWriter writer, IArmorAddonGetter item)
            {
                var weightSlider = item.WeightSliderEnabled;
                if (weightSlider is ArmorAddonWeightSliderContainer special)
                {
                    writer.Write(special._male);
                    writer.Write(special._female);
                }
                else
                {
                    writer.Write(weightSlider.Male ? (byte)2 : default(byte));
                    writer.Write(weightSlider.Female ? (byte)2 : default(byte));
                }
            }

            public static partial void WriteBinaryBodyTemplateCustom(MutagenWriter writer, IArmorAddonGetter item)
            {
                if (item.BodyTemplate is { } templ)
                {
                    BodyTemplateBinaryWriteTranslation.Write(writer, templ);
                }
            }
        }

        public partial class ArmorAddonBinaryOverlay
        {
            public IGenderedItemGetter<Boolean> GetWeightSliderEnabledCustom() => new GenderedItem<bool>(
                ArmorAddonBinaryCreateTranslation.IsEnabled(_data.Slice(_DNAMLocation!.Value + 2)[0]),
                ArmorAddonBinaryCreateTranslation.IsEnabled(_data.Slice(_DNAMLocation!.Value + 3)[0]));

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
