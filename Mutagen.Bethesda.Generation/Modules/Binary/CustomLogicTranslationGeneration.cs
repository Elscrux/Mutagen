using System;
using System.Threading.Tasks;
using Loqui;
using Loqui.Generation;
using Mutagen.Bethesda.Generation.Fields;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Meta;
using Mutagen.Bethesda.Plugins.Records.Internals;

namespace Mutagen.Bethesda.Generation.Modules.Binary
{
    public class CustomLogicTranslationGeneration : BinaryTranslationGeneration
    {
        public override bool DoErrorMasks => true;

        public override string GetTranslatorInstance(TypeGeneration typeGen, bool getter)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldGenerateWrite(TypeGeneration typeGen)
        {
            return true;
        }

        public override bool ShouldGenerateCopyIn(TypeGeneration typeGen)
        {
            return true;
        }

        public override async Task GenerateCopyIn(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor readerAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor)
        {
            GenerateFill(
                fg: fg,
                objGen: objGen,
                field: typeGen,
                frameAccessor: readerAccessor,
                isAsync: false,
                useReturnValue: true);
        }

        public override void GenerateCopyInRet(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration targetGen,
            TypeGeneration typeGen,
            Accessor readerAccessor,
            AsyncMode asyncMode,
            Accessor retAccessor,
            Accessor outItemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationAccessor,
            Accessor converterAccessor,
            bool inline)
        {
            throw new NotImplementedException();
        }

        public override async Task GenerateWrite(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor writerAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor,
            Accessor converterAccessor)
        {
            this.GenerateWrite(
                fg: fg,
                obj: objGen,
                field: typeGen,
                writerAccessor: writerAccessor);
        }

        public static void GenerateCreatePartialMethods(
            FileGeneration fg,
            ObjectGeneration obj,
            TypeGeneration field,
            bool isAsync,
            bool useReturnValue)
        {
            var fieldData = field.GetFieldData();
            var returningParseResult = useReturnValue && fieldData.HasTrigger;
            if (!isAsync)
            {
                using (var args = new FunctionWrapper(fg,
                    $"public static partial {(returningParseResult ? nameof(ParseResult) : "void")} FillBinary{field.Name}Custom")
                {
                    SemiColon = true
                })
                {
                    args.Add($"{nameof(MutagenFrame)} frame");
                    args.Add($"{obj.Interface(getter: false, internalInterface: true)} item");
                    if (returningParseResult && obj.GetObjectType() == ObjectType.Subrecord)
                    {
                        args.Add($"{nameof(PreviousParse)} lastParsed");
                    }
                }
                fg.AppendLine();
            }
        }

        public static void GenerateWritePartialMethods(
            FileGeneration fg,
            ObjectGeneration obj,
            TypeGeneration field,
            bool isAsync)
        {
            using (var args = new FunctionWrapper(fg,
                $"public static partial void WriteBinary{field.Name}Custom{obj.GetGenericTypes(MaskType.Normal)}"))
            {
                args.Wheres.AddRange(obj.GenerateWhereClauses(LoquiInterfaceType.IGetter, defs: obj.Generics));
                args.SemiColon = true;
                args.Add($"{nameof(MutagenWriter)} writer");
                args.Add($"{obj.Interface(getter: true, internalInterface: true)} item");
            }
            fg.AppendLine();
            using (var args = new FunctionWrapper(fg,
                $"public static void WriteBinary{field.Name}{obj.GetGenericTypes(MaskType.Normal)}"))
            {
                args.Wheres.AddRange(obj.GenerateWhereClauses(LoquiInterfaceType.IGetter, defs: obj.Generics));
                args.Add($"{nameof(MutagenWriter)} writer");
                args.Add($"{obj.Interface(getter: true, internalInterface: true)} item");
            }
            using (new BraceWrapper(fg))
            {
                using (var args = new ArgsWrapper(fg,
                    $"WriteBinary{field.Name}Custom"))
                {
                    args.Add("writer: writer");
                    args.Add("item: item");
                }
            }
            fg.AppendLine();
        }

        public void GenerateWrite(
            FileGeneration fg,
            ObjectGeneration obj,
            TypeGeneration field,
            Accessor writerAccessor)
        {
            using (var args = new ArgsWrapper(fg,
                $"{this.Module.TranslationWriteClass(obj)}.WriteBinary{field.Name}"))
            {
                args.Add($"writer: {writerAccessor}");
                args.Add("item: item");
            }
        }

