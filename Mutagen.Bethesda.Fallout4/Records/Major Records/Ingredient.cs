using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Ingredient
    {
        [Flags]
        public enum Flag
        {
            NoAutoCalculation = 0x001,
            FoodItem = 0x002,
            ReferencesPersist = 0x100
        }
    }
}
