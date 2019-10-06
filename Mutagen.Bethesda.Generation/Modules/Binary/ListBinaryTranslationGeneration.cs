﻿using Loqui;
using Loqui.Generation;
using Noggog;
using Mutagen.Bethesda.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mutagen.Bethesda.Generation
{
    public enum ListBinaryType
    {
        SubTrigger,
        Trigger,
        Frame
    }

    public class ListBinaryTranslationGeneration : BinaryTranslationGeneration
    {
        public virtual string TranslatorName => $"ListBinaryTranslation";

        const string AsyncItemKey = "ListAsyncItem";
        const string ThreadKey = "ListThread";

        public override string GetTranslatorInstance(TypeGeneration typeGen, bool getter)
        {
            var list = typeGen as ListType;
            if (!Module.TryGetTypeGeneration(list.SubTypeGeneration.GetType(), out var subTransl))
            {
                throw new ArgumentException("Unsupported type generator: " + list.SubTypeGeneration);
            }

            var subMaskStr = subTransl.MaskModule.GetMaskModule(list.SubTypeGeneration.GetType()).GetErrorMaskTypeStr(list.SubTypeGeneration);
            return $"{TranslatorName}<{list.SubTypeGeneration.TypeName(getter)}, {subMaskStr}>.Instance";
        }

        public override bool IsAsync(TypeGeneration gen, bool read)
        {
            var listType = gen as ListType;
            if (listType.CustomData.TryGetValue(ThreadKey, out var val) && ((bool)val)) return true;
            if (this.Module.TryGetTypeGeneration(listType.SubTypeGeneration.GetType(), out var keyGen)
                && keyGen.IsAsync(listType.SubTypeGeneration, read)) return true;
            return false;
        }

        public override void Load(ObjectGeneration obj, TypeGeneration field, XElement node)
        {
            var asyncItem = node.GetAttribute<bool>("asyncItems", false);
            var thread = node.GetAttribute<bool>("thread", false);
            var listType = field as ListType;
            listType.CustomData[ThreadKey] = thread;
            if (asyncItem && listType.SubTypeGeneration is LoquiType loqui)
            {
                loqui.CustomData[LoquiBinaryTranslationGeneration.AsyncOverrideKey] = asyncItem;
            }
        }

        private ListBinaryType GetListType(
            ListType list,
            MutagenFieldData data,
            MutagenFieldData subData)
        {
            if (subData.HasTrigger)
            {
                return ListBinaryType.SubTrigger;
            }
            else if (data.RecordType.HasValue)
            {
                return ListBinaryType.Trigger;
            }
            else
            {
                return ListBinaryType.Frame;
            }
        }

        protected virtual string GetWriteAccessor(Accessor itemAccessor)
        {
            return itemAccessor.PropertyOrDirectAccess;
        }

        public override void GenerateWrite(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor writerAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor)
        {
            var list = typeGen as ListType;
            if (!this.Module.TryGetTypeGeneration(list.SubTypeGeneration.GetType(), out var subTransl))
            {
                throw new ArgumentException("Unsupported type generator: " + list.SubTypeGeneration);
            }

            if (typeGen.TryGetFieldData(out var data)
                && data.MarkerType.HasValue)
            {
                fg.AppendLine($"using (HeaderExport.ExportHeader(writer, {objGen.RegistrationName}.{data.MarkerType.Value.Type}_HEADER, ObjectType.Subrecord)) {{ }}");
            }

            var subData = list.SubTypeGeneration.GetFieldData();

            ListBinaryType listBinaryType = GetListType(list, data, subData);

            var allowDirectWrite = subTransl.AllowDirectWrite(objGen, typeGen);
            var isLoqui = list.SubTypeGeneration is LoquiType;
            var listOfRecords = !isLoqui
                && listBinaryType == ListBinaryType.SubTrigger
                && allowDirectWrite;

            var typeName = list.SubTypeGeneration.TypeName(getter: true);
            if (list.SubTypeGeneration is LoquiType loqui)
            {
                typeName = loqui.TypeName(getter: true, internalInterface: true);
            }

            using (var args = new ArgsWrapper(fg,
                $"{this.Namespace}ListBinaryTranslation<{typeName}>.Instance.Write{(listOfRecords ? "ListOfRecords" : null)}"))
            {
                args.Add($"writer: {writerAccessor}");
                args.Add($"items: {GetWriteAccessor(itemAccessor)}");
                if (subTransl.DoErrorMasks)
                {
                    args.Add($"fieldIndex: (int){typeGen.IndexEnumName}");
                }
                if (listBinaryType == ListBinaryType.Trigger)
                {
                    args.Add($"recordType: {objGen.RecordTypeHeaderName(data.RecordType.Value)}");
                }
                if (listOfRecords)
                {
                    args.Add($"recordType: {subData.TriggeringRecordSetAccessor}");
                }
                if (subTransl.DoErrorMasks)
                {
                    args.Add($"errorMask: {errorMaskAccessor}");
                }
                if (this.Module.TranslationMaskParameter)
                {
                    args.Add($"translationMask: {translationMaskAccessor}");
                }
                if (allowDirectWrite)
                {
                    args.Add($"transl: {subTransl.GetTranslatorInstance(list.SubTypeGeneration, getter: true)}.Write");
                }
                else
                {
                    args.Add((gen) =>
                    {
                        var listTranslMask = this.MaskModule.GetMaskModule(list.SubTypeGeneration.GetType()).GetTranslationMaskTypeStr(list.SubTypeGeneration);
                        gen.AppendLine($"transl: (MutagenWriter subWriter, {typeName} subItem{(subTransl.DoErrorMasks ? ", ErrorMaskBuilder listErrorMask" : null)}) =>");
                        using (new BraceWrapper(gen))
                        {
                            subTransl.GenerateWrite(
                                fg: gen,
                                objGen: objGen,
                                typeGen: list.SubTypeGeneration,
                                writerAccessor: "subWriter",
                                translationAccessor: "listTranslMask",
                                itemAccessor: new Accessor($"subItem"),
                                errorMaskAccessor: $"listErrorMask");
                        }
                    });
                }
            }
        }

        public override void GenerateCopyIn(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor nodeAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor)
        {
            var list = typeGen as ListType;
            var data = list.GetFieldData();
            var subData = list.SubTypeGeneration.GetFieldData();
            if (!this.Module.TryGetTypeGeneration(list.SubTypeGeneration.GetType(), out var subTransl))
            {
                throw new ArgumentException("Unsupported type generator: " + list.SubTypeGeneration);
            }

            var isAsync = subTransl.IsAsync(list.SubTypeGeneration, read: true);
            ListBinaryType listBinaryType = GetListType(list, data, subData);

            if (data.MarkerType.HasValue)
            {
                fg.AppendLine($"frame.Position += frame.{nameof(MutagenFrame.MetaData)}.{nameof(MetaDataConstants.SubConstants)}.{nameof(MetaDataConstants.SubConstants.HeaderLength)} + contentLength; // Skip marker");
            }
            else if (listBinaryType == ListBinaryType.Trigger)
            {
                fg.AppendLine($"frame.Position += frame.{nameof(MutagenBinaryReadStream.MetaData)}.{nameof(MetaDataConstants.SubConstants)}.{nameof(RecordConstants.HeaderLength)};");
            }

            bool threading = list.CustomData.TryGetValue(ThreadKey, out var t)
                && (bool)t;

            using (var args = new ArgsWrapper(fg,
                $"{Loqui.Generation.Utility.Await(isAsync)}{this.Namespace}List{(isAsync ? "Async" : null)}BinaryTranslation<{list.SubTypeGeneration.TypeName(getter: false)}>.Instance.ParseRepeatedItem",
                suffixLine: Loqui.Generation.Utility.ConfigAwait(isAsync)))
            {
                if (list is ArrayType arr
                    && arr.FixedSize.HasValue)
                {
                    args.Add($"frame: frame");
                    args.Add($"amount: {arr.FixedSize.Value}");
                }
                else if (listBinaryType == ListBinaryType.SubTrigger)
                {
                    args.Add($"frame: frame");
                    args.Add($"triggeringRecord: {subData.TriggeringRecordSetAccessor}");
                }
                else if (listBinaryType == ListBinaryType.Trigger)
                {
                    args.Add($"frame: frame.SpawnWithLength(contentLength)");
                }
                else if (listBinaryType == ListBinaryType.Frame)
                {
                    args.Add($"frame: frame");
                }
                else
                {
                    throw new NotImplementedException();
                }
                if (threading)
                {
                    args.Add($"thread: true");
                }
                if (list.SubTypeGeneration is FormIDLinkType)
                {
                    args.Add($"masterReferences: masterReferences");
                }
                args.Add($"item: {itemAccessor.PropertyOrDirectAccess}");
                if (subTransl.DoErrorMasks)
                {
                    args.Add($"fieldIndex: (int){typeGen.IndexEnumName}");
                }
                if (list.CustomData.TryGetValue("lengthLength", out object len))
                {
                    args.Add($"lengthLength: {len}");
                }
                else if (list.SubTypeGeneration.GetFieldData().HasTrigger)
                {
                    if (list.SubTypeGeneration is MutagenLoquiType loqui)
                    {
                        switch (loqui.GetObjectType())
                        {
                            case ObjectType.Subrecord:
                                args.Add($"lengthLength: frame.{nameof(MutagenFrame.MetaData)}.{nameof(MetaDataConstants.SubConstants)}.{nameof(MetaDataConstants.SubConstants.LengthLength)}");
                                break;
                            case ObjectType.Group:
                                args.Add($"lengthLength: frame.{nameof(MutagenFrame.MetaData)}.{nameof(MetaDataConstants.GroupConstants)}.{nameof(MetaDataConstants.SubConstants.LengthLength)}");
                                break;
                            case ObjectType.Record:
                                args.Add($"lengthLength: frame.{nameof(MutagenFrame.MetaData)}.{nameof(MetaDataConstants.MajorConstants)}.{nameof(MetaDataConstants.SubConstants.LengthLength)}");
                                break;
                            case ObjectType.Mod:
                            default:
                                throw new ArgumentException();
                        }
                    }
                    else
                    {
                        args.Add($"lengthLength: frame.{nameof(MutagenFrame.MetaData)}.{nameof(MetaDataConstants.SubConstants)}.{nameof(MetaDataConstants.SubConstants.LengthLength)}");
                    }
                }
                if (subTransl.DoErrorMasks)
                {
                    args.Add($"errorMask: {errorMaskAccessor}");
                }
                var subGenTypes = subData.GenerationTypes.ToList();
                var subGen = this.Module.GetTypeGeneration(list.SubTypeGeneration.GetType());
                if (subGenTypes.Count <= 1 && subTransl.AllowDirectParse(
                    objGen,
                    typeGen: typeGen,
                    squashedRepeatedList: listBinaryType == ListBinaryType.Trigger))
                {
                    if (list.SubTypeGeneration is LoquiType loqui
                        && !loqui.CanStronglyType)
                    {
                        args.Add($"transl: {subTransl.GetTranslatorInstance(list.SubTypeGeneration, getter: false)}.Parse<{loqui.TypeName(getter: false)}>");
                    }
                    else
                    {
                        args.Add($"transl: {subTransl.GetTranslatorInstance(list.SubTypeGeneration, getter: false)}.Parse");
                    }
                }
                else
                {
                    args.Add((gen) =>
                    {
                        gen.AppendLine($"transl: {Loqui.Generation.Utility.Async(isAsync)}(MutagenFrame r{(subGenTypes.Count <= 1 ? string.Empty : ", RecordType header")}{(isAsync ? null : $", out {list.SubTypeGeneration.TypeName(getter: false)} listSubItem")}{(subTransl.DoErrorMasks ? ", ErrorMaskBuilder listErrMask" : null)}) =>");
                        using (new BraceWrapper(gen))
                        {
                            if (subGenTypes.Count <= 1)
                            {
                                subGen.GenerateCopyInRet(
                                    fg: gen,
                                    objGen: objGen,
                                    targetGen: list.SubTypeGeneration,
                                    typeGen: list.SubTypeGeneration,
                                    readerAccessor: "r",
                                    translationAccessor: "listTranslMask",
                                    retAccessor: "return ",
                                    outItemAccessor: new Accessor("listSubItem"),
                                    asyncMode: isAsync ? AsyncMode.Async : AsyncMode.Off,
                                    errorMaskAccessor: "listErrMask");
                            }
                            else
                            {
                                gen.AppendLine("switch (header.TypeInt)");
                                using (new BraceWrapper(gen))
                                {
                                    foreach (var item in subGenTypes)
                                    {
                                        foreach (var trigger in item.Key)
                                        {
                                            gen.AppendLine($"case 0x{trigger.TypeInt.ToString("X")}: // {trigger.Type}");
                                        }
                                        LoquiType targetLoqui = list.SubTypeGeneration as LoquiType;
                                        LoquiType specificLoqui = item.Value as LoquiType;
                                        using (new DepthWrapper(gen))
                                        {
                                            subGen.GenerateCopyInRet(
                                                fg: gen,
                                                objGen: objGen,
                                                targetGen: list.SubTypeGeneration,
                                                typeGen: item.Value,
                                                readerAccessor: "r",
                                                translationAccessor: "listTranslMask",
                                                retAccessor: "return ",
                                                outItemAccessor: new Accessor("listSubItem"),
                                                asyncMode: AsyncMode.Async,
                                                errorMaskAccessor: $"listErrMask");
                                        }
                                    }
                                    gen.AppendLine("default:");
                                    using (new DepthWrapper(gen))
                                    {
                                        gen.AppendLine("throw new NotImplementedException();");
                                    }
                                }
                            }
                        }
                    });
                }
            }
        }

        public override void GenerateCopyInRet(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration targetGen,
            TypeGeneration typeGen,
            Accessor nodeAccessor,
            AsyncMode asyncMode,
            Accessor retAccessor,
            Accessor outItemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationAccessor)
        {
            throw new NotImplementedException();
        }

        public override void GenerateWrapperFields(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor dataAccessor,
            int currentPosition,
            DataType dataType = null)
        {
            ListType list = typeGen as ListType;
            var data = list.GetFieldData();
            switch (data.BinaryWrapperFallback)
            {
                case BinaryGenerationType.Normal:
                    break;
                case BinaryGenerationType.DoNothing:
                case BinaryGenerationType.NoGeneration:
                    return;
                case BinaryGenerationType.Custom:
                    using (var args = new ArgsWrapper(fg,
                        $"partial void {typeGen.Name}CustomParse"))
                    {
                        args.Add($"{nameof(BinaryMemoryReadStream)} stream");
                        args.Add($"long finalPos");
                        args.Add($"int offset");
                        args.Add($"{nameof(RecordType)} type");
                        args.Add($"int? lastParsed");
                    }
                    return;
                default:
                    throw new NotImplementedException();
            }
            var subGen = this.Module.GetTypeGeneration(list.SubTypeGeneration.GetType());
            if (list.SubTypeGeneration is LoquiType loqui)
            {
                var typeName = this.Module.BinaryWrapperClassName(loqui);
                fg.AppendLine($"public {list.Interface(getter: true, internalInterface: true)} {typeGen.Name} {{ get; private set; }} = EmptySetList<{typeName}>.Instance;");
            }
            else if (data.HasTrigger)
            {
                fg.AppendLine($"public {list.Interface(getter: true, internalInterface: true)} {typeGen.Name} {{ get; private set; }} = EmptySetList<{list.SubTypeGeneration.TypeName(getter: true)}>.Instance;");
            }
            else
            {
                fg.AppendLine($"public {list.Interface(getter: true, internalInterface: true)} {typeGen.Name} => BinaryWrapperSetList<{list.SubTypeGeneration.TypeName(getter: true)}>.FactoryByStartIndex({dataAccessor}.Slice({currentPosition}), _package, {subGen.ExpectedLength(objGen, list.SubTypeGeneration)}, (s, p) => {subGen.GenerateForTypicalWrapper(objGen, list.SubTypeGeneration, "s", "p")});");
            }
        }

        public override int? ExpectedLength(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            return null;
        }

        public override async Task GenerateWrapperRecordTypeParse(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor locationAccessor,
            Accessor packageAccessor,
            Accessor converterAccessor)
        {
            ListType list = typeGen as ListType;
            var data = list.GetFieldData();
            switch (data.BinaryWrapperFallback)
            {
                case BinaryGenerationType.Normal:
                    break;
                case BinaryGenerationType.DoNothing:
                case BinaryGenerationType.NoGeneration:
                    return;
                case BinaryGenerationType.Custom:
                    using (var args = new ArgsWrapper(fg,
                        $"{typeGen.Name}CustomParse"))
                    {
                        args.AddPassArg($"stream");
                        args.AddPassArg($"finalPos");
                        args.AddPassArg($"offset");
                        args.AddPassArg($"type");
                        args.AddPassArg($"lastParsed");
                    }
                    return;
                default:
                    throw new NotImplementedException();
            }

            if (data.MarkerType.HasValue)
            {
                fg.AppendLine($"stream.Position += {packageAccessor}.Meta.SubConstants.HeaderLength; // Skip marker");
            }
            var subData = list.SubTypeGeneration.GetFieldData();
            var subGenTypes = subData.GenerationTypes.ToList();
            ListBinaryType listBinaryType = GetListType(list, data, subData);
            var subGen = this.Module.GetTypeGeneration(list.SubTypeGeneration.GetType());
            string typeName;
            LoquiType loqui = list.SubTypeGeneration as LoquiType;
            if (loqui != null)
            {
                typeName = this.Module.BinaryWrapperClassName(loqui);
            }
            else
            {
                typeName = list.SubTypeGeneration.TypeName(getter: true);
            }
            switch (listBinaryType)
            {
                case ListBinaryType.SubTrigger:
                    if (loqui != null)
                    {
                        if (loqui.TargetObjectGeneration.IsTypelessStruct())
                        {
                            using (var args = new ArgsWrapper(fg,
                                $"this.{typeGen.Name} = this.{nameof(BinaryWrapper.ParseRepeatedTypelessSubrecord)}<{typeName}>"))
                            {
                                args.AddPassArg("stream");
                                args.Add($"recordTypeConverter: {converterAccessor}");
                                args.Add($"trigger: {subData.TriggeringRecordSetAccessor}");
                                if (subGenTypes.Count <= 1)
                                {
                                    args.Add($"factory:  {this.Module.BinaryWrapperClassName(loqui)}.{loqui.TargetObjectGeneration.Name}Factory");
                                }
                                else
                                {
                                    args.Add((subFg) =>
                                    {
                                        subFg.AppendLine("factory: (s, r, p, recConv) =>");
                                        using (new BraceWrapper(subFg))
                                        {
                                            subFg.AppendLine("switch (r.TypeInt)");
                                            using (new BraceWrapper(subFg))
                                            {
                                                foreach (var item in subGenTypes)
                                                {
                                                    foreach (var trigger in item.Key)
                                                    {
                                                        subFg.AppendLine($"case 0x{trigger.TypeInt.ToString("X")}: // {trigger.Type}");
                                                    }
                                                    using (new DepthWrapper(subFg))
                                                    {
                                                        LoquiType specificLoqui = item.Value as LoquiType;
                                                        subFg.AppendLine($"return {this.Module.BinaryWrapperClassName(specificLoqui.TargetObjectGeneration)}.{specificLoqui.TargetObjectGeneration.Name}Factory(s, p);");
                                                    }
                                                }
                                                subFg.AppendLine("default:");
                                                using (new DepthWrapper(subFg))
                                                {
                                                    subFg.AppendLine("throw new NotImplementedException();");
                                                }
                                            }
                                        }
                                    });
                                }
                            }
                        }
                        else
                        {
                            using (var args = new ArgsWrapper(fg,
                                $"this.{typeGen.Name} = BinaryWrapperSetList<{typeName}>.FactoryByArray"))
                            {
                                args.Add($"mem: stream.RemainingMemory");
                                args.Add($"package: _package");
                                args.Add($"recordTypeConverter: {converterAccessor}");
                                args.Add($"getter: (s, p, recConv) => {typeName}.{loqui.TargetObjectGeneration.Name}Factory(new {nameof(BinaryMemoryReadStream)}(s), p, recConv)");
                                args.Add(subFg =>
                                {
                                    using (var subArgs = new FunctionWrapper(subFg,
                                        $"locs: {nameof(BinaryWrapper.ParseRecordLocations)}"))
                                    {
                                        subArgs.AddPassArg("stream");
                                        subArgs.AddPassArg("finalPos");
                                        subArgs.Add("trigger: type");
                                        switch (loqui.TargetObjectGeneration.GetObjectType())
                                        {
                                            case ObjectType.Subrecord:
                                                subArgs.Add($"constants: _package.Meta.{nameof(MetaDataConstants.SubConstants)}");
                                                break;
                                            case ObjectType.Record:
                                                subArgs.Add($"constants: _package.Meta.{nameof(MetaDataConstants.MajorConstants)}");
                                                break;
                                            case ObjectType.Group:
                                                subArgs.Add($"constants: _package.Meta.{nameof(MetaDataConstants.GroupConstants)}");
                                                break;
                                            case ObjectType.Mod:
                                            default:
                                                throw new NotImplementedException();
                                        }
                                        subArgs.Add("skipHeader: false");
                                    }
                                });
                            }
                        }
                    }

                    else
                    {
                        using (var args = new ArgsWrapper(fg,
                            $"this.{typeGen.Name} = BinaryWrapperSetList<{typeName}>.FactoryByArray"))
                        {
                            args.Add($"mem: stream.RemainingMemory");
                            args.Add($"package: _package");
                            args.Add($"getter: (s, p) => {subGen.GenerateForTypicalWrapper(objGen, list.SubTypeGeneration, "s", "p")}");
                            args.Add(subFg =>
                            {
                                using (var subArgs = new FunctionWrapper(subFg,
                                    $"locs: {nameof(BinaryWrapper.ParseRecordLocations)}"))
                                {
                                    subArgs.AddPassArg("stream");
                                    subArgs.AddPassArg("finalPos");
                                    subArgs.Add($"constants: _package.Meta.{nameof(MetaDataConstants.SubConstants)}");
                                    subArgs.Add("trigger: type");
                                    subArgs.Add("skipHeader: true");
                                }
                            });
                        }
                    }
                    break;
                case ListBinaryType.Trigger:
                    fg.AppendLine("var subMeta = _package.Meta.ReadSubRecord(stream);");
                    fg.AppendLine("var subLen = subMeta.RecordLength;");
                    var expectedLen = subGen.ExpectedLength(objGen, list.SubTypeGeneration);
                    if (expectedLen.HasValue)
                    {
                        using (var args = new ArgsWrapper(fg,
                            $"this.{typeGen.Name} = BinaryWrapperSetList<{typeName}>.FactoryByStartIndex"))
                        {
                            args.Add($"mem: stream.RemainingMemory.Slice(0, subLen)");
                            args.Add($"package: _package");
                            args.Add($"itemLength: {subGen.ExpectedLength(objGen, list.SubTypeGeneration)}");
                            if (subGenTypes.Count <= 1)
                            {
                                args.Add($"getter: (s, p) => {subGen.GenerateForTypicalWrapper(objGen, list.SubTypeGeneration, "s", "p")}");
                            }
                            else
                            {
                                args.Add((subFg) =>
                                {
                                    subFg.AppendLine("getter: (s, r, p) =>");
                                    using (new BraceWrapper(subFg))
                                    {
                                        subFg.AppendLine("switch (r.TypeInt)");
                                        using (new BraceWrapper(subFg))
                                        {
                                            foreach (var item in subGenTypes)
                                            {
                                                foreach (var trigger in item.Key)
                                                {
                                                    subFg.AppendLine($"case 0x{trigger.TypeInt.ToString("X")}: // {trigger.Type}");
                                                }
                                                using (new DepthWrapper(subFg))
                                                {
                                                    LoquiType specificLoqui = item.Value as LoquiType;
                                                    subFg.AppendLine($"return {subGen.GenerateForTypicalWrapper(objGen, specificLoqui, "s", "p")}");
                                                }
                                            }
                                            subFg.AppendLine("default:");
                                            using (new DepthWrapper(subFg))
                                            {
                                                subFg.AppendLine("throw new NotImplementedException();");
                                            }
                                        }
                                    }
                                });
                            }
                        }
                    }
                    else
                    {
                        using (var args = new ArgsWrapper(fg,
                            $"this.{typeGen.Name} = BinaryWrapperSetList<{typeName}>.FactoryByLazyParse"))
                        {
                            args.Add($"mem: stream.RemainingMemory.Slice(0, subLen)");
                            args.Add($"package: _package");
                            if (subGenTypes.Count <= 1)
                            {
                                args.Add($"getter: (s, p) => {subGen.GenerateForTypicalWrapper(objGen, list.SubTypeGeneration, "s", "p")}");
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                    }
                    fg.AppendLine("stream.Position += subLen;");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
