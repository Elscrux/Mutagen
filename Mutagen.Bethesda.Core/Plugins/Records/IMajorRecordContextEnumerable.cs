using Loqui;
using Mutagen.Bethesda.Plugins.Cache;

namespace Mutagen.Bethesda.Plugins.Records;

public interface IMajorRecordSimpleContextEnumerable
{
    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified type  
    /// </summary>  
    /// <returns>Enumerable of all major records</returns>  
    IEnumerable<IModContext<IMajorRecordGetter>> EnumerateMajorRecordSimpleContexts();

    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified generic type  
    /// </summary>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>
    /// <returns>Enumerable of all applicable major records</returns>  
    IEnumerable<IModContext<TMajor>> EnumerateMajorRecordSimpleContexts<TMajor>(bool throwIfUnknown = true)
        where TMajor : class, IMajorRecordQueryableGetter;

    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified type  
    /// </summary>  
    /// <param name="t">Type to query and iterate</param> 
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>
    /// <returns>Enumerable of all applicable major records</returns>  
    IEnumerable<IModContext<IMajorRecordGetter>> EnumerateMajorRecordSimpleContexts(Type t, bool throwIfUnknown = true);
}
    
public interface IMajorRecordContextEnumerable<TMod, TModGetter> : IMajorRecordSimpleContextEnumerable
    where TModGetter : IModGetter
    where TMod : TModGetter, IMod
{
    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified generic type  
    /// </summary>
    /// <param name="linkCache">LinkCache to use when creating parent objects</param> 
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>
    /// <returns>Enumerable of all applicable major records</returns>  
    IEnumerable<IModContext<TMod, TModGetter, TSetter, TGetter>> EnumerateMajorRecordContexts<TSetter, TGetter>(ILinkCache linkCache, bool throwIfUnknown = true)
        where TSetter : class, IMajorRecordQueryable, TGetter
        where TGetter : class, IMajorRecordQueryableGetter;

    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified type  
    /// </summary>  
    /// <param name="linkCache">LinkCache to use when creating parent objects</param> 
    /// <param name="t">Type to query and iterate</param> 
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>
    /// <returns>Enumerable of all applicable major records</returns>  
    IEnumerable<IModContext<TMod, TModGetter, IMajorRecord, IMajorRecordGetter>> EnumerateMajorRecordContexts(ILinkCache linkCache, Type t, bool throwIfUnknown = true);
}

internal static class MajorRecordContextEnumerableUtility
{
    internal enum TypeMatch
    {
        NotMatch,
        MajorRecord,
        Match
    }

    public static TypeMatch GetMatch(Type type, string fullName)
    {
        if (!LoquiRegistration.TryGetRegister(type, out var regis)) return TypeMatch.NotMatch;
        if (regis.Name.Equals("MajorRecord")) return TypeMatch.MajorRecord;
        return regis.FullName.Equals(fullName) ? TypeMatch.Match : TypeMatch.NotMatch;
    }
}