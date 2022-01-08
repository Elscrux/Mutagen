using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ObjectEffect
    {
        [Flags]
        public enum Flag
        {
            NoAutoCalc = 0x01,
            ExtendDurationOnRecast = 0x04
        }

        public enum EnchantTypeEnum
        {
            Enchantment = 0x06,
            StaffEnchantment = 0x0C
        }
    }
}
