﻿using System.Diagnostics;
using Mutagen.Bethesda.Plugins.Aspects;

namespace Mutagen.Bethesda.Starfield;

partial class PackageDataLocationBinaryOverlay
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    string INamedRequiredGetter.Name => this.Name ?? string.Empty;
    
    public ILocationTargetRadiusGetter Location => throw new NotImplementedException();
}