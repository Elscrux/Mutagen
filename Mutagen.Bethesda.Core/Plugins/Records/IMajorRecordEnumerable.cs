namespace Mutagen.Bethesda.Plugins.Records;

/// <summary>  
/// An interface for classes that contain Major Records and can enumerate them.  
/// </summary>  
public interface IMajorRecordEnumerable : IMajorRecordGetterEnumerable
{
    /// <summary>  
    /// Enumerates all contained Major Records  
    /// </summary> 
    /// <returns>Enumerable of all contained Major Records</returns>  
    new IEnumerable<IMajorRecord> EnumerateMajorRecords();

    /// <summary>  
    /// Enumerates all contained Major Records of the specified generic type  
    /// </summary>  
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <typeparam name="TMajor">Type of major record to enumerate</typeparam>
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    /// <returns>Enumerable of all contained Major Records</returns>  
    new IEnumerable<TMajor> EnumerateMajorRecords<TMajor>(bool throwIfUnknown = true)
        where TMajor : class, IMajorRecordQueryable;

    /// <summary>  
    /// Enumerates all contained Major Record of the specified type  
    /// </summary>  
    /// <param name="t">Type of major records to enumerate</param> 
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    /// <returns>Enumerable of all applicable major records</returns>  
    new IEnumerable<IMajorRecord> EnumerateMajorRecords(Type? t, bool throwIfUnknown = true);

    /// <summary>
    /// Removes any records within matching the given FormKey.
    /// </summary>
    /// <param name="formKey">FormKey to remove</param>
    [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
    void Remove(FormKey formKey);

    /// <summary>
    /// Removes any records within matching the given FormKeys.
    /// </summary>
    /// <param name="formKeys">FormKeys to remove</param>
    [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
    void Remove(IEnumerable<FormKey> formKeys);

    /// <summary>
    /// Removes any records within matching the given FormKeys.
    /// </summary>
    /// <param name="formKeys">FormKeys to remove</param>
    [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
    void Remove(HashSet<FormKey> formKeys);

    /// <summary>
    /// Removes any records within matching the given FormLinks.
    /// </summary>
    /// <param name="formLinks">FormLinks to remove</param>
    void Remove(IEnumerable<IFormLinkIdentifier> formLinks);

    /// <summary>
    /// Removes any records within matching the given FormKey.
    /// </summary>
    /// <param name="formKey">FormKey to remove</param>
    /// <param name="type">Type associated with FormKey to remove</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove(FormKey formKey, Type type, bool throwIfUnknown = true);

    /// <summary>
    /// Removes any records within matching the given FormKeys.
    /// </summary>
    /// <param name="formKeys">FormKeys to remove</param>
    /// <param name="type">Type associated with FormKey to remove</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove(IEnumerable<FormKey> formKeys, Type type, bool throwIfUnknown = true);

    /// <summary>
    /// Removes any records within matching the given FormKeys.
    /// </summary>
    /// <param name="formKeys">FormKeys to remove</param>
    /// <param name="type">Type associated with FormKey to remove</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove(HashSet<FormKey> formKeys, Type type, bool throwIfUnknown = true);

    /// <summary>
    /// Removes any records within matching the given FormKeys.<br/>
    /// Type information provided allows the mod to remove from a specific group for quicker processing.
    /// </summary>
    /// <param name="formKey">FormKey to remove</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <typeparam name="TMajor">Type of major record to remove from</typeparam>
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove<TMajor>(FormKey formKey, bool throwIfUnknown = true)
        where TMajor : IMajorRecordGetter;

    /// <summary>
    /// Removes any records within matching the given FormKeys.<br/>
    /// Type information provided allows the mod to remove from a specific group for quicker processing.
    /// </summary>
    /// <param name="formKeys">FormKeys to remove</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <typeparam name="TMajor">Type of major record to remove from</typeparam>
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove<TMajor>(HashSet<FormKey> formKeys, bool throwIfUnknown = true)
        where TMajor : IMajorRecordGetter;

    /// <summary>
    /// Removes any records within matching the given FormKeys.<br/>
    /// Type information provided allows the mod to remove from a specific group for quicker processing.
    /// </summary>
    /// <param name="formKeys">FormKeys to remove</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <typeparam name="TMajor">Type of major record to remove from</typeparam>
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove<TMajor>(IEnumerable<FormKey> formKeys, bool throwIfUnknown = true)
        where TMajor : IMajorRecordGetter;

    /// <summary>
    /// Removes any records within matching the given FormKeys.<br/>
    /// Type information provided allows the mod to remove from a specific group for quicker processing.
    /// 
    /// </summary>
    /// <param name="record">Major record whose FormKey is to be removed</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <typeparam name="TMajor">Type of major record to remove from</typeparam>
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove<TMajor>(TMajor record, bool throwIfUnknown = true)
        where TMajor : IMajorRecordGetter;

    /// <summary>
    /// Removes any records within matching the given FormKeys.<br/>
    /// Type information provided allows the mod to remove from a specific group for quicker processing.
    /// 
    /// </summary>
    /// <param name="records">Major records whose FormKeys are to be removed</param>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <typeparam name="TMajor">Type of major record to remove from</typeparam>
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    void Remove<TMajor>(IEnumerable<TMajor> records, bool throwIfUnknown = true)
        where TMajor : IMajorRecordGetter;
}

/// <summary>  
/// An interface for classes that contain Major Record Getter interfaces and can enumerate them  
/// </summary>  
public interface IMajorRecordGetterEnumerable
{
    /// <summary>  
    /// Enumerates all contained Major Record Getters  
    /// </summary>  
    /// <returns>Enumerable of all contained Major Record Getters</returns>  
    IEnumerable<IMajorRecordGetter> EnumerateMajorRecords();

    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified generic type  
    /// </summary>
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    /// <returns>Enumerable of all applicable major records</returns>  
    IEnumerable<T> EnumerateMajorRecords<T>(bool throwIfUnknown = true)
        where T : class, IMajorRecordQueryableGetter;

    /// <summary>  
    /// Enumerates all contained Major Record Getters of the specified type  
    /// </summary>  
    /// <param name="type">Type to query and iterate</param> 
    /// <param name="throwIfUnknown">Whether to throw an exception if type is unknown</param> 
    /// <exception cref="ArgumentException">If a non applicable type is provided, and throw parameter is on</exception>  
    /// <returns>Enumerable of all applicable major records</returns>  
    IEnumerable<IMajorRecordGetter> EnumerateMajorRecords(Type type, bool throwIfUnknown = true);
}