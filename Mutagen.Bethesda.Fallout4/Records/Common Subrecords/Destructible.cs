using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Destructible
    {
        public enum DestructibleFlag
        {
            VATSTargetable,
            LargeActorDestroys
        }

        public enum DestructionStageDataFlag
        {
            CapDamage,
            Disable,
            Destroy,
            IgnoreExternalDamage,
            BecomesDynamic
        }
    }
}
