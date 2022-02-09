using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class InstanceNamingRule
    {
        [Flags]
        public enum TargetEnum
        {
            None = 0x00,
            Armor = 0x1D,
            Actor = 0x2D,
            Furniture = 0x2A,
            Weapon = 0x2B
        }

        [Flags]
        public enum PropertyEnum
        {
            Enchantments = 0x0,
            BashImpactDataSet = 0x1,
            BlockMaterial = 0x2,
            Keywords = 0x3,
            Weight = 0x4,
            Value = 0x5,
            Rating = 0x6,
            AddonIndex = 0x7,
            BodyPart = 0x8,
            DamageTypeValues = 0x9,
            ActorValues = 0xA,
            Health = 0xB,
            ColorRemappingIndex = 0xC,
            MaterialSwaps = 0xD
        }

        public enum OpEnum
        {
            GreaterThanOrEqualTo = 0,
            GreaterThan = 1,
            LessThanOrEqualTo = 2,
            LessThan = 3,
            EqualTo = 4
        }
    }
}
