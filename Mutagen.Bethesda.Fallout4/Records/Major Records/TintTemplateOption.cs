using System;
using System.Collections.Generic;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class TintTemplateOption
    {
        public enum Flag
        {
            OnOffOnly = 0x01,
            ChargenDetail = 0x02,
            TakesSkinTone = 0x04,
        }

        public enum TintSlot
        {
            ForeheadMask,
            EyesMask,
            NoseMask,
            EarsMask,
            CheeksMask,
            MouthMask,
            NeckMask,
            LipColor,
            CheekColor,
            Eyeliner,
            EyeSocketUpper,
            EyeSocketLower,
            SkinTone,
            Paint,
            LaughLines,
            CheekColorLower,
            Nose,
            Chin,
            Neck,
            Forehead,
            Dirt,
            Scars,
            FaceDetail,
            Brows,
            Wrinkles,
            Beards
        }
    }

    namespace Internals
    {
        public partial class TintTemplateOptionBinaryOverlay
        {
            public IReadOnlyList<IConditionGetter> Conditions { get; private set; } = ListExt.Empty<IConditionGetter>();

            partial void ConditionsCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, PreviousParse lastParsed)
            {
                Conditions = ConditionBinaryOverlay.ConstructBinayOverlayList(stream, _package);
            }
        }
    }
}