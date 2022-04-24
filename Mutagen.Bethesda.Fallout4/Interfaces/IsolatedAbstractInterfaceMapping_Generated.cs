/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections.Generic;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Loqui;

namespace Mutagen.Bethesda.Fallout4;

internal class Fallout4IsolatedAbstractInterfaceMapping : IInterfaceMapping
{
    public IReadOnlyDictionary<Type, InterfaceMappingResult> InterfaceToObjectTypes { get; }

    public GameCategory GameCategory => GameCategory.Fallout4;

    public Fallout4IsolatedAbstractInterfaceMapping()
    {
        var dict = new Dictionary<Type, InterfaceMappingResult>();
        InterfaceToObjectTypes = dict;
    }
}
