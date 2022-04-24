using Loqui;
using Loqui.Generation;
using Mutagen.Bethesda.Generation.Fields;
using Mutagen.Bethesda.Plugins.Records.Mapping;

namespace Mutagen.Bethesda.Generation.Modules.Plugin;

public class AbstractInterfaceModule : GenerationModule
{
    
    public override async Task FinalizeGeneration(ProtocolGeneration proto)
    {
        await base.PrepareGeneration(proto);
        if (proto.Protocol.Namespace == "Bethesda") return;

        HashSet<ObjectGeneration> grupTypes = new();
        foreach (var obj in proto.ObjectGenerationsByID.Values)
        {
            foreach (var field in obj.Fields)
            {
                if (field is GroupType grup)
                {
                    var grupTarget = grup.GetGroupTarget();
                    if (await grupTarget.IsMajorRecord())
                    {
                        grupTypes.Add(grup.GetGroupTarget());
                    }
                }
                else if (field is ContainerType cont)
                {
                    if (cont.SubTypeGeneration is LoquiType loqui)
                    {
                        if (loqui.TargetObjectGeneration != null 
                            && await loqui.TargetObjectGeneration.IsMajorRecord())
                        {
                            grupTypes.Add(loqui.TargetObjectGeneration);
                        }
                    }
                }
            }
        }

        await GenerateAbstractBaseMapping(proto, grupTypes);
        await GenerateInheritingMapping(proto, grupTypes);
    }

    private static async Task GenerateAbstractBaseMapping(ProtocolGeneration proto, HashSet<ObjectGeneration> grupTypes)
    {
        HashSet<ObjectGeneration> baseClasses = new();
        
        foreach (var obj in grupTypes)
        {
            if (obj.BaseClass != null
                && !obj.BaseClass.Name.EndsWith("MajorRecord"))
            {
                if (grupTypes.Contains(obj.BaseClass)) continue;
                baseClasses.Add(obj.BaseClass);
            }
        }

        FileGeneration mappingGen = new FileGeneration();
        ObjectGeneration.AddAutogenerationComment(mappingGen);
        mappingGen.AppendLine($"using System;");
        mappingGen.AppendLine($"using System.Collections.Generic;");
        mappingGen.AppendLine($"using Mutagen.Bethesda.Plugins.Records.Mapping;");
        mappingGen.AppendLine($"using Loqui;");
        mappingGen.AppendLine();
        using (new NamespaceWrapper(mappingGen, proto.DefaultNamespace))
        {
            using (var c = new ClassWrapper(mappingGen, $"{proto.Protocol.Namespace}IsolatedAbstractInterfaceMapping"))
            {
                c.Public = PermissionLevel.@internal;
                c.Interfaces.Add(nameof(IInterfaceMapping));
            }
        
            using (new BraceWrapper(mappingGen))
            {
                mappingGen.AppendLine(
                    $"public IReadOnlyDictionary<Type, {nameof(InterfaceMappingResult)}> InterfaceToObjectTypes {{ get; }}");
                mappingGen.AppendLine();
                mappingGen.AppendLine(
                    $"public {nameof(GameCategory)} GameCategory => {nameof(GameCategory)}.{proto.Protocol.Namespace};");
                mappingGen.AppendLine();
        
                mappingGen.AppendLine($"public {proto.Protocol.Namespace}IsolatedAbstractInterfaceMapping()");
                using (new BraceWrapper(mappingGen))
                {
                    mappingGen.AppendLine($"var dict = new Dictionary<Type, {nameof(InterfaceMappingResult)}>();");
                    foreach (var rec in baseClasses.OrderBy(x => x.Name))
                    {
                        mappingGen.AppendLine(
                            $"dict[typeof({rec.Interface(getter: false)})] = new {nameof(InterfaceMappingResult)}(true, new {nameof(ILoquiRegistration)}[]");
                        using (new BraceWrapper(mappingGen) { AppendSemicolon = true, AppendParenthesis = true })
                        {
                            foreach (var inheriting in await rec.InheritingObjects())
                            {
                                if (grupTypes.Contains(inheriting))
                                {
                                    mappingGen.AppendLine($"{inheriting.RegistrationName}.Instance,");
                                }
                            }
                        }
        
                        mappingGen.AppendLine(
                            $"dict[typeof({rec.Interface(getter: true)})] = dict[typeof({rec.Interface(getter: false)})] with {{ Setter = false }};");
                    }
        
                    mappingGen.AppendLine($"InterfaceToObjectTypes = dict;");
                }
            }
        }
        
        mappingGen.AppendLine();
        var mappingPath = Path.Combine(proto.DefFileLocation.FullName,
            $"../Interfaces/IsolatedAbstractInterfaceMapping{Loqui.Generation.Constants.AutogeneratedMarkerString}.cs");
        mappingGen.Generate(mappingPath);
        proto.GeneratedFiles.Add(mappingPath, ProjItemType.Compile);
    }

