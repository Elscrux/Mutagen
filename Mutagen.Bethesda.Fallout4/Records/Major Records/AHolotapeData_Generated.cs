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
using Mutagen.Bethesda.Fallout4.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Internals;
using Mutagen.Bethesda.Plugins.Meta;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using Noggog.StructuredStrings;
using Noggog.StructuredStrings.CSharp;
using RecordTypeInts = Mutagen.Bethesda.Fallout4.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Fallout4.Internals.RecordTypes;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Fallout4
{
    #region Class
    /// <summary>
    /// Implemented by: [HolotapeSound, HolotapeVoice, HolotapeProgram, HolotapeTerminal]
    /// </summary>
    public abstract partial class AHolotapeData :
        IAHolotapeData,
        IEquatable<IAHolotapeDataGetter>,
        ILoquiObjectSetter<AHolotapeData>
    {
        #region Ctor
        public AHolotapeData()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region To String

        public virtual void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            AHolotapeDataMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IAHolotapeDataGetter rhs) return false;
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)this).CommonInstance()!).Equals(this, rhs, equalsMask: null);
        }

        public bool Equals(IAHolotapeDataGetter? obj)
        {
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)this).CommonInstance()!).Equals(this, obj, equalsMask: null);
        }

        public override int GetHashCode() => ((AHolotapeDataCommon)((IAHolotapeDataGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
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
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public virtual bool All(Func<TItem, bool> eval)
            {
                return true;
            }
            #endregion

            #region Any
            public virtual bool Any(Func<TItem, bool> eval)
            {
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new AHolotapeData.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(AHolotapeData.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, AHolotapeData.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(AHolotapeData.Mask<TItem>)} =>");
                using (sb.Brace())
                {
                }
            }
            #endregion

        }

        public class ErrorMask :
            IErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Overall { get; set; }
            private List<string>? _warnings;
            public List<string> Warnings
            {
                get
                {
                    if (_warnings == null)
                    {
                        _warnings = new List<string>();
                    }
                    return _warnings;
                }
            }
            #endregion

            #region IErrorMask
            public virtual object? GetNthMask(int index)
            {
                AHolotapeData_FieldIndex enu = (AHolotapeData_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual void SetNthException(int index, Exception ex)
            {
                AHolotapeData_FieldIndex enu = (AHolotapeData_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual void SetNthMask(int index, object obj)
            {
                AHolotapeData_FieldIndex enu = (AHolotapeData_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual bool IsInError()
            {
                if (Overall != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public virtual void Print(StructuredStringBuilder sb, string? name = null)
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
            protected virtual void PrintFillInternal(StructuredStringBuilder sb)
            {
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
            public static ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public class TranslationMask : ITranslationMask
        {
            #region Members
            private TranslationCrystal? _crystal;
            public readonly bool DefaultOn;
            public bool OnOverall;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
            }

            #endregion

            public TranslationCrystal GetCrystal()
            {
                if (_crystal != null) return _crystal;
                var ret = new List<(bool On, TranslationCrystal? SubCrystal)>();
                GetCrystal(ret);
                _crystal = new TranslationCrystal(ret.ToArray());
                return _crystal;
            }

            protected virtual void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Mutagen
        public virtual IEnumerable<IFormLinkGetter> EnumerateFormLinks() => AHolotapeDataCommon.Instance.EnumerateFormLinks(this);
        public virtual void RemapLinks(IReadOnlyDictionary<FormKey, FormKey> mapping) => AHolotapeDataSetterCommon.Instance.RemapLinks(this, mapping);
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual object BinaryWriteTranslator => AHolotapeDataBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((AHolotapeDataBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        void IClearable.Clear()
        {
            ((AHolotapeDataSetterCommon)((IAHolotapeDataGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static AHolotapeData GetNew()
        {
            throw new ArgumentException("New called on an abstract class.");
        }

    }
    #endregion

    #region Interface
    /// <summary>
    /// Implemented by: [HolotapeSound, HolotapeVoice, HolotapeProgram, HolotapeTerminal]
    /// </summary>
    public partial interface IAHolotapeData :
        IAHolotapeDataGetter,
        IFormLinkContainer,
        ILoquiObjectSetter<IAHolotapeData>
    {
    }

    /// <summary>
    /// Implemented by: [HolotapeSound, HolotapeVoice, HolotapeProgram, HolotapeTerminal]
    /// </summary>
    public partial interface IAHolotapeDataGetter :
        ILoquiObject,
        IBinaryItem,
        IFormLinkContainerGetter,
        ILoquiObject<IAHolotapeDataGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration StaticRegistration => AHolotapeData_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class AHolotapeDataMixIn
    {
        public static void Clear(this IAHolotapeData item)
        {
            ((AHolotapeDataSetterCommon)((IAHolotapeDataGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static AHolotapeData.Mask<bool> GetEqualsMask(
            this IAHolotapeDataGetter item,
            IAHolotapeDataGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this IAHolotapeDataGetter item,
            string? name = null,
            AHolotapeData.Mask<bool>? printMask = null)
        {
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this IAHolotapeDataGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            AHolotapeData.Mask<bool>? printMask = null)
        {
            ((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IAHolotapeDataGetter item,
            IAHolotapeDataGetter rhs,
            AHolotapeData.TranslationMask? equalsMask = null)
        {
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                equalsMask: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IAHolotapeData lhs,
            IAHolotapeDataGetter rhs)
        {
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IAHolotapeData lhs,
            IAHolotapeDataGetter rhs,
            AHolotapeData.TranslationMask? copyMask = null)
        {
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IAHolotapeData lhs,
            IAHolotapeDataGetter rhs,
            out AHolotapeData.ErrorMask errorMask,
            AHolotapeData.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = AHolotapeData.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IAHolotapeData lhs,
            IAHolotapeDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static AHolotapeData DeepCopy(
            this IAHolotapeDataGetter item,
            AHolotapeData.TranslationMask? copyMask = null)
        {
            return ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static AHolotapeData DeepCopy(
            this IAHolotapeDataGetter item,
            out AHolotapeData.ErrorMask errorMask,
            AHolotapeData.TranslationMask? copyMask = null)
        {
            return ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static AHolotapeData DeepCopy(
            this IAHolotapeDataGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IAHolotapeData item,
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            ((AHolotapeDataSetterCommon)((IAHolotapeDataGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Fallout4
{
    #region Field Index
    internal enum AHolotapeData_FieldIndex
    {
    }
    #endregion

    #region Registration
    internal partial class AHolotapeData_Registration : ILoquiRegistration
    {
        public static readonly AHolotapeData_Registration Instance = new AHolotapeData_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 0;

        public static readonly Type MaskType = typeof(AHolotapeData.Mask<>);

        public static readonly Type ErrorMaskType = typeof(AHolotapeData.ErrorMask);

        public static readonly Type ClassType = typeof(AHolotapeData);

        public static readonly Type GetterType = typeof(IAHolotapeDataGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IAHolotapeData);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.AHolotapeData";

        public const string Name = "AHolotapeData";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(AHolotapeDataBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
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
    internal partial class AHolotapeDataSetterCommon
    {
        public static readonly AHolotapeDataSetterCommon Instance = new AHolotapeDataSetterCommon();

        partial void ClearPartial();
        
        public virtual void Clear(IAHolotapeData item)
        {
            ClearPartial();
        }
        
        #region Mutagen
        public void RemapLinks(IAHolotapeData obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IAHolotapeData item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
        }
        
        #endregion
        
    }
    internal partial class AHolotapeDataCommon
    {
        public static readonly AHolotapeDataCommon Instance = new AHolotapeDataCommon();

        public AHolotapeData.Mask<bool> GetEqualsMask(
            IAHolotapeDataGetter item,
            IAHolotapeDataGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new AHolotapeData.Mask<bool>(false);
            ((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IAHolotapeDataGetter item,
            IAHolotapeDataGetter rhs,
            AHolotapeData.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
        }
        
        public string Print(
            IAHolotapeDataGetter item,
            string? name = null,
            AHolotapeData.Mask<bool>? printMask = null)
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
            IAHolotapeDataGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            AHolotapeData.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"AHolotapeData =>");
            }
            else
            {
                sb.AppendLine($"{name} (AHolotapeData) =>");
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
            IAHolotapeDataGetter item,
            StructuredStringBuilder sb,
            AHolotapeData.Mask<bool>? printMask = null)
        {
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IAHolotapeDataGetter? lhs,
            IAHolotapeDataGetter? rhs,
            TranslationCrystal? equalsMask)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            return true;
        }
        
        public virtual int GetHashCode(IAHolotapeDataGetter item)
        {
            var hash = new HashCode();
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public virtual object GetNew()
        {
            return AHolotapeData.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(IAHolotapeDataGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    internal partial class AHolotapeDataSetterTranslationCommon
    {
        public static readonly AHolotapeDataSetterTranslationCommon Instance = new AHolotapeDataSetterTranslationCommon();

        #region DeepCopyIn
        public virtual void DeepCopyIn(
            IAHolotapeData item,
            IAHolotapeDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            DeepCopyInCustom(
                item: item,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        partial void DeepCopyInCustom(
            IAHolotapeData item,
            IAHolotapeDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy);
        #endregion
        
        public AHolotapeData DeepCopy(
            IAHolotapeDataGetter item,
            AHolotapeData.TranslationMask? copyMask = null)
        {
            AHolotapeData ret = (AHolotapeData)((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).GetNew();
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public AHolotapeData DeepCopy(
            IAHolotapeDataGetter item,
            out AHolotapeData.ErrorMask errorMask,
            AHolotapeData.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            AHolotapeData ret = (AHolotapeData)((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).GetNew();
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = AHolotapeData.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public AHolotapeData DeepCopy(
            IAHolotapeDataGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            AHolotapeData ret = (AHolotapeData)((AHolotapeDataCommon)((IAHolotapeDataGetter)item).CommonInstance()!).GetNew();
            ((AHolotapeDataSetterTranslationCommon)((IAHolotapeDataGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Fallout4
{
    public partial class AHolotapeData
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => AHolotapeData_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => AHolotapeData_Registration.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonInstance() => AHolotapeDataCommon.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonSetterInstance()
        {
            return AHolotapeDataSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected virtual object CommonSetterTranslationInstance() => AHolotapeDataSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IAHolotapeDataGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IAHolotapeDataGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IAHolotapeDataGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4
{
    public partial class AHolotapeDataBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public static readonly AHolotapeDataBinaryWriteTranslation Instance = new();

        public virtual void Write(
            MutagenWriter writer,
            IAHolotapeDataGetter item,
            TypedWriteParams translationParams)
        {
        }

        public virtual void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams translationParams = default)
        {
            Write(
                item: (IAHolotapeDataGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class AHolotapeDataBinaryCreateTranslation
    {
        public static readonly AHolotapeDataBinaryCreateTranslation Instance = new AHolotapeDataBinaryCreateTranslation();

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class AHolotapeDataBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this IAHolotapeDataGetter item,
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((AHolotapeDataBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                translationParams: translationParams);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4
{
    internal abstract partial class AHolotapeDataBinaryOverlay :
        PluginBinaryOverlay,
        IAHolotapeDataGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => AHolotapeData_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => AHolotapeData_Registration.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonInstance() => AHolotapeDataCommon.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonSetterTranslationInstance() => AHolotapeDataSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IAHolotapeDataGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? IAHolotapeDataGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object IAHolotapeDataGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        public virtual IEnumerable<IFormLinkGetter> EnumerateFormLinks() => AHolotapeDataCommon.Instance.EnumerateFormLinks(this);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual object BinaryWriteTranslator => AHolotapeDataBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((AHolotapeDataBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected AHolotapeDataBinaryOverlay(
            MemoryPair memoryPair,
            BinaryOverlayFactoryPackage package)
            : base(
                memoryPair: memoryPair,
                package: package)
        {
            this.CustomCtor();
        }


        #region To String

        public virtual void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            AHolotapeDataMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IAHolotapeDataGetter rhs) return false;
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)this).CommonInstance()!).Equals(this, rhs, equalsMask: null);
        }

        public bool Equals(IAHolotapeDataGetter? obj)
        {
            return ((AHolotapeDataCommon)((IAHolotapeDataGetter)this).CommonInstance()!).Equals(this, obj, equalsMask: null);
        }

        public override int GetHashCode() => ((AHolotapeDataCommon)((IAHolotapeDataGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