        public void GenerateFill(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration field,
            Accessor frameAccessor,
            bool isAsync,
            bool useReturnValue)
        {
            var data = field.GetFieldData();
            var returningParseValue = useReturnValue && data.HasTrigger;
            using (var args = new ArgsWrapper(fg,
                $"{(returningParseValue ? "return " : null)}{Loqui.Generation.Utility.Await(isAsync)}{this.Module.TranslationCreateClass(field.ObjectGen)}.FillBinary{field.Name}Custom"))
            {
                args.Add($"frame: {(data.HasTrigger ? $"{frameAccessor}.SpawnWithLength(frame.{nameof(MutagenFrame.MetaData)}.{nameof(ParsingBundle.Constants)}.{nameof(GameConstants.SubConstants)}.{nameof(GameConstants.SubConstants.HeaderLength)} + contentLength)" : frameAccessor)}");
                args.AddPassArg("item");
                if (returningParseValue && objGen.GetObjectType() == ObjectType.Subrecord)
                {
                    args.AddPassArg("lastParsed");
                }
            }
        }

        public async Task GenerateForCustomFlagWrapperFields(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor dataAccessor,
            int? currentPosition,
            string passedLenAccessor,
            DataType? dataType = null)
        {
            var fieldData = typeGen.GetFieldData();
            var gen = this.Module.GetTypeGeneration(typeGen.GetType());
            string loc;
            if (fieldData.HasTrigger)
            {
                using (var args = new ArgsWrapper(fg,
                    $"partial void {typeGen.Name}CustomParse"))
                {
                    args.Add($"{nameof(OverlayStream)} stream");
                    args.Add($"long finalPos");
                    args.Add($"int offset");
                }
                if (typeGen.Nullable && !typeGen.CanBeNullable(getter: true))
                {
                    fg.AppendLine($"public bool {typeGen.Name}_IsSet => Get{typeGen.Name}IsSetCustom();");
                }
                loc = $"_{typeGen.Name}Location.Value";
            }
            else if (dataType != null)
            {
                loc = $"_{typeGen.Name}Location";
                DataBinaryTranslationGeneration.GenerateWrapperExtraMembers(fg, dataType, objGen, typeGen, passedLenAccessor);
            }
            else
            {
                loc = passedLenAccessor;
            }
            using (var args = new ArgsWrapper(fg,
                $"public {typeGen.OverrideStr}{typeGen.TypeName(getter: true)}{(typeGen.IsNullable ? "?" : null)} {typeGen.Name} => Get{typeGen.Name}Custom"))
            {
                if (!fieldData.HasTrigger && dataType == null)
                {
                    args.Add($"location: {loc ?? "0x0"}");
                }
            }
            if (!fieldData.HasTrigger)
            {
                currentPosition += fieldData.Length ?? await gen.ExpectedLength(objGen, typeGen);
            }
        }

        public override async Task GenerateWrapperFields(
            FileGeneration fg, 
            ObjectGeneration objGen, 
            TypeGeneration typeGen, 
            Accessor dataAccessor, 
            int? passedLength,
            string passedLengthAccessor,
            DataType? data = null)
        {
            var fieldData = typeGen.GetFieldData();
            var returningParseValue = fieldData.HasTrigger;
            if (data != null)
            {
                DataBinaryTranslationGeneration.GenerateWrapperExtraMembers(fg, data, objGen, typeGen, passedLengthAccessor);
            }
            using (var args = new ArgsWrapper(fg,
                $"{(returningParseValue ? "public " : null)}partial {(returningParseValue ? nameof(ParseResult) : "void")} {(typeGen.Name == null ? typeGen.GetFieldData().RecordType?.ToString() : typeGen.Name)}CustomParse"))
            {
                args.Add($"{nameof(OverlayStream)} stream");
                args.Add($"int offset");
                if (returningParseValue && objGen.GetObjectType() == ObjectType.Subrecord)
                {
                    args.Add($"{nameof(PreviousParse)} lastParsed");
                }
            }
        }

        public override async Task GenerateWrapperRecordTypeParse(
            FileGeneration fg, 
            ObjectGeneration objGen,  
            TypeGeneration typeGen, 
            Accessor locationAccessor, 
            Accessor packageAccessor, 
            Accessor converterAccessor)
        {
            var fieldData = typeGen.GetFieldData();
            var returningParseValue = fieldData.HasTrigger;
            using (var args = new ArgsWrapper(fg,
                $"{(returningParseValue ? "return " : null)}{(typeGen.Name == null ? typeGen.GetFieldData().RecordType?.ToString() : typeGen.Name)}CustomParse"))
            {
                args.Add("stream");
                args.Add("offset");
                if (returningParseValue && objGen.GetObjectType() == ObjectType.Subrecord)
                {
                    args.AddPassArg("lastParsed");
                }
            }
        }

        public override async Task<int?> ExpectedLength(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            CustomLogic custom = typeGen as CustomLogic;
            var data = typeGen.GetFieldData();
            return data.Length;
        }
    }
}