    private static async Task GenerateInheritingMapping(ProtocolGeneration proto, HashSet<ObjectGeneration> grupTypes)
    {
        Dictionary<ObjectGeneration, ObjectGeneration> inheritingChildren = new();

        foreach (var obj in proto.ObjectGenerationsByID.Values)
        {
            if (grupTypes.Contains(obj)) continue;
            if (!await obj.IsMajorRecord()) continue;
            if (obj.BaseClass != null
                && !obj.BaseClass.Name.EndsWith("MajorRecord"))
            {
                inheritingChildren.Add(obj, obj.BaseClass);
            }
        }

        FileGeneration mappingGen = new FileGeneration();
        ObjectGeneration.AddAutogenerationComment(mappingGen);
        mappingGen.AppendLine($"using System;");
        mappingGen.AppendLine($"using System.Collections.Generic;");
        mappingGen.AppendLine($"using Mutagen.Bethesda.Plugins.Records.Mapping;");
        mappingGen.AppendLine($"using Loqui;");
        mappingGen.AppendLine();
        using (new NamespaceWrapper(mappingGen, proto.DefaultNamespace))
        {
            using (var c = new ClassWrapper(mappingGen, $"{proto.Protocol.Namespace}InheritingInterfaceMapping"))
            {
                c.Public = PermissionLevel.@internal;
                c.Interfaces.Add(nameof(IInterfaceMapping));
            }

            using (new BraceWrapper(mappingGen))
            {
                mappingGen.AppendLine(
                    $"public IReadOnlyDictionary<Type, {nameof(InterfaceMappingResult)}> InterfaceToObjectTypes {{ get; }}");
                mappingGen.AppendLine();
                mappingGen.AppendLine(
                    $"public {nameof(GameCategory)} GameCategory => {nameof(GameCategory)}.{proto.Protocol.Namespace};");
                mappingGen.AppendLine();

                mappingGen.AppendLine($"public {proto.Protocol.Namespace}InheritingInterfaceMapping()");
                using (new BraceWrapper(mappingGen))
                {
                    mappingGen.AppendLine($"var dict = new Dictionary<Type, {nameof(InterfaceMappingResult)}>();");
                    foreach (var rec in inheritingChildren.OrderBy(x => x.Key.Name))
                    {
                        mappingGen.AppendLine(
                            $"dict[typeof({rec.Key.Interface(getter: false)})] = new {nameof(InterfaceMappingResult)}(true, new {nameof(ILoquiRegistration)}[]");
                        using (new BraceWrapper(mappingGen) { AppendSemicolon = true, AppendParenthesis = true })
                        {
                            mappingGen.AppendLine($"{rec.Value.RegistrationName}.Instance,");
                        }

                        mappingGen.AppendLine(
                            $"dict[typeof({rec.Key.Interface(getter: true)})] = dict[typeof({rec.Key.Interface(getter: false)})] with {{ Setter = false }};");
                    }

                    mappingGen.AppendLine($"InterfaceToObjectTypes = dict;");
                }
            }
        }

        mappingGen.AppendLine();
        var mappingPath = Path.Combine(proto.DefFileLocation.FullName,
            $"../Interfaces/InheritingInterfaceMapping{Loqui.Generation.Constants.AutogeneratedMarkerString}.cs");
        mappingGen.Generate(mappingPath);
        proto.GeneratedFiles.Add(mappingPath, ProjItemType.Compile);
    }
}