/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loqui;
using Noggog;
using Noggog.Notifying;
using Mutagen.Bethesda.Tests.Internals;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Loqui.Xml;
using System.Diagnostics;

namespace Mutagen.Bethesda.Tests
{
    #region Class
    public partial class Move : IMove, ILoquiObjectSetter, IEquatable<Move>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => Move_Registration.Instance;
        public static Move_Registration Registration => Move_Registration.Instance;

        #region Ctor
        public Move()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region SectionToMove
        public RangeInt64 SectionToMove { get; set; }
        #endregion
        #region LocationToMove
        public Int64 LocationToMove { get; set; }
        #endregion

        #region Loqui Getter Interface

        protected object GetNthObject(ushort index) => MoveCommon.GetNthObject(index, this);
        object ILoquiObjectGetter.GetNthObject(ushort index) => this.GetNthObject(index);

        protected bool GetNthObjectHasBeenSet(ushort index) => MoveCommon.GetNthObjectHasBeenSet(index, this);
        bool ILoquiObjectGetter.GetNthObjectHasBeenSet(ushort index) => this.GetNthObjectHasBeenSet(index);

        protected void UnsetNthObject(ushort index, NotifyingUnsetParameters cmds) => MoveCommon.UnsetNthObject(index, this, cmds);
        void ILoquiObjectSetter.UnsetNthObject(ushort index, NotifyingUnsetParameters cmds) => this.UnsetNthObject(index, cmds);

        #endregion

