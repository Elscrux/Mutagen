using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ScriptPropertyStruct : ScriptProperty
    {

    }

    namespace Internals
    {
        public partial class ScriptPropertyStructBinaryOverlay
        {
            public string Name => throw new NotImplementedException();

            public ScriptPropertyStruct.Flag Flags => throw new NotImplementedException();
        }
    }
}
