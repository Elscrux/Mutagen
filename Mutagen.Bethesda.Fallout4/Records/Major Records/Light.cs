using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Light
    {
        [Flags]
        public enum MajorFlag
        {
            RandomAnimStart = 0x0001_0000,
            Obstacle = 0x200_0000,
            PortalStrict = 0x1000_0000
        }

        [Flags]
        public enum Flag
        {
            CanBeCarried = 0x0002,
            Flicker = 0x0008,
            OffByDefault = 0x0020,
            Pulse = 0x0080,
            ShadowSpotlight = 0x0400,
            ShadowHemisphere = 0x0800,
            ShadowOmnidirectional = 0x1000,
            NonShadowSpotlight = 0x4000,
            NonSpecular = 0x8000,
            AttenuationOnly = 0x1_0000,
            NonShadowBox=0x2_0000,
            IgnoreRoughness = 0x4_0000,
            NoRimLighting = 0x8_0000,
            AmbientOnly=0x10_0000
        }
    }
}
