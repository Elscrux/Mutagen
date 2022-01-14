using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ScriptPropertyStruct
    {
        public enum Flag
        {
            Edited = 0x01,
            Removed = 0x03
        }

        public enum Type
        {
            None = 0,
            Object = 1,
            String = 2,
            Int = 3,
            Float = 4,
            Bool = 5,
            Variable = 6,
            Struct = 7,
            ArrayOfObject = 11,
            ArrayOfString = 12,
            ArrayOfInt = 13,
            ArrayOfFloat = 14,
            ArrayOfBool = 15,
            ArrayOfVariable = 16,
            ArrayOfStruct = 17
        }
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
