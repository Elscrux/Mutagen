using Mutagen.Bethesda.Plugins.Order;
using Noggog;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Mutagen.Bethesda.Plugins.Masters;
using Mutagen.Bethesda.Plugins.Masters.DI;
using Mutagen.Bethesda.Plugins.Records;

namespace Mutagen.Bethesda.Plugins;

/// <summary>
/// A struct representing a unique identifier for a record:<br/>
///   - The ID of a record (6 bytes)<br/>
///   - The ModKey the record originates from<br/>
///<br/>
/// FormKeys are preferable to FormIDs, as they:<br/>
///   - Cannot be misinterpreted to originate from the wrong Mod depending on context<br/>
///   - Remove the 255 limit while within code space.  On-disk formats still enforce 255 limit.<br/>
/// </summary>
[DebuggerDisplay("{ToString()}")]
public readonly struct FormKey : IEquatable<FormKey>, IFormKeyGetter
{
    /// <summary>
    /// A static readonly singleton string representing a null FormKey
    /// </summary>
    public const string NullStr = "Null";
        
    /// <summary>
    /// A static readonly singleton Null FormKey (00000000)
    /// </summary>
    public static readonly FormKey Null = new FormKey(ModKey.Null, 0);
    
    /// <summary>
    /// A static readonly singleton string representing a none FormKey
    /// </summary>
    public const string NoneStr = "None";
        
    /// <summary>
    /// A static readonly singleton None FormKey (FFFFFFFF)
    /// </summary>
    public static readonly FormKey None = new FormKey(ModKey.Null, 0xFFFFFF);
        
    /// <summary>
    /// Record ID, with master indices set to zero.
    /// </summary>
    public readonly uint ID;
        
    /// <summary>
    /// ModKey the Record originates from
    /// </summary>
    public readonly ModKey ModKey;

    /// <summary>
    /// True if FormKey is considered Null
    /// </summary>
    public bool IsNull => ID == 0 || ModKey.IsNull;

    /// <summary>
    /// Constructor taking a ModKey and ID as separate parameters
    /// </summary>
    /// <param name="modKey">ModKey to use</param>
    /// <param name="id">Record ID to use.  Must be less than 0x00FFFFFF.</param>
    /// <exception cref="ArgumentException">ID needs to contain no data in upper two bytes, or it will throw.</exception>
    public FormKey(ModKey modKey, uint id)
    {
        ModKey = modKey;
        ID = id & 0xFFFFFF;
    }

    /// <summary>
    /// Constructs a FormKey from a list of masters and the raw uint
    /// </summary>
    /// <param name="masterReferences">Master reference list to refer to</param>
    /// <param name="idWithModID">Mod index and Record ID to use</param>
    /// <returns>Converted FormID</returns>
    internal static FormKey Factory(ISeparatedMasterPackage masterReferences, uint idWithModID)
    {
        return FormIDTranslator.GetFormKey(masterReferences, idWithModID);
    }

    /// <summary>
    /// Constructs a FormKey from a list of masters and the raw uint
    /// </summary>
    /// <param name="masterReferences">Master reference list to refer to</param>
    /// <param name="idWithModID">Mod index and Record ID to use</param>
    /// <param name="maxIsNull">Whether a maximum value should be considered null</param>
    /// <returns>Converted FormID</returns>
    internal static FormKey Factory(ISeparatedMasterPackage masterReferences, uint idWithModID, bool maxIsNull)
    {
        if (maxIsNull && idWithModID == uint.MaxValue)
        {
            return FormKey.None;
        }
        return Factory(masterReferences, idWithModID);
    }

    private static bool IsDelim(char c) => c is ':' or '_';

    /// <summary>
    /// Attempts to construct a FormKey from a string:
    ///   012ABC:ModName.esp
    /// </summary>
    /// <param name="str">String to parse</param>
    /// <param name="formKey">FormKey if successfully converted</param>
    /// <returns>True if conversion successful</returns>
    public static bool TryFactory(ReadOnlySpan<char> str, [MaybeNullWhen(false)]out FormKey formKey)
    {
        // Trim whitespace
        str = str.Trim();

        // If equal to Null
        if (NullStr.AsSpan().Equals(str, StringComparison.OrdinalIgnoreCase))
        {
            formKey = Null;
            return true;
        }

        // If equal to None
        if (NoneStr.AsSpan().Equals(str, StringComparison.OrdinalIgnoreCase))
        {
            formKey = None;
            return true;
        }

        // If less than Null:Null, is invalid
        const int shortCircuitSize = 9;
        if (str.Length < shortCircuitSize)
        {
            formKey = default!;
            return false;
        }

        uint id;
        int delim;
        if (IsDelim(str[4]) && str.Slice(0, 4).Equals(NullStr, StringComparison.OrdinalIgnoreCase))
        {
            delim = 4;
            id = 0;
        }
        else
        {
            // If delimeter not in place, invalid
            if (!IsDelim(str[6]))
            {
                formKey = default!;
                return false;
            }

            delim = 6;

            // Convert ID section
            if (!uint.TryParse(str.Slice(0, delim), NumberStyles.HexNumber, null, out id))
            {
                formKey = default!;
                return false;
            }
        }

        // Slice past delimiter
        str = str.Slice(delim + 1);

        if (!ModKey.TryFromNameAndExtension(str, out var modKey))
        {
            if (str.Equals(NullStr, StringComparison.OrdinalIgnoreCase))
            {
                modKey = ModKey.Null;
            }
            else
            {
                formKey = default!;
                return false;
            }
        }
            
        formKey = new FormKey(
            modKey: modKey,
            id: id);
        return true;
    }

    /// <summary>
    /// Attempts to construct a FormKey from a string:
    ///   012ABC:ModName.esp
    /// </summary>
    /// <param name="str">String to parse</param>
    /// <returns>FormKey if successfully converted, otherwise null</returns>
    public static FormKey? TryFactory(ReadOnlySpan<char> str)
    {
        if (TryFactory(str, out var formKey))
        {
            return formKey;
        }
        return default;
    }

    /// <summary>
    /// Constructs a FormKey from a string:
    ///   012ABC:ModName.esp
    /// </summary>
    /// <param name="str">String to parse</param>
    /// <returns>Converted FormKey</returns>
    /// <exception cref="ArgumentException">If string malformed</exception>
    public static FormKey Factory(ReadOnlySpan<char> str)
    {
        if (!TryFactory(str, out var form))
        {
            throw new ArgumentException($"Malformed FormKey string: {str.ToString()}");
        }
        return form;
    }

    /// <summary>
    /// Converts to a string: FFFFFF:MyMod.esp
    /// </summary>
    /// <returns>String representation of FormKey</returns>
    public override string ToString()
    {
        if (ID == 0 && ModKey.IsNull)
        {
            return NullStr;
        }

        if (None == this)
        {
            return NoneStr;
        }
        return $"{IDString()}:{ModKey}";
    }
         
    /// <summary>
    /// Converts to a hex string containing only the ID section: FFFFFF
    /// </summary>
    /// <returns>Hex string</returns>
    public string IDString()
    {
        return ID.ToString("X6");
    }

    /// <summary>
    /// Converts to a string that is safe for use in file paths
    /// </summary>
    /// <returns>a string that is safe for use in file paths</returns>
    public string ToFilesafeString()
    {
        if (ID == 0 && ModKey.IsNull)
        {
            return "Null";
        }
        return $"{(ID == 0 ? "Null" : IDString())}_{ModKey}";
    }

    /// <summary>
    /// Default equality operator
    /// </summary>
    /// <param name="other">object to compare to</param>
    /// <returns>True if FormKey with equal ModKey and ID values</returns>
    public override bool Equals(object? other)
    {
        if (other is not FormKey key) return false;
        return Equals(key);
    }

    /// <summary>
    /// FormKey equality operator
    /// </summary>
    /// <param name="other">FormKey to compare to</param>
    /// <returns>True if equal ModKey and ID values</returns>
    public bool Equals(FormKey other)
    {
        if (!ModKey.Equals(other.ModKey)) return false;
        if (ID != other.ID) return false;
        return true;
    }

    /// <summary>
    /// Hashcode retrieved from ModKey and ID values.
    /// </summary>
    /// <returns>Hashcode retrieved from ModKey and ID values.</returns>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(ModKey);
        hash.Add(ID);
        return hash.ToHashCode();
    }

    [Obsolete("Use ToLink instead")]
    public FormLink<TMajorGetter> AsLink<TMajorGetter>()
        where TMajorGetter : class, IMajorRecordGetter
    {
        return new FormLink<TMajorGetter>(this);
    }

    public FormLink<TMajorGetter> ToLink<TMajorGetter>()
        where TMajorGetter : class, IMajorRecordGetter
    {
        return new FormLink<TMajorGetter>(this);
    }

    [Obsolete("Use ToLinkGetter instead")]
    public IFormLinkGetter<TMajorGetter> AsLinkGetter<TMajorGetter>()
        where TMajorGetter : class, IMajorRecordGetter
    {
        return new FormLink<TMajorGetter>(this);
    }

    public IFormLinkGetter<TMajorGetter> ToLinkGetter<TMajorGetter>()
        where TMajorGetter : class, IMajorRecordGetter
    {
        return new FormLink<TMajorGetter>(this);
    }

    public static bool operator ==(FormKey? a, FormKey? b)
    {
        return EqualityComparer<FormKey?>.Default.Equals(a, b);
    }

    public static bool operator !=(FormKey? a, FormKey? b)
    {
        return !EqualityComparer<FormKey?>.Default.Equals(a, b);
    }

    #region Comparers
    /// <summary>
    /// Constructs a comparer that sorts FormKeys in alphabetical order, with an optional parameter to always sort masters first.
    /// </summary>
    /// <param name="mastersFirst">Whether to sort all masters first</param>
    /// <returns>Comparer to use</returns>
    public static Comparer<FormKey> AlphabeticalComparer(bool mastersFirst = true) => new AlphabeticalFormKeyComparer(mastersFirst);

    private class AlphabeticalFormKeyComparer : Comparer<FormKey>
    {
        private readonly bool _mastersFirst;

        public AlphabeticalFormKeyComparer(bool mastersFirst)
        {
            _mastersFirst = mastersFirst;
        }

        public override int Compare(FormKey x, FormKey y)
        {
            if (_mastersFirst
                && x.ModKey.Type != y.ModKey.Type)
            {
                return x.ModKey.Type.CompareTo(y.ModKey.Type);
            }

            var stringComp = string.Compare(x.ModKey.FileName, y.ModKey.FileName, StringComparison.OrdinalIgnoreCase);
            if (stringComp != 0) return stringComp;

            return x.ID.CompareTo(y.ID);
        }
    }

    /// <summary>
    /// Constructs a comparer that sorts FormKeys according to a load order.
    /// If FormKeys are from the same mod, then alphabetical sorting will be used, unless an override is specified.
    /// </summary>
    /// <param name="loadOrder">Load order to refer to for sorting</param>
    /// <param name="matchingModKeyFallback">Comparer to use when FormKeys from the same mod.  Alphabetical is default.</param>
    /// <param name="notOnLoadOrderFallback">Comparer to use when FormKeys not on the load order. Default is to throw an exception</param>
    /// <returns>Comparer to use</returns>
    /// <exception cref="ArgumentOutOfRangeException">A FormKey not on the load order is queried, and no fallback specified.</exception>
    public static Comparer<FormKey> LoadOrderComparer(
        IReadOnlyList<ModKey> loadOrder,
        Comparer<FormKey>? matchingModKeyFallback = null,
        Comparer<FormKey>? notOnLoadOrderFallback = null) =>
        new ModKeyListFormKeyComparer(loadOrder, matchingModKeyFallback: matchingModKeyFallback, notOnLoadOrderFallback: notOnLoadOrderFallback);

    /// <summary>
    /// Constructs a comparer that sorts FormKeys according to a load order.
    /// If FormKeys are from the same mod, then alphabetical sorting will be used, unless an override is specified.
    /// </summary>
    /// <param name="loadOrder">Load order to refer to for sorting</param>
    /// <param name="matchingModKeyFallback">Comparer to use when FormKeys from the same mod.  Alphabetical is default.</param>
    /// <param name="notOnLoadOrderFallback">Comparer to use when FormKeys not on the load order. Default is to throw an exception</param>
    /// <returns>Comparer to use</returns>
    /// <exception cref="ArgumentOutOfRangeException">A FormKey not on the load order is queried, and no fallback specified.</exception>
    public static Comparer<FormKey> LoadOrderComparer(
        IEnumerable<ModKey> loadOrder,
        Comparer<FormKey>? matchingModKeyFallback = null,
        Comparer<FormKey>? notOnLoadOrderFallback = null) =>
        new ModKeyListFormKeyComparer(loadOrder.ToList(), matchingModKeyFallback: matchingModKeyFallback, notOnLoadOrderFallback: notOnLoadOrderFallback);

    /// <summary>
    /// Constructs a comparer that sorts FormKeys according to a load order.
    /// If FormKeys are from the same mod, then alphabetical sorting will be used, unless an override is specified.
    /// </summary>
    /// <param name="loadOrder">Load order to refer to for sorting</param>
    /// <param name="matchingModKeyFallback">Comparer to use when FormKeys from the same mod.  Alphabetical is default.</param>
    /// <param name="notOnLoadOrderFallback">Comparer to use when FormKeys not on the load order. Default is to throw an exception</param>
    /// <returns>Comparer to use</returns>
    /// <exception cref="ArgumentOutOfRangeException">A FormKey not on the load order is queried, and no fallback specified.</exception>
    public static Comparer<FormKey> LoadOrderComparer(
        ILoadOrderGetter loadOrder,
        Comparer<FormKey>? matchingModKeyFallback = null,
        Comparer<FormKey>? notOnLoadOrderFallback = null) =>
        new ModKeyListFormKeyComparer(loadOrder.ListedOrder.ToList(), matchingModKeyFallback: matchingModKeyFallback, notOnLoadOrderFallback: notOnLoadOrderFallback);

    private class ModKeyListFormKeyComparer : Comparer<FormKey>
    {
        private readonly IReadOnlyList<ModKey> _loadOrder;
        private readonly Comparer<FormKey> _matchingModKeyFallback;
        private readonly Comparer<FormKey>? _notOnLoadOrderFallback;

        public ModKeyListFormKeyComparer(
            IReadOnlyList<ModKey> loadOrder,
            Comparer<FormKey>? matchingModKeyFallback,
            Comparer<FormKey>? notOnLoadOrderFallback)
        {
            _loadOrder = loadOrder;
            _matchingModKeyFallback = matchingModKeyFallback ?? AlphabeticalComparer(mastersFirst: false);
            _notOnLoadOrderFallback = notOnLoadOrderFallback;
        }

        public override int Compare(FormKey x, FormKey y)
        {
            if (x.ModKey != y.ModKey)
            {
                var xIndex = _loadOrder.IndexOf(x.ModKey);
                if (xIndex == -1)
                {
                    if (_notOnLoadOrderFallback != null)
                    {
                        return _notOnLoadOrderFallback.Compare(x, y);
                    }
                    throw new ArgumentOutOfRangeException($"ModKey was not on load order: {x.ModKey}");
                }
                var yIndex = _loadOrder.IndexOf(y.ModKey);
                if (yIndex == -1)
                {
                    if (_notOnLoadOrderFallback != null)
                    {
                        return _notOnLoadOrderFallback.Compare(x, y);
                    }
                    throw new ArgumentOutOfRangeException($"ModKey was not on load order: {y.ModKey}");
                }
                return xIndex.CompareTo(yIndex);
            }

            return _matchingModKeyFallback.Compare(x, y);
        }
    }

    /// <summary>
    /// Constructs a comparer that sorts FormKeys according to a load order.
    /// If FormKeys are from the same mod, then alphabetical sorting will be used, unless an override is specified.
    /// </summary>
    /// <param name="loadOrder">Load order to refer to for sorting</param>
    /// <param name="matchingFallback">Comparer to use when FormKeys from the same mod.  Alphabetical is default.</param>
    /// <returns>Comparer to use</returns>
    /// <exception cref="ArgumentOutOfRangeException">A FormKey not on the load order is queried.</exception>
    public static Comparer<FormKey> LoadOrderComparer<TItem>(
        LoadOrder<TItem> loadOrder,
        Comparer<FormKey>? matchingFallback = null)
        where TItem : class, IModKeyed
    {
        return new ModEntryListFormKeyComparer<TItem>(loadOrder, matchingFallback);
    }

    private class ModEntryListFormKeyComparer<TItem> : Comparer<FormKey>
        where TItem : class, IModKeyed
    {
        private readonly LoadOrder<TItem> _loadOrder;
        private readonly Comparer<FormKey> _matchingFallback;

        public ModEntryListFormKeyComparer(
            LoadOrder<TItem> loadOrder,
            Comparer<FormKey>? matchingFallback)
        {
            _loadOrder = loadOrder;
            _matchingFallback = matchingFallback ?? AlphabeticalComparer(mastersFirst: false);
        }

        public override int Compare(FormKey x, FormKey y)
        {
            if (x.ModKey != y.ModKey)
            {
                var xIndex = _loadOrder.IndexOf(x.ModKey, (l, k) => l.Key.Equals(k));
                if (xIndex == -1) throw new ArgumentOutOfRangeException($"ModKey was not on load order: {x.ModKey}");
                var yIndex = _loadOrder.IndexOf(y.ModKey, (l, k) => l.Key.Equals(k));
                if (yIndex == -1) throw new ArgumentOutOfRangeException($"ModKey was not on load order: {y.ModKey}");
                return xIndex.CompareTo(yIndex);
            }

            return _matchingFallback.Compare(x, y);
        }
    }
    #endregion

    FormKey IFormKeyGetter.FormKey => this;
}