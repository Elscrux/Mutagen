/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Fallout4.Internals;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Translations.Binary;
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
namespace Mutagen.Bethesda.Fallout4
{
    #region Class
    public partial class ScriptStruct :
        IEquatable<IScriptStructGetter>,
        ILoquiObjectSetter<ScriptStruct>,
        IScriptStruct
    {
        #region Ctor
        public ScriptStruct()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            ScriptStructMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IScriptStructGetter rhs) return false;
            return ((ScriptStructCommon)((IScriptStructGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IScriptStructGetter? obj)
        {
            return ((ScriptStructCommon)((IScriptStructGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((ScriptStructCommon)((IScriptStructGetter)this).CommonInstance()!).GetHashCode(this);

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
            public bool All(Func<TItem, bool> eval)
            {
                return true;
            }
            #endregion

            #region Any
            public bool Any(Func<TItem, bool> eval)
            {
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new ScriptStruct.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(ScriptStruct.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, ScriptStruct.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(ScriptStruct.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
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
            #endregion

            #region IErrorMask
            public object? GetNthMask(int index)
            {
                ScriptStruct_FieldIndex enu = (ScriptStruct_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthException(int index, Exception ex)
            {
                ScriptStruct_FieldIndex enu = (ScriptStruct_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthMask(int index, object obj)
            {
                ScriptStruct_FieldIndex enu = (ScriptStruct_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public bool IsInError()
            {
                if (Overall != null) return true;
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

            protected void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => ScriptStructBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((ScriptStructBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #region Binary Create
        public static ScriptStruct CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            var ret = new ScriptStruct();
            ((ScriptStructSetterCommon)((IScriptStructGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out ScriptStruct item,
            TypedParseParams? translationParams = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                translationParams: translationParams);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((ScriptStructSetterCommon)((IScriptStructGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static ScriptStruct GetNew()
        {
            return new ScriptStruct();
        }

    }
    #endregion

    #region Interface
    public partial interface IScriptStruct :
        ILoquiObjectSetter<IScriptStruct>,
        IScriptStructGetter
    {
    }

    public partial interface IScriptStructGetter :
        ILoquiObject,
        IBinaryItem,
        ILoquiObject<IScriptStructGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration StaticRegistration => ScriptStruct_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class ScriptStructMixIn
    {
        public static void Clear(this IScriptStruct item)
        {
            ((ScriptStructSetterCommon)((IScriptStructGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static ScriptStruct.Mask<bool> GetEqualsMask(
            this IScriptStructGetter item,
            IScriptStructGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IScriptStructGetter item,
            string? name = null,
            ScriptStruct.Mask<bool>? printMask = null)
        {
            return ((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IScriptStructGetter item,
            FileGeneration fg,
            string? name = null,
            ScriptStruct.Mask<bool>? printMask = null)
        {
            ((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IScriptStructGetter item,
            IScriptStructGetter rhs,
            ScriptStruct.TranslationMask? equalsMask = null)
        {
            return ((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IScriptStruct lhs,
            IScriptStructGetter rhs)
        {
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IScriptStruct lhs,
            IScriptStructGetter rhs,
            ScriptStruct.TranslationMask? copyMask = null)
        {
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IScriptStruct lhs,
            IScriptStructGetter rhs,
            out ScriptStruct.ErrorMask errorMask,
            ScriptStruct.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = ScriptStruct.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IScriptStruct lhs,
            IScriptStructGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static ScriptStruct DeepCopy(
            this IScriptStructGetter item,
            ScriptStruct.TranslationMask? copyMask = null)
        {
            return ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static ScriptStruct DeepCopy(
            this IScriptStructGetter item,
            out ScriptStruct.ErrorMask errorMask,
            ScriptStruct.TranslationMask? copyMask = null)
        {
            return ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static ScriptStruct DeepCopy(
            this IScriptStructGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IScriptStruct item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            ((ScriptStructSetterCommon)((IScriptStructGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Fallout4.Internals
{
    #region Field Index
    public enum ScriptStruct_FieldIndex
    {
    }
    #endregion

    #region Registration
    public partial class ScriptStruct_Registration : ILoquiRegistration
    {
        public static readonly ScriptStruct_Registration Instance = new ScriptStruct_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 208,
            version: 0);

        public const string GUID = "17c297d5-374d-4c20-8314-17304be8f76f";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 0;

        public static readonly Type MaskType = typeof(ScriptStruct.Mask<>);

        public static readonly Type ErrorMaskType = typeof(ScriptStruct.ErrorMask);

        public static readonly Type ClassType = typeof(ScriptStruct);

        public static readonly Type GetterType = typeof(IScriptStructGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IScriptStruct);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.ScriptStruct";

        public const string Name = "ScriptStruct";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(ScriptStructBinaryWriteTranslation);
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
    public partial class ScriptStructSetterCommon
    {
        public static readonly ScriptStructSetterCommon Instance = new ScriptStructSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IScriptStruct item)
        {
            ClearPartial();
        }
        
        #region Mutagen
        public void RemapLinks(IScriptStruct obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IScriptStruct item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillStructs: ScriptStructBinaryCreateTranslation.FillBinaryStructs);
        }
        
        #endregion
        
    }
    public partial class ScriptStructCommon
    {
        public static readonly ScriptStructCommon Instance = new ScriptStructCommon();

        public ScriptStruct.Mask<bool> GetEqualsMask(
            IScriptStructGetter item,
            IScriptStructGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new ScriptStruct.Mask<bool>(false);
            ((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IScriptStructGetter item,
            IScriptStructGetter rhs,
            ScriptStruct.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
        }
        
        public string ToString(
            IScriptStructGetter item,
            string? name = null,
            ScriptStruct.Mask<bool>? printMask = null)
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
            IScriptStructGetter item,
            FileGeneration fg,
            string? name = null,
            ScriptStruct.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"ScriptStruct =>");
            }
            else
            {
                fg.AppendLine($"{name} (ScriptStruct) =>");
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
            IScriptStructGetter item,
            FileGeneration fg,
            ScriptStruct.Mask<bool>? printMask = null)
        {
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IScriptStructGetter? lhs,
            IScriptStructGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            return true;
        }
        
        public virtual int GetHashCode(IScriptStructGetter item)
        {
            var hash = new HashCode();
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public object GetNew()
        {
            return ScriptStruct.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> GetContainedFormLinks(IScriptStructGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    public partial class ScriptStructSetterTranslationCommon
    {
        public static readonly ScriptStructSetterTranslationCommon Instance = new ScriptStructSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IScriptStruct item,
            IScriptStructGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
        }
        
        #endregion
        
        public ScriptStruct DeepCopy(
            IScriptStructGetter item,
            ScriptStruct.TranslationMask? copyMask = null)
        {
            ScriptStruct ret = (ScriptStruct)((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).GetNew();
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public ScriptStruct DeepCopy(
            IScriptStructGetter item,
            out ScriptStruct.ErrorMask errorMask,
            ScriptStruct.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ScriptStruct ret = (ScriptStruct)((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).GetNew();
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = ScriptStruct.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public ScriptStruct DeepCopy(
            IScriptStructGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            ScriptStruct ret = (ScriptStruct)((ScriptStructCommon)((IScriptStructGetter)item).CommonInstance()!).GetNew();
            ((ScriptStructSetterTranslationCommon)((IScriptStructGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class ScriptStruct
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => ScriptStruct_Registration.Instance;
        public static ScriptStruct_Registration StaticRegistration => ScriptStruct_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => ScriptStructCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterInstance()
        {
            return ScriptStructSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => ScriptStructSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IScriptStructGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IScriptStructGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IScriptStructGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class ScriptStructBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public readonly static ScriptStructBinaryWriteTranslation Instance = new ScriptStructBinaryWriteTranslation();

        public void Write(
            MutagenWriter writer,
            IScriptStructGetter item,
            TypedWriteParams? translationParams = null)
        {
        }

        public void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams? translationParams = null)
        {
            Write(
                item: (IScriptStructGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    public partial class ScriptStructBinaryCreateTranslation
    {
        public readonly static ScriptStructBinaryCreateTranslation Instance = new ScriptStructBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IScriptStruct item,
            MutagenFrame frame)
        {
        }

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class ScriptStructBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this IScriptStructGetter item,
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((ScriptStructBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                translationParams: translationParams);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class ScriptStructBinaryOverlay :
        PluginBinaryOverlay,
        IScriptStructGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => ScriptStruct_Registration.Instance;
        public static ScriptStruct_Registration StaticRegistration => ScriptStruct_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => ScriptStructCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => ScriptStructSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IScriptStructGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? IScriptStructGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object IScriptStructGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => ScriptStructBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((ScriptStructBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected ScriptStructBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static ScriptStructBinaryOverlay ScriptStructFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            TypedParseParams? parseParams = null)
        {
            var ret = new ScriptStructBinaryOverlay(
                bytes: stream.RemainingMemory,
                package: package);
            int offset = stream.Position;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static ScriptStructBinaryOverlay ScriptStructFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            TypedParseParams? parseParams = null)
        {
            return ScriptStructFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                parseParams: parseParams);
        }

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            ScriptStructMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IScriptStructGetter rhs) return false;
            return ((ScriptStructCommon)((IScriptStructGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IScriptStructGetter? obj)
        {
            return ((ScriptStructCommon)((IScriptStructGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((ScriptStructCommon)((IScriptStructGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