        #region Loqui Interface
        protected void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            MoveCommon.SetNthObjectHasBeenSet(index, on, this);
        }
        void ILoquiObjectSetter.SetNthObjectHasBeenSet(ushort index, bool on) => this.SetNthObjectHasBeenSet(index, on);

        #endregion

        #region To String
        public override string ToString()
        {
            return MoveCommon.ToString(this, printMask: null);
        }

        public string ToString(
            string name = null,
            Move_Mask<bool> printMask = null)
        {
            return MoveCommon.ToString(this, name: name, printMask: printMask);
        }

        public void ToString(
            FileGeneration fg,
            string name = null)
        {
            MoveCommon.ToString(this, fg, name: name, printMask: null);
        }

        #endregion

        public Move_Mask<bool> GetHasBeenSetMask()
        {
            return MoveCommon.GetHasBeenSetMask(this);
        }
        #region Equals and Hash
        public override bool Equals(object obj)
        {
            if (!(obj is Move rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(Move rhs)
        {
            if (rhs == null) return false;
            if (SectionToMove != rhs.SectionToMove) return false;
            if (LocationToMove != rhs.LocationToMove) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            ret = HashHelper.GetHashCode(SectionToMove).CombineHashCode(ret);
            ret = HashHelper.GetHashCode(LocationToMove).CombineHashCode(ret);
            return ret;
        }

        #endregion


        #region XML Translation
        #region XML Create
        [DebuggerStepThrough]
        public static Move Create_XML(XElement root)
        {
            return Create_XML(
                root: root,
                doMasks: false,
                errorMask: out var errorMask);
        }

        [DebuggerStepThrough]
        public static Move Create_XML(
            XElement root,
            out Move_ErrorMask errorMask)
        {
            return Create_XML(
                root: root,
                doMasks: true,
                errorMask: out errorMask);
        }

        [DebuggerStepThrough]
        public static Move Create_XML(
            XElement root,
            bool doMasks,
            out Move_ErrorMask errorMask)
        {
            var ret = Create_XML(
                root: root,
                doMasks: doMasks);
            errorMask = ret.ErrorMask;
            return ret.Object;
        }

        [DebuggerStepThrough]
        public static (Move Object, Move_ErrorMask ErrorMask) Create_XML(
            XElement root,
            bool doMasks)
        {
            Move_ErrorMask errMaskRet = null;
            var ret = Create_XML_Internal(
                root: root,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new Move_ErrorMask()) : default(Func<Move_ErrorMask>));
            return (ret, errMaskRet);
        }

        public static Move Create_XML(string path)
        {
            var root = XDocument.Load(path).Root;
            return Create_XML(root: root);
        }

        public static Move Create_XML(
            string path,
            out Move_ErrorMask errorMask)
        {
            var root = XDocument.Load(path).Root;
            return Create_XML(
                root: root,
                errorMask: out errorMask);
        }

        public static Move Create_XML(Stream stream)
        {
            var root = XDocument.Load(stream).Root;
            return Create_XML(root: root);
        }

        public static Move Create_XML(
            Stream stream,
            out Move_ErrorMask errorMask)
        {
            var root = XDocument.Load(stream).Root;
            return Create_XML(
                root: root,
                errorMask: out errorMask);
        }

        #endregion

        #region XML Write
        public virtual void Write_XML(
            XmlWriter writer,
            out Move_ErrorMask errorMask,
            string name = null)
        {
            errorMask = (Move_ErrorMask)this.Write_XML_Internal(
                writer: writer,
                name: name,
                doMasks: true);
        }

        public virtual void Write_XML(
            string path,
            out Move_ErrorMask errorMask,
            string name = null)
        {
            using (var writer = new XmlTextWriter(path, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: name,
                    errorMask: out errorMask);
            }
        }

        public virtual void Write_XML(
            Stream stream,
            out Move_ErrorMask errorMask,
            string name = null)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: name,
                    errorMask: out errorMask);
            }
        }

        public void Write_XML(
            XmlWriter writer,
            string name = null)
        {
            this.Write_XML_Internal(
                writer: writer,
                name: name,
                doMasks: false);
        }

        public void Write_XML(
            string path,
            string name = null)
        {
            using (var writer = new XmlTextWriter(path, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: name);
            }
        }

        public void Write_XML(
            Stream stream,
            string name = null)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: name);
            }
        }

        protected object Write_XML_Internal(
            XmlWriter writer,
            bool doMasks,
            string name = null)
        {
            MoveCommon.Write_XML(
                item: this,
                doMasks: doMasks,
                writer: writer,
                name: name,
                errorMask: out var errorMask);
            return errorMask;
        }
        #endregion

        private static Move Create_XML_Internal(
            XElement root,
            Func<Move_ErrorMask> errorMask)
        {
            var ret = new Move();
            try
            {
                foreach (var elem in root.Elements())
                {
                    Fill_XML_Internal(
                        item: ret,
                        root: elem,
                        name: elem.Name.LocalName,
                        errorMask: errorMask);
                }
            }
            catch (Exception ex)
            when (errorMask != null)
            {
                errorMask().Overall = ex;
            }
            return ret;
        }

        protected static void Fill_XML_Internal(
            Move item,
            XElement root,
            string name,
            Func<Move_ErrorMask> errorMask)
        {
            switch (name)
            {
                case "SectionToMove":
                    item.SectionToMove = RangeInt64XmlTranslation.Instance.ParseNonNull(
                        root,
                        fieldIndex: (int)Move_FieldIndex.SectionToMove,
                        errorMask: errorMask).GetOrDefault(item.SectionToMove);
                    break;
                case "LocationToMove":
                    item.LocationToMove = Int64XmlTranslation.Instance.ParseNonNull(
                        root,
                        fieldIndex: (int)Move_FieldIndex.LocationToMove,
                        errorMask: errorMask).GetOrDefault(item.LocationToMove);
                    break;
                default:
                    break;
            }
        }

        #endregion

        public Move Copy(
            Move_CopyMask copyMask = null,
            IMoveGetter def = null)
        {
            return Move.Copy(
                this,
                copyMask: copyMask,
                def: def);
        }

        public static Move Copy(
            IMove item,
            Move_CopyMask copyMask = null,
            IMoveGetter def = null)
        {
            Move ret;
            if (item.GetType().Equals(typeof(Move)))
            {
                ret = new Move();
            }
            else
            {
                ret = (Move)System.Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        public static CopyType CopyGeneric<CopyType>(
            CopyType item,
            Move_CopyMask copyMask = null,
            IMoveGetter def = null)
            where CopyType : class, IMove
        {
            CopyType ret;
            if (item.GetType().Equals(typeof(Move)))
            {
                ret = new Move() as CopyType;
            }
            else
            {
                ret = (CopyType)System.Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                doMasks: false,
                errorMask: null,
                cmds: null,
                def: def);
            return ret;
        }

        public static Move Copy_ToLoqui(
            IMoveGetter item,
            Move_CopyMask copyMask = null,
            IMoveGetter def = null)
        {
            Move ret;
            if (item.GetType().Equals(typeof(Move)))
            {
                ret = new Move() as Move;
            }
            else
            {
                ret = (Move)System.Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        void ILoquiObjectSetter.SetNthObject(ushort index, object obj, NotifyingFireParameters cmds) => this.SetNthObject(index, obj, cmds);
        protected void SetNthObject(ushort index, object obj, NotifyingFireParameters cmds = null)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    this.SectionToMove = (RangeInt64)obj;
                    break;
                case Move_FieldIndex.LocationToMove:
                    this.LocationToMove = (Int64)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        partial void ClearPartial(NotifyingUnsetParameters cmds);

        protected void CallClearPartial_Internal(NotifyingUnsetParameters cmds)
        {
            ClearPartial(cmds);
        }

        public void Clear(NotifyingUnsetParameters cmds = null)
        {
            CallClearPartial_Internal(cmds);
            MoveCommon.Clear(this, cmds);
        }


        public static Move Create(IEnumerable<KeyValuePair<ushort, object>> fields)
        {
            var ret = new Move();
            foreach (var pair in fields)
            {
                CopyInInternal_Move(ret, pair);
            }
            return ret;
        }

        protected static void CopyInInternal_Move(Move obj, KeyValuePair<ushort, object> pair)
        {
            if (!EnumExt.TryParse(pair.Key, out Move_FieldIndex enu))
            {
                throw new ArgumentException($"Unknown index: {pair.Key}");
            }
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    obj.SectionToMove = (RangeInt64)pair.Value;
                    break;
                case Move_FieldIndex.LocationToMove:
                    obj.LocationToMove = (Int64)pair.Value;
                    break;
                default:
                    throw new ArgumentException($"Unknown enum type: {enu}");
            }
        }
        public static void CopyIn(IEnumerable<KeyValuePair<ushort, object>> fields, Move obj)
        {
            ILoquiObjectExt.CopyFieldsIn(obj, fields, def: null, skipProtected: false, cmds: null);
        }

    }
    #endregion

    #region Interface
    public interface IMove : IMoveGetter, ILoquiClass<IMove, IMoveGetter>, ILoquiClass<Move, IMoveGetter>
    {
        new RangeInt64 SectionToMove { get; set; }

        new Int64 LocationToMove { get; set; }

    }

    public interface IMoveGetter : ILoquiObject
    {
        #region SectionToMove
        RangeInt64 SectionToMove { get; }

        #endregion
        #region LocationToMove
        Int64 LocationToMove { get; }

        #endregion

    }

    #endregion

}

namespace Mutagen.Bethesda.Tests.Internals
{
    #region Field Index
    public enum Move_FieldIndex
    {
        SectionToMove = 0,
        LocationToMove = 1,
    }
    #endregion

    #region Registration
    public class Move_Registration : ILoquiRegistration
    {
        public static readonly Move_Registration Instance = new Move_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Tests.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Tests.ProtocolKey,
            msgID: 2,
            version: 0);

        public const string GUID = "226328fc-e330-4693-9377-5d70b7a70342";

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(Move_Mask<>);

        public static readonly Type ErrorMaskType = typeof(Move_ErrorMask);

        public static readonly Type ClassType = typeof(Move);

        public static readonly Type GetterType = typeof(IMoveGetter);

        public static readonly Type SetterType = typeof(IMove);

        public static readonly Type CommonType = typeof(MoveCommon);

        public const string FullName = "Mutagen.Bethesda.Tests.Move";

        public const string Name = "Move";

        public const string Namespace = "Mutagen.Bethesda.Tests";

        public const byte GenericCount = 0;

        public static readonly Type GenericRegistrationType = null;

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                case "SECTIONTOMOVE":
                    return (ushort)Move_FieldIndex.SectionToMove;
                case "LOCATIONTOMOVE":
                    return (ushort)Move_FieldIndex.LocationToMove;
                default:
                    return null;
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsLoqui(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static string GetNthName(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    return "SectionToMove";
                case Move_FieldIndex.LocationToMove:
                    return "LocationToMove";
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsProtected(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static Type GetNthType(ushort index)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    return typeof(RangeInt64);
                case Move_FieldIndex.LocationToMove:
                    return typeof(Int64);
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        int ILoquiRegistration.FieldCount => FieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type ILoquiRegistration.CommonType => CommonType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => GetNameIndex(name);
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => GetNthIsEnumerable(index);
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => GetNthIsLoqui(index);
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => GetNthIsSingleton(index);
        string ILoquiRegistration.GetNthName(ushort index) => GetNthName(index);
        bool ILoquiRegistration.IsNthDerivative(ushort index) => IsNthDerivative(index);
        bool ILoquiRegistration.IsProtected(ushort index) => IsProtected(index);
        Type ILoquiRegistration.GetNthType(ushort index) => GetNthType(index);
        #endregion

    }
    #endregion

    #region Extensions
    public static partial class MoveCommon
    {
        #region Copy Fields From
        public static void CopyFieldsFrom(
            this IMove item,
            IMoveGetter rhs,
            Move_CopyMask copyMask = null,
            IMoveGetter def = null,
            NotifyingFireParameters cmds = null)
        {
            MoveCommon.CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doMasks: false,
                errorMask: null,
                copyMask: copyMask,
                cmds: cmds);
        }

        public static void CopyFieldsFrom(
            this IMove item,
            IMoveGetter rhs,
            out Move_ErrorMask errorMask,
            Move_CopyMask copyMask = null,
            IMoveGetter def = null,
            NotifyingFireParameters cmds = null)
        {
            MoveCommon.CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doMasks: true,
                errorMask: out errorMask,
                copyMask: copyMask,
                cmds: cmds);
        }

        public static void CopyFieldsFrom(
            this IMove item,
            IMoveGetter rhs,
            IMoveGetter def,
            bool doMasks,
            out Move_ErrorMask errorMask,
            Move_CopyMask copyMask,
            NotifyingFireParameters cmds = null)
        {
            Move_ErrorMask retErrorMask = null;
            Func<Move_ErrorMask> maskGetter = () =>
            {
                if (retErrorMask == null)
                {
                    retErrorMask = new Move_ErrorMask();
                }
                return retErrorMask;
            };
            CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doMasks: true,
                errorMask: maskGetter,
                copyMask: copyMask,
                cmds: cmds);
            errorMask = retErrorMask;
        }

        public static void CopyFieldsFrom(
            this IMove item,
            IMoveGetter rhs,
            IMoveGetter def,
            bool doMasks,
            Func<Move_ErrorMask> errorMask,
            Move_CopyMask copyMask,
            NotifyingFireParameters cmds = null)
        {
            if (copyMask?.SectionToMove ?? true)
            {
                item.SectionToMove = rhs.SectionToMove;
            }
            if (copyMask?.LocationToMove ?? true)
            {
                item.LocationToMove = rhs.LocationToMove;
            }
        }

        #endregion

        public static void SetNthObjectHasBeenSet(
            ushort index,
            bool on,
            IMove obj,
            NotifyingFireParameters cmds = null)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    if (on) break;
                    throw new ArgumentException("Tried to unset a field which does not have this functionality." + index);
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void UnsetNthObject(
            ushort index,
            IMove obj,
            NotifyingUnsetParameters cmds = null)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    obj.SectionToMove = default(RangeInt64);
                    break;
                case Move_FieldIndex.LocationToMove:
                    obj.LocationToMove = default(Int64);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(
            ushort index,
            IMove obj)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                case Move_FieldIndex.LocationToMove:
                    return true;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static object GetNthObject(
            ushort index,
            IMoveGetter obj)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    return obj.SectionToMove;
                case Move_FieldIndex.LocationToMove:
                    return obj.LocationToMove;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void Clear(
            IMove item,
            NotifyingUnsetParameters cmds = null)
        {
            item.SectionToMove = default(RangeInt64);
            item.LocationToMove = default(Int64);
        }

        public static Move_Mask<bool> GetEqualsMask(
            this IMoveGetter item,
            IMoveGetter rhs)
        {
            var ret = new Move_Mask<bool>();
            FillEqualsMask(item, rhs, ret);
            return ret;
        }

        public static void FillEqualsMask(
            IMoveGetter item,
            IMoveGetter rhs,
            Move_Mask<bool> ret)
        {
            if (rhs == null) return;
            ret.SectionToMove = item.SectionToMove == rhs.SectionToMove;
            ret.LocationToMove = item.LocationToMove == rhs.LocationToMove;
        }

        public static string ToString(
            this IMoveGetter item,
            string name = null,
            Move_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            item.ToString(fg, name, printMask);
            return fg.ToString();
        }

        public static void ToString(
            this IMoveGetter item,
            FileGeneration fg,
            string name = null,
            Move_Mask<bool> printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"{nameof(Move)} =>");
            }
            else
            {
                fg.AppendLine($"{name} ({nameof(Move)}) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (printMask?.SectionToMove ?? true)
                {
                    fg.AppendLine($"SectionToMove => {item.SectionToMove}");
                }
                if (printMask?.LocationToMove ?? true)
                {
                    fg.AppendLine($"LocationToMove => {item.LocationToMove}");
                }
            }
            fg.AppendLine("]");
        }

        public static bool HasBeenSet(
            this IMoveGetter item,
            Move_Mask<bool?> checkMask)
        {
            return true;
        }

        public static Move_Mask<bool> GetHasBeenSetMask(IMoveGetter item)
        {
            var ret = new Move_Mask<bool>();
            ret.SectionToMove = true;
            ret.LocationToMove = true;
            return ret;
        }

        #region XML Translation
        #region XML Write
        public static void Write_XML(
            XmlWriter writer,
            IMoveGetter item,
            bool doMasks,
            out Move_ErrorMask errorMask,
            string name = null)
        {
            Move_ErrorMask errMaskRet = null;
            Write_XML_Internal(
                writer: writer,
                name: name,
                item: item,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new Move_ErrorMask()) : default(Func<Move_ErrorMask>));
            errorMask = errMaskRet;
        }

        private static void Write_XML_Internal(
            XmlWriter writer,
            IMoveGetter item,
            Func<Move_ErrorMask> errorMask,
            string name = null)
        {
            try
            {
                using (new ElementWrapper(writer, name ?? "Mutagen.Bethesda.Tests.Move"))
                {
                    if (name != null)
                    {
                        writer.WriteAttributeString("type", "Mutagen.Bethesda.Tests.Move");
                    }
                    RangeInt64XmlTranslation.Instance.Write(
                        writer: writer,
                        name: nameof(item.SectionToMove),
                        item: item.SectionToMove,
                        fieldIndex: (int)Move_FieldIndex.SectionToMove,
                        errorMask: errorMask);
                    Int64XmlTranslation.Instance.Write(
                        writer: writer,
                        name: nameof(item.LocationToMove),
                        item: item.LocationToMove,
                        fieldIndex: (int)Move_FieldIndex.LocationToMove,
                        errorMask: errorMask);
                }
            }
            catch (Exception ex)
            when (errorMask != null)
            {
                errorMask().Overall = ex;
            }
        }
        #endregion

        #endregion

    }
    #endregion

    #region Modules

    #region Mask
    public class Move_Mask<T> : IMask<T>, IEquatable<Move_Mask<T>>
    {
        #region Ctors
        public Move_Mask()
        {
        }

        public Move_Mask(T initialValue)
        {
            this.SectionToMove = initialValue;
            this.LocationToMove = initialValue;
        }
        #endregion

        #region Members
        public T SectionToMove;
        public T LocationToMove;
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (!(obj is Move_Mask<T> rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(Move_Mask<T> rhs)
        {
            if (rhs == null) return false;
            if (!object.Equals(this.SectionToMove, rhs.SectionToMove)) return false;
            if (!object.Equals(this.LocationToMove, rhs.LocationToMove)) return false;
            return true;
        }
        public override int GetHashCode()
        {
            int ret = 0;
            ret = ret.CombineHashCode(this.SectionToMove?.GetHashCode());
            ret = ret.CombineHashCode(this.LocationToMove?.GetHashCode());
            return ret;
        }

        #endregion

        #region All Equal
        public bool AllEqual(Func<T, bool> eval)
        {
            if (!eval(this.SectionToMove)) return false;
            if (!eval(this.LocationToMove)) return false;
            return true;
        }
        #endregion

        #region Translate
        public Move_Mask<R> Translate<R>(Func<T, R> eval)
        {
            var ret = new Move_Mask<R>();
            this.Translate_InternalFill(ret, eval);
            return ret;
        }

        protected void Translate_InternalFill<R>(Move_Mask<R> obj, Func<T, R> eval)
        {
            obj.SectionToMove = eval(this.SectionToMove);
            obj.LocationToMove = eval(this.LocationToMove);
        }
        #endregion

        #region Clear Enumerables
        public void ClearEnumerables()
        {
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return ToString(printMask: null);
        }

        public string ToString(Move_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            ToString(fg, printMask);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg, Move_Mask<bool> printMask = null)
        {
            fg.AppendLine($"{nameof(Move_Mask<T>)} =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (printMask?.SectionToMove ?? true)
                {
                    fg.AppendLine($"SectionToMove => {SectionToMove}");
                }
                if (printMask?.LocationToMove ?? true)
                {
                    fg.AppendLine($"LocationToMove => {LocationToMove}");
                }
            }
            fg.AppendLine("]");
        }
        #endregion

    }

    public class Move_ErrorMask : IErrorMask, IErrorMask<Move_ErrorMask>
    {
        #region Members
        public Exception Overall { get; set; }
        private List<string> _warnings;
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
        public Exception SectionToMove;
        public Exception LocationToMove;
        #endregion

        #region IErrorMask
        public void SetNthException(int index, Exception ex)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    this.SectionToMove = ex;
                    break;
                case Move_FieldIndex.LocationToMove:
                    this.LocationToMove = ex;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void SetNthMask(int index, object obj)
        {
            Move_FieldIndex enu = (Move_FieldIndex)index;
            switch (enu)
            {
                case Move_FieldIndex.SectionToMove:
                    this.SectionToMove = (Exception)obj;
                    break;
                case Move_FieldIndex.LocationToMove:
                    this.LocationToMove = (Exception)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public bool IsInError()
        {
            if (Overall != null) return true;
            if (SectionToMove != null) return true;
            if (LocationToMove != null) return true;
            return false;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            var fg = new FileGeneration();
            ToString(fg);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg)
        {
            fg.AppendLine("Move_ErrorMask =>");
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
            fg.AppendLine($"SectionToMove => {SectionToMove}");
            fg.AppendLine($"LocationToMove => {LocationToMove}");
        }
        #endregion

        #region Combine
        public Move_ErrorMask Combine(Move_ErrorMask rhs)
        {
            var ret = new Move_ErrorMask();
            ret.SectionToMove = this.SectionToMove.Combine(rhs.SectionToMove);
            ret.LocationToMove = this.LocationToMove.Combine(rhs.LocationToMove);
            return ret;
        }
        public static Move_ErrorMask Combine(Move_ErrorMask lhs, Move_ErrorMask rhs)
        {
            if (lhs != null && rhs != null) return lhs.Combine(rhs);
            return lhs ?? rhs;
        }
        #endregion

    }
    public class Move_CopyMask
    {
        #region Members
        public bool SectionToMove;
        public bool LocationToMove;
        #endregion

    }
    #endregion


    #endregion

}
