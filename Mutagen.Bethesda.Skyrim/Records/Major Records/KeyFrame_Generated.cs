/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Records.Binary.Overlay;
using Mutagen.Bethesda.Skyrim.Internals;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Skyrim
{
    #region Class
    public partial class KeyFrame :
        IEquatable<IKeyFrameGetter>,
        IKeyFrame,
        ILoquiObjectSetter<KeyFrame>
    {
        #region Ctor
        public KeyFrame()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Time
        public Single Time { get; set; } = default;
        #endregion
        #region Value
        public Single Value { get; set; } = default;
        #endregion

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            KeyFrameMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IKeyFrameGetter rhs) return false;
            return ((KeyFrameCommon)((IKeyFrameGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IKeyFrameGetter? obj)
        {
            return ((KeyFrameCommon)((IKeyFrameGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((KeyFrameCommon)((IKeyFrameGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            {
                this.Time = initialValue;
                this.Value = initialValue;
            }

            public Mask(
                TItem Time,
                TItem Value)
            {
                this.Time = Time;
                this.Value = Value;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Time;
            public TItem Value;
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
                if (!object.Equals(this.Time, rhs.Time)) return false;
                if (!object.Equals(this.Value, rhs.Value)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Time);
                hash.Add(this.Value);
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public bool All(Func<TItem, bool> eval)
            {
                if (!eval(this.Time)) return false;
                if (!eval(this.Value)) return false;
                return true;
            }
            #endregion

            #region Any
            public bool Any(Func<TItem, bool> eval)
            {
                if (eval(this.Time)) return true;
                if (eval(this.Value)) return true;
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new KeyFrame.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                obj.Time = eval(this.Time);
                obj.Value = eval(this.Value);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(KeyFrame.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, KeyFrame.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(KeyFrame.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Time ?? true)
                    {
                        fg.AppendItem(Time, "Time");
                    }
                    if (printMask?.Value ?? true)
                    {
                        fg.AppendItem(Value, "Value");
                    }
                }
                fg.AppendLine("]");
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
            public Exception? Time;
            public Exception? Value;
            #endregion

            #region IErrorMask
            public object? GetNthMask(int index)
            {
                KeyFrame_FieldIndex enu = (KeyFrame_FieldIndex)index;
                switch (enu)
                {
                    case KeyFrame_FieldIndex.Time:
                        return Time;
                    case KeyFrame_FieldIndex.Value:
                        return Value;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthException(int index, Exception ex)
            {
                KeyFrame_FieldIndex enu = (KeyFrame_FieldIndex)index;
                switch (enu)
                {
                    case KeyFrame_FieldIndex.Time:
                        this.Time = ex;
                        break;
                    case KeyFrame_FieldIndex.Value:
                        this.Value = ex;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthMask(int index, object obj)
            {
                KeyFrame_FieldIndex enu = (KeyFrame_FieldIndex)index;
                switch (enu)
                {
                    case KeyFrame_FieldIndex.Time:
                        this.Time = (Exception?)obj;
                        break;
                    case KeyFrame_FieldIndex.Value:
                        this.Value = (Exception?)obj;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public bool IsInError()
            {
                if (Overall != null) return true;
                if (Time != null) return true;
                if (Value != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString()
            {
                var fg = new FileGeneration();
                ToString(fg, null);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, string? name = null)
            {
                fg.AppendLine($"{(name ?? "ErrorMask")} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (this.Overall != null)
                    {
                        fg.AppendLine("Overall =>");
                        fg.AppendLine("[");
                        using (new DepthWrapper(fg))
                        {
                            fg.AppendLine($"{this.Overall}");
                        }
                        fg.AppendLine("]");
                    }
                    ToString_FillInternal(fg);
                }
                fg.AppendLine("]");
            }
            protected void ToString_FillInternal(FileGeneration fg)
            {
                fg.AppendItem(Time, "Time");
                fg.AppendItem(Value, "Value");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Time = this.Time.Combine(rhs.Time);
                ret.Value = this.Value.Combine(rhs.Value);
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
            public bool Time;
            public bool Value;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
                this.Time = defaultOn;
                this.Value = defaultOn;
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

            protected void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                ret.Add((Time, null));
                ret.Add((Value, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => KeyFrameBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((KeyFrameBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public static KeyFrame CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new KeyFrame();
            ((KeyFrameSetterCommon)((IKeyFrameGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out KeyFrame item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(frame, recordTypeConverter);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((KeyFrameSetterCommon)((IKeyFrameGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static KeyFrame GetNew()
        {
            return new KeyFrame();
        }

    }
    #endregion

    #region Interface
    public partial interface IKeyFrame :
        IKeyFrameGetter,
        ILoquiObjectSetter<IKeyFrame>
    {
        new Single Time { get; set; }
        new Single Value { get; set; }
    }

    public partial interface IKeyFrameGetter :
        ILoquiObject,
        IBinaryItem,
        ILoquiObject<IKeyFrameGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration Registration => KeyFrame_Registration.Instance;
        Single Time { get; }
        Single Value { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class KeyFrameMixIn
    {
        public static void Clear(this IKeyFrame item)
        {
            ((KeyFrameSetterCommon)((IKeyFrameGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static KeyFrame.Mask<bool> GetEqualsMask(
            this IKeyFrameGetter item,
            IKeyFrameGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IKeyFrameGetter item,
            string? name = null,
            KeyFrame.Mask<bool>? printMask = null)
        {
            return ((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IKeyFrameGetter item,
            FileGeneration fg,
            string? name = null,
            KeyFrame.Mask<bool>? printMask = null)
        {
            ((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IKeyFrameGetter item,
            IKeyFrameGetter rhs,
            KeyFrame.TranslationMask? equalsMask = null)
        {
            return ((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IKeyFrame lhs,
            IKeyFrameGetter rhs)
        {
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IKeyFrame lhs,
            IKeyFrameGetter rhs,
            KeyFrame.TranslationMask? copyMask = null)
        {
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IKeyFrame lhs,
            IKeyFrameGetter rhs,
            out KeyFrame.ErrorMask errorMask,
            KeyFrame.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = KeyFrame.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IKeyFrame lhs,
            IKeyFrameGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static KeyFrame DeepCopy(
            this IKeyFrameGetter item,
            KeyFrame.TranslationMask? copyMask = null)
        {
            return ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static KeyFrame DeepCopy(
            this IKeyFrameGetter item,
            out KeyFrame.ErrorMask errorMask,
            KeyFrame.TranslationMask? copyMask = null)
        {
            return ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static KeyFrame DeepCopy(
            this IKeyFrameGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IKeyFrame item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((KeyFrameSetterCommon)((IKeyFrameGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim.Internals
{
    #region Field Index
    public enum KeyFrame_FieldIndex
    {
        Time = 0,
        Value = 1,
    }
    #endregion

    #region Registration
    public partial class KeyFrame_Registration : ILoquiRegistration
    {
        public static readonly KeyFrame_Registration Instance = new KeyFrame_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 410,
            version: 0);

        public const string GUID = "b58e26b4-d37e-404e-92a1-bc482dbf77a4";

        public const ushort AdditionalFieldCount = 2;

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(KeyFrame.Mask<>);

        public static readonly Type ErrorMaskType = typeof(KeyFrame.ErrorMask);

        public static readonly Type ClassType = typeof(KeyFrame);

        public static readonly Type GetterType = typeof(IKeyFrameGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IKeyFrame);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.KeyFrame";

        public const string Name = "KeyFrame";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(KeyFrameBinaryWriteTranslation);
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
    public partial class KeyFrameSetterCommon
    {
        public static readonly KeyFrameSetterCommon Instance = new KeyFrameSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IKeyFrame item)
        {
            ClearPartial();
            item.Time = default;
            item.Value = default;
        }
        
        #region Mutagen
        public void RemapLinks(IKeyFrame obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IKeyFrame item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: KeyFrameBinaryCreateTranslation.FillBinaryStructs);
        }
        
        #endregion
        
    }
    public partial class KeyFrameCommon
    {
        public static readonly KeyFrameCommon Instance = new KeyFrameCommon();

        public KeyFrame.Mask<bool> GetEqualsMask(
            IKeyFrameGetter item,
            IKeyFrameGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new KeyFrame.Mask<bool>(false);
            ((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IKeyFrameGetter item,
            IKeyFrameGetter rhs,
            KeyFrame.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Time = item.Time.EqualsWithin(rhs.Time);
            ret.Value = item.Value.EqualsWithin(rhs.Value);
        }
        
        public string ToString(
            IKeyFrameGetter item,
            string? name = null,
            KeyFrame.Mask<bool>? printMask = null)
        {
            var fg = new FileGeneration();
            ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
            return fg.ToString();
        }
        
        public void ToString(
            IKeyFrameGetter item,
            FileGeneration fg,
            string? name = null,
            KeyFrame.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"KeyFrame =>");
            }
            else
            {
                fg.AppendLine($"{name} (KeyFrame) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                ToStringFields(
                    item: item,
                    fg: fg,
                    printMask: printMask);
            }
            fg.AppendLine("]");
        }
        
        protected static void ToStringFields(
            IKeyFrameGetter item,
            FileGeneration fg,
            KeyFrame.Mask<bool>? printMask = null)
        {
            if (printMask?.Time ?? true)
            {
                fg.AppendItem(item.Time, "Time");
            }
            if (printMask?.Value ?? true)
            {
                fg.AppendItem(item.Value, "Value");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IKeyFrameGetter? lhs,
            IKeyFrameGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if ((crystal?.GetShouldTranslate((int)KeyFrame_FieldIndex.Time) ?? true))
            {
                if (!lhs.Time.EqualsWithin(rhs.Time)) return false;
            }
            if ((crystal?.GetShouldTranslate((int)KeyFrame_FieldIndex.Value) ?? true))
            {
                if (!lhs.Value.EqualsWithin(rhs.Value)) return false;
            }
            return true;
        }
        
        public virtual int GetHashCode(IKeyFrameGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Time);
            hash.Add(item.Value);
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public object GetNew()
        {
            return KeyFrame.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormLinkInformation> GetContainedFormLinks(IKeyFrameGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    public partial class KeyFrameSetterTranslationCommon
    {
        public static readonly KeyFrameSetterTranslationCommon Instance = new KeyFrameSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IKeyFrame item,
            IKeyFrameGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            if ((copyMask?.GetShouldTranslate((int)KeyFrame_FieldIndex.Time) ?? true))
            {
                item.Time = rhs.Time;
            }
            if ((copyMask?.GetShouldTranslate((int)KeyFrame_FieldIndex.Value) ?? true))
            {
                item.Value = rhs.Value;
            }
        }
        
        #endregion
        
        public KeyFrame DeepCopy(
            IKeyFrameGetter item,
            KeyFrame.TranslationMask? copyMask = null)
        {
            KeyFrame ret = (KeyFrame)((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).GetNew();
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public KeyFrame DeepCopy(
            IKeyFrameGetter item,
            out KeyFrame.ErrorMask errorMask,
            KeyFrame.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            KeyFrame ret = (KeyFrame)((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).GetNew();
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = KeyFrame.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public KeyFrame DeepCopy(
            IKeyFrameGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            KeyFrame ret = (KeyFrame)((KeyFrameCommon)((IKeyFrameGetter)item).CommonInstance()!).GetNew();
            ((KeyFrameSetterTranslationCommon)((IKeyFrameGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Skyrim
{
    public partial class KeyFrame
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => KeyFrame_Registration.Instance;
        public static KeyFrame_Registration Registration => KeyFrame_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => KeyFrameCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterInstance()
        {
            return KeyFrameSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => KeyFrameSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IKeyFrameGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IKeyFrameGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IKeyFrameGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class KeyFrameBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public readonly static KeyFrameBinaryWriteTranslation Instance = new KeyFrameBinaryWriteTranslation();

        public static void WriteEmbedded(
            IKeyFrameGetter item,
            MutagenWriter writer)
        {
            Mutagen.Bethesda.Binary.FloatBinaryTranslation.Instance.Write(
                writer: writer,
                item: item.Time);
            Mutagen.Bethesda.Binary.FloatBinaryTranslation.Instance.Write(
                writer: writer,
                item: item.Value);
        }

        public void Write(
            MutagenWriter writer,
            IKeyFrameGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
        }

        public void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IKeyFrameGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class KeyFrameBinaryCreateTranslation
    {
        public readonly static KeyFrameBinaryCreateTranslation Instance = new KeyFrameBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IKeyFrame item,
            MutagenFrame frame)
        {
            item.Time = Mutagen.Bethesda.Binary.FloatBinaryTranslation.Instance.Parse(frame: frame);
            item.Value = Mutagen.Bethesda.Binary.FloatBinaryTranslation.Instance.Parse(frame: frame);
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class KeyFrameBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this IKeyFrameGetter item,
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((KeyFrameBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class KeyFrameBinaryOverlay :
        BinaryOverlay,
        IKeyFrameGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => KeyFrame_Registration.Instance;
        public static KeyFrame_Registration Registration => KeyFrame_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => KeyFrameCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => KeyFrameSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IKeyFrameGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? IKeyFrameGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object IKeyFrameGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => KeyFrameBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((KeyFrameBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public Single Time => _data.Slice(0x0, 0x4).Float();
        public Single Value => _data.Slice(0x4, 0x4).Float();
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected KeyFrameBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static KeyFrameBinaryOverlay KeyFrameFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new KeyFrameBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x8),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x8;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static KeyFrameBinaryOverlay KeyFrameFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return KeyFrameFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            KeyFrameMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IKeyFrameGetter rhs) return false;
            return ((KeyFrameCommon)((IKeyFrameGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IKeyFrameGetter? obj)
        {
            return ((KeyFrameCommon)((IKeyFrameGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((KeyFrameCommon)((IKeyFrameGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

