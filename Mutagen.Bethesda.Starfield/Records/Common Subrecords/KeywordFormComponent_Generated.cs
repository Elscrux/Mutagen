/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Interfaces;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Internals;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Starfield;
using Mutagen.Bethesda.Starfield.Internals;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using Noggog.StructuredStrings;
using Noggog.StructuredStrings.CSharp;
using RecordTypeInts = Mutagen.Bethesda.Starfield.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Starfield.Internals.RecordTypes;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Starfield
{
    #region Class
    public partial class KeywordFormComponent :
        AComponent,
        IEquatable<IKeywordFormComponentGetter>,
        IKeywordFormComponent,
        ILoquiObjectSetter<KeywordFormComponent>
    {
        #region Ctor
        public KeywordFormComponent()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region To String

        public override void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            KeywordFormComponentMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IKeywordFormComponentGetter rhs) return false;
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)this).CommonInstance()!).Equals(this, rhs, equalsMask: null);
        }

        public bool Equals(IKeywordFormComponentGetter? obj)
        {
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)this).CommonInstance()!).Equals(this, obj, equalsMask: null);
        }

        public override int GetHashCode() => ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            AComponent.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
            }


            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Equals
            public override bool Equals(object? obj)
            {
                if (!(obj is Mask<TItem> rhs)) return false;
                return Equals(rhs);
            }

            public bool Equals(Mask<TItem>? rhs)
            {
                if (rhs == null) return false;
                if (!base.Equals(rhs)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new KeywordFormComponent.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(KeywordFormComponent.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, KeywordFormComponent.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(KeywordFormComponent.Mask<TItem>)} =>");
                using (sb.Brace())
                {
                }
            }
            #endregion

        }

        public new class ErrorMask :
            AComponent.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                KeywordFormComponent_FieldIndex enu = (KeywordFormComponent_FieldIndex)index;
                switch (enu)
                {
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                KeywordFormComponent_FieldIndex enu = (KeywordFormComponent_FieldIndex)index;
                switch (enu)
                {
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                KeywordFormComponent_FieldIndex enu = (KeywordFormComponent_FieldIndex)index;
                switch (enu)
                {
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public override void Print(StructuredStringBuilder sb, string? name = null)
            {
                sb.AppendLine($"{(name ?? "ErrorMask")} =>");
                using (sb.Brace())
                {
                    if (this.Overall != null)
                    {
                        sb.AppendLine("Overall =>");
                        using (sb.Brace())
                        {
                            sb.AppendLine($"{this.Overall}");
                        }
                    }
                    PrintFillInternal(sb);
                }
            }
            protected override void PrintFillInternal(StructuredStringBuilder sb)
            {
                base.PrintFillInternal(sb);
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static new ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public new class TranslationMask :
            AComponent.TranslationMask,
            ITranslationMask
        {
            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
            }

            #endregion

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => KeywordFormComponentBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((KeywordFormComponentBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #region Binary Create
        public new static KeywordFormComponent CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            var ret = new KeywordFormComponent();
            ((KeywordFormComponentSetterCommon)((IKeywordFormComponentGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out KeywordFormComponent item,
            TypedParseParams translationParams = default)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                translationParams: translationParams);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        void IClearable.Clear()
        {
            ((KeywordFormComponentSetterCommon)((IKeywordFormComponentGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new KeywordFormComponent GetNew()
        {
            return new KeywordFormComponent();
        }

    }
    #endregion

    #region Interface
    public partial interface IKeywordFormComponent :
        IAComponent,
        IKeywordFormComponentGetter,
        ILoquiObjectSetter<IKeywordFormComponent>
    {
    }

    public partial interface IKeywordFormComponentGetter :
        IAComponentGetter,
        IBinaryItem,
        ILoquiObject<IKeywordFormComponentGetter>
    {
        static new ILoquiRegistration StaticRegistration => KeywordFormComponent_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class KeywordFormComponentMixIn
    {
        public static void Clear(this IKeywordFormComponent item)
        {
            ((KeywordFormComponentSetterCommon)((IKeywordFormComponentGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static KeywordFormComponent.Mask<bool> GetEqualsMask(
            this IKeywordFormComponentGetter item,
            IKeywordFormComponentGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this IKeywordFormComponentGetter item,
            string? name = null,
            KeywordFormComponent.Mask<bool>? printMask = null)
        {
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this IKeywordFormComponentGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            KeywordFormComponent.Mask<bool>? printMask = null)
        {
            ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IKeywordFormComponentGetter item,
            IKeywordFormComponentGetter rhs,
            KeywordFormComponent.TranslationMask? equalsMask = null)
        {
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                equalsMask: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IKeywordFormComponent lhs,
            IKeywordFormComponentGetter rhs,
            out KeywordFormComponent.ErrorMask errorMask,
            KeywordFormComponent.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = KeywordFormComponent.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IKeywordFormComponent lhs,
            IKeywordFormComponentGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static KeywordFormComponent DeepCopy(
            this IKeywordFormComponentGetter item,
            KeywordFormComponent.TranslationMask? copyMask = null)
        {
            return ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static KeywordFormComponent DeepCopy(
            this IKeywordFormComponentGetter item,
            out KeywordFormComponent.ErrorMask errorMask,
            KeywordFormComponent.TranslationMask? copyMask = null)
        {
            return ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static KeywordFormComponent DeepCopy(
            this IKeywordFormComponentGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IKeywordFormComponent item,
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            ((KeywordFormComponentSetterCommon)((IKeywordFormComponentGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Starfield
{
    #region Field Index
    internal enum KeywordFormComponent_FieldIndex
    {
    }
    #endregion

    #region Registration
    internal partial class KeywordFormComponent_Registration : ILoquiRegistration
    {
        public static readonly KeywordFormComponent_Registration Instance = new KeywordFormComponent_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Starfield.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Starfield.ProtocolKey,
            msgID: 885,
            version: 0);

        public const string GUID = "2a979c6c-5762-419f-9f2b-bb2fc2ea7d97";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 0;

        public static readonly Type MaskType = typeof(KeywordFormComponent.Mask<>);

        public static readonly Type ErrorMaskType = typeof(KeywordFormComponent.ErrorMask);

        public static readonly Type ClassType = typeof(KeywordFormComponent);

        public static readonly Type GetterType = typeof(IKeywordFormComponentGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IKeywordFormComponent);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Starfield.KeywordFormComponent";

        public const string Name = "KeywordFormComponent";

        public const string Namespace = "Mutagen.Bethesda.Starfield";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly RecordType TriggeringRecordType = RecordTypes.BFCB;
        public static RecordTriggerSpecs TriggerSpecs => _recordSpecs.Value;
        private static readonly Lazy<RecordTriggerSpecs> _recordSpecs = new Lazy<RecordTriggerSpecs>(() =>
        {
            var all = RecordCollection.Factory(RecordTypes.BFCB);
            return new RecordTriggerSpecs(allRecordTypes: all);
        });
        public static readonly Type BinaryWriteTranslation = typeof(KeywordFormComponentBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        ushort ILoquiRegistration.FieldCount => FieldCount;
        ushort ILoquiRegistration.AdditionalFieldCount => AdditionalFieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type? ILoquiRegistration.InternalSetterType => InternalSetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type? ILoquiRegistration.InternalGetterType => InternalGetterType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type? ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => throw new NotImplementedException();
        string ILoquiRegistration.GetNthName(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsNthDerivative(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsProtected(ushort index) => throw new NotImplementedException();
        Type ILoquiRegistration.GetNthType(ushort index) => throw new NotImplementedException();
        #endregion

    }
    #endregion

    #region Common
    internal partial class KeywordFormComponentSetterCommon : AComponentSetterCommon
    {
        public new static readonly KeywordFormComponentSetterCommon Instance = new KeywordFormComponentSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IKeywordFormComponent item)
        {
            ClearPartial();
            base.Clear(item);
        }
        
        public override void Clear(IAComponent item)
        {
            Clear(item: (IKeywordFormComponent)item);
        }
        
        #region Mutagen
        public void RemapLinks(IKeywordFormComponent obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IKeywordFormComponent item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillTyped: KeywordFormComponentBinaryCreateTranslation.FillBinaryRecordTypes);
        }
        
        public override void CopyInFromBinary(
            IAComponent item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
            CopyInFromBinary(
                item: (KeywordFormComponent)item,
                frame: frame,
                translationParams: translationParams);
        }
        
        #endregion
        
    }
    internal partial class KeywordFormComponentCommon : AComponentCommon
    {
        public new static readonly KeywordFormComponentCommon Instance = new KeywordFormComponentCommon();

        public KeywordFormComponent.Mask<bool> GetEqualsMask(
            IKeywordFormComponentGetter item,
            IKeywordFormComponentGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new KeywordFormComponent.Mask<bool>(false);
            ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IKeywordFormComponentGetter item,
            IKeywordFormComponentGetter rhs,
            KeywordFormComponent.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string Print(
            IKeywordFormComponentGetter item,
            string? name = null,
            KeywordFormComponent.Mask<bool>? printMask = null)
        {
            var sb = new StructuredStringBuilder();
            Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
            return sb.ToString();
        }
        
        public void Print(
            IKeywordFormComponentGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            KeywordFormComponent.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"KeywordFormComponent =>");
            }
            else
            {
                sb.AppendLine($"{name} (KeywordFormComponent) =>");
            }
            using (sb.Brace())
            {
                ToStringFields(
                    item: item,
                    sb: sb,
                    printMask: printMask);
            }
        }
        
        protected static void ToStringFields(
            IKeywordFormComponentGetter item,
            StructuredStringBuilder sb,
            KeywordFormComponent.Mask<bool>? printMask = null)
        {
            AComponentCommon.ToStringFields(
                item: item,
                sb: sb,
                printMask: printMask);
        }
        
        public static KeywordFormComponent_FieldIndex ConvertFieldIndex(AComponent_FieldIndex index)
        {
            switch (index)
            {
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IKeywordFormComponentGetter? lhs,
            IKeywordFormComponentGetter? rhs,
            TranslationCrystal? equalsMask)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if (!base.Equals((IAComponentGetter)lhs, (IAComponentGetter)rhs, equalsMask)) return false;
            return true;
        }
        
        public override bool Equals(
            IAComponentGetter? lhs,
            IAComponentGetter? rhs,
            TranslationCrystal? equalsMask)
        {
            return Equals(
                lhs: (IKeywordFormComponentGetter?)lhs,
                rhs: rhs as IKeywordFormComponentGetter,
                equalsMask: equalsMask);
        }
        
        public virtual int GetHashCode(IKeywordFormComponentGetter item)
        {
            var hash = new HashCode();
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IAComponentGetter item)
        {
            return GetHashCode(item: (IKeywordFormComponentGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return KeywordFormComponent.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(IKeywordFormComponentGetter obj)
        {
            foreach (var item in base.EnumerateFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    internal partial class KeywordFormComponentSetterTranslationCommon : AComponentSetterTranslationCommon
    {
        public new static readonly KeywordFormComponentSetterTranslationCommon Instance = new KeywordFormComponentSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IKeywordFormComponent item,
            IKeywordFormComponentGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IAComponent)item,
                (IAComponentGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
        }
        
        
        public override void DeepCopyIn(
            IAComponent item,
            IAComponentGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IKeywordFormComponent)item,
                rhs: (IKeywordFormComponentGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public KeywordFormComponent DeepCopy(
            IKeywordFormComponentGetter item,
            KeywordFormComponent.TranslationMask? copyMask = null)
        {
            KeywordFormComponent ret = (KeywordFormComponent)((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).GetNew();
            ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public KeywordFormComponent DeepCopy(
            IKeywordFormComponentGetter item,
            out KeywordFormComponent.ErrorMask errorMask,
            KeywordFormComponent.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            KeywordFormComponent ret = (KeywordFormComponent)((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).GetNew();
            ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = KeywordFormComponent.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public KeywordFormComponent DeepCopy(
            IKeywordFormComponentGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            KeywordFormComponent ret = (KeywordFormComponent)((KeywordFormComponentCommon)((IKeywordFormComponentGetter)item).CommonInstance()!).GetNew();
            ((KeywordFormComponentSetterTranslationCommon)((IKeywordFormComponentGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: true);
            return ret;
        }
        
    }
    #endregion

}

namespace Mutagen.Bethesda.Starfield
{
    public partial class KeywordFormComponent
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => KeywordFormComponent_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => KeywordFormComponent_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => KeywordFormComponentCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return KeywordFormComponentSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => KeywordFormComponentSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Starfield
{
    public partial class KeywordFormComponentBinaryWriteTranslation :
        AComponentBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new static readonly KeywordFormComponentBinaryWriteTranslation Instance = new();

        public void Write(
            MutagenWriter writer,
            IKeywordFormComponentGetter item,
            TypedWriteParams translationParams)
        {
            AComponentBinaryWriteTranslation.WriteRecordTypes(
                item: item,
                writer: writer,
                translationParams: translationParams);
            using (HeaderExport.Subrecord(writer, RecordTypes.BFCE)) { } // End Marker
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams translationParams = default)
        {
            Write(
                item: (IKeywordFormComponentGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

        public override void Write(
            MutagenWriter writer,
            IAComponentGetter item,
            TypedWriteParams translationParams)
        {
            Write(
                item: (IKeywordFormComponentGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class KeywordFormComponentBinaryCreateTranslation : AComponentBinaryCreateTranslation
    {
        public new static readonly KeywordFormComponentBinaryCreateTranslation Instance = new KeywordFormComponentBinaryCreateTranslation();

    }

}
namespace Mutagen.Bethesda.Starfield
{
    #region Binary Write Mixins
    public static class KeywordFormComponentBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Starfield
{
    internal partial class KeywordFormComponentBinaryOverlay :
        AComponentBinaryOverlay,
        IKeywordFormComponentGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => KeywordFormComponent_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => KeywordFormComponent_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => KeywordFormComponentCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => KeywordFormComponentSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => KeywordFormComponentBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((KeywordFormComponentBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected KeywordFormComponentBinaryOverlay(
            MemoryPair memoryPair,
            BinaryOverlayFactoryPackage package)
            : base(
                memoryPair: memoryPair,
                package: package)
        {
            this.CustomCtor();
        }

        public static IKeywordFormComponentGetter KeywordFormComponentFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            TypedParseParams translationParams = default)
        {
            stream = ExtractTypelessSubrecordRecordMemory(
                stream: stream,
                meta: package.MetaData.Constants,
                translationParams: translationParams,
                memoryPair: out var memoryPair,
                offset: out var offset,
                finalPos: out var finalPos);
            var ret = new KeywordFormComponentBinaryOverlay(
                memoryPair: memoryPair,
                package: package);
            ret.FillTypelessSubrecordTypes(
                stream: stream,
                finalPos: stream.Length,
                offset: offset,
                translationParams: translationParams,
                fill: ret.FillRecordType);
            return ret;
        }

        public static IKeywordFormComponentGetter KeywordFormComponentFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            TypedParseParams translationParams = default)
        {
            return KeywordFormComponentFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                translationParams: translationParams);
        }

        #region To String

        public override void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            KeywordFormComponentMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IKeywordFormComponentGetter rhs) return false;
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)this).CommonInstance()!).Equals(this, rhs, equalsMask: null);
        }

        public bool Equals(IKeywordFormComponentGetter? obj)
        {
            return ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)this).CommonInstance()!).Equals(this, obj, equalsMask: null);
        }

        public override int GetHashCode() => ((KeywordFormComponentCommon)((IKeywordFormComponentGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

