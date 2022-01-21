using Loqui;
using Loqui.Generation;
using System;
using System.Linq;
using Noggog;
using System.Threading.Tasks;
using Mutagen.Bethesda.Generation.Fields;
using Mutagen.Bethesda.Generation.Modules.Plugin;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Meta;
using EnumType = Mutagen.Bethesda.Generation.Fields.EnumType;

namespace Mutagen.Bethesda.Generation.Modules.Binary
{
    public class EnumBinaryTranslationGeneration : BinaryTranslationGeneration
    {
        public override bool NeedsNamespacePrefix => false;

        public override string GetTranslatorInstance(TypeGeneration typeGen, bool getter)
        {
            var eType = typeGen as EnumType;
            return $"EnumBinaryTranslation<{eType.NoNullTypeName}, {Module.ReaderClass}, {Module.WriterClass}>.Instance";
        }

        public override bool AllowDirectWrite(
            ObjectGeneration objGen,
            TypeGeneration typeGen) => false;
        public override bool AllowDirectParse(
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            bool squashedRepeatedList) => false;

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
            var eType = typeGen as EnumType;
            var data = typeGen.CustomData[Constants.DataKey] as MutagenFieldData;
            var nullable = typeGen.Nullable && eType.NullableFallbackInt == null;
            using (var args = new ArgsWrapper(fg,
                $"{NamespacePrefix}{GetTranslatorInstance(typeGen, getter: true)}.Write{(nullable ? "Nullable" : null)}"))
            {
                args.Add(writerAccessor.Access);
                if (eType.NullableFallbackInt == null)
                {
                    args.Add($"{itemAccessor}");
                }
                else
                {
                    args.Add($"((int?){itemAccessor}) ?? {eType.NullableFallbackInt}");
                }
                args.Add($"length: {eType.ByteLength}");
                if (this.DoErrorMasks)
                {
                    if (typeGen.HasIndex)
                    {
                        args.Add($"fieldIndex: (int){typeGen.IndexEnumName}");
                    }
                    args.Add($"errorMask: {errorMaskAccessor}");
                }
                if (data.RecordType.HasValue)
                {
                    args.Add($"header: translationParams.ConvertToCustom({objGen.RecordTypeHeaderName(data.RecordType.Value)})");
                }
            }
        }

        public override async Task GenerateCopyIn(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor frameAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor)
        {
            var data = typeGen.CustomData[Constants.DataKey] as MutagenFieldData;
            var eType = typeGen as EnumType;
            if (data.HasTrigger)
            {
                fg.AppendLine($"{frameAccessor}.Position += {frameAccessor}.{nameof(MutagenBinaryReadStream.MetaData)}.{nameof(ParsingBundle.Constants)}.{nameof(GameConstants.SubConstants)}.{nameof(RecordHeaderConstants.HeaderLength)};");
            }

            TranslationGeneration.WrapParseCall(
                new TranslationWrapParseArgs()
                {
                    FG = fg,
                    TypeGen = typeGen,
                    TranslatorLine = GetTranslatorInstance(typeGen, getter: true),
                    MaskAccessor = errorMaskAccessor,
                    ItemAccessor = itemAccessor,
                    TranslationMaskAccessor = null,
                    IndexAccessor = typeGen.IndexEnumInt,
                    ExtraArgs = $"reader: {frameAccessor}".AsEnumerable()
                        .And($"length: {(data.HasTrigger ? "contentLength" : eType.ByteLength.ToString())}"),
                    SkipErrorMask = !this.DoErrorMasks
                });
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
            Accessor translationAccessor,
            Accessor converterAccessor,
            bool inline)
        {
            var eType = typeGen as EnumType;
            if (inline)
            {
                throw new NotImplementedException();
            }
            else
            {
                using (var args = new ArgsWrapper(fg,
                    $"{retAccessor}{this.NamespacePrefix}{GetTranslatorInstance(typeGen, getter: true)}.Parse"))
                {
                    args.Add($"reader: {nodeAccessor}.SpawnWithLength({eType.ByteLength})");
                    if (asyncMode == AsyncMode.Off)
                    {
                        args.Add($"item: out {outItemAccessor}");
                    }
                    if (this.DoErrorMasks)
                    {
                        args.Add($"errorMask: {errorMaskAccessor}");
                    }
                }
            }
        }

