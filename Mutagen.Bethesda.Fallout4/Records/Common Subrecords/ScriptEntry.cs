using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Plugins.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ScriptEntry
    {
        public enum Flag : byte
        {
            Local = 0,
            Inherited = 1,
            Removed = 2,
            InheritedAndRemoved = 3,
        }
    }

    namespace Internals
    {
        public partial class ScriptEntryBinaryOverlay
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            string INamedRequiredGetter.Name => this.Name ?? string.Empty;

            public IReadOnlyList<IScriptPropertyGetter> Properties => throw new NotImplementedException();

            public string Name => throw new NotImplementedException();

            public ScriptEntry.Flag Flags => throw new NotImplementedException();
        }
    }
}