        public override async Task GenerateWrapperFields(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor dataAccessor,
            int? currentPosition,
            string passedLengthAccessor,
            DataType dataType)
        {
            var eType = typeGen as EnumType;
            var data = typeGen.GetFieldData();
            var nullable = typeGen.Nullable && eType.NullableFallbackInt == null;
            switch (data.BinaryOverlayFallback)
            {
                case BinaryGenerationType.Normal:
                    break;
                case BinaryGenerationType.NoGeneration:
                    return;
                case BinaryGenerationType.Custom:
                    await this.Module.CustomLogic.GenerateForCustomFlagWrapperFields(
                        fg,
                        objGen,
                        typeGen,
                        dataAccessor,
                        currentPosition,
                        passedLengthAccessor,
                        dataType);
                    return;
                default:
                    throw new NotImplementedException();
            }

            if (dataType == null && data.HasVersioning && !typeGen.Nullable)
            {
                fg.AppendLine($"private bool _{typeGen.Name}_IsSet => {VersioningModule.GetVersionIfCheck(data, "_package.FormVersion!.FormVersion!.Value")};");
            }
            if (data.HasTrigger)
            {
                fg.AppendLine($"private int? _{typeGen.Name}Location;");
            }
            var posStr = dataType == null ? passedLengthAccessor : $"_{typeGen.Name}Location";
            posStr ??= "0x0";
            string slice;
            if (data.RecordType.HasValue)
            {
                slice = $"{nameof(HeaderTranslation)}.{nameof(HeaderTranslation.ExtractSubrecordMemory)}({dataAccessor}, _{typeGen.Name}Location!.Value, _package.{nameof(BinaryOverlayFactoryPackage.MetaData)}.{nameof(ParsingBundle.Constants)})";
            }
            else
            {
                slice = $"{dataAccessor}.Span.Slice({posStr}, 0x{eType.ByteLength:X})";
            }
            var getType = GenerateForTypicalWrapper(objGen, typeGen, slice, "_package");

            if (dataType != null)
            {
                DataBinaryTranslationGeneration.GenerateWrapperExtraMembers(fg, dataType, objGen, typeGen, passedLengthAccessor);
            }

            bool isSetCheck = dataType != null || data.HasVersioning;

            if (eType.NullableFallbackInt != null)
            {
                fg.AppendLine($"public {eType.TypeName(getter: true)}? {eType.Name}");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine("get");
                    using (new BraceWrapper(fg))
                    {
                        fg.AppendLine($"var val = {getType};");
                        fg.AppendLine($"if (((int)val) == {eType.NullableFallbackInt}) return null;");
                        fg.AppendLine("return val;");
                    }
                }
            }
            else if (data.HasTrigger)
            {
                if (typeGen.CanBeNullable(getter: true))
                {
                    fg.AppendLine($"public {eType.TypeName(getter: true)}{(nullable ? "?" : null)} {eType.Name} => _{typeGen.Name}Location.HasValue ? {getType} : default({eType.TypeName(getter: true)}{(nullable ? "?" : null)});");
                }
                else
                {
                    fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => {getType};");
                }
            }
            else
            {
                if (!isSetCheck)
                {
                    if (data.IsAfterBreak)
                    {
                        fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => {dataAccessor}.Span.Length <= {posStr} ? default : {getType};");
                    }
                    else
                    {
                        fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => {getType};");
                    }
                }
                else
                {
                    fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => _{typeGen.Name}_IsSet ? {getType} : default;");
                }
            }

        }

        public override async Task<int?> GetPassedAmount(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            var data = typeGen.GetFieldData();
            if (!data.RecordType.HasValue)
            {
                return await this.ExpectedLength(objGen, typeGen) ?? null;
            }
            return 0;
        }

        public override async Task<int?> ExpectedLength(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            var eType = typeGen as EnumType;
            return eType.ByteLength;
        }

        public override string GenerateForTypicalWrapper(ObjectGeneration objGen, TypeGeneration typeGen, Accessor dataAccessor, Accessor packageAccessor)
        {
            var eType = typeGen as EnumType;
            switch (eType.ByteLength)
            {
                case 1:
                    return $"({eType.TypeName(getter: true)}){dataAccessor}[0]";
                case 2:
                    return $"({eType.TypeName(getter: true)})BinaryPrimitives.ReadUInt16LittleEndian({dataAccessor})";
                case 4:
                    return $"({eType.TypeName(getter: true)})BinaryPrimitives.ReadInt32LittleEndian({dataAccessor})";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
