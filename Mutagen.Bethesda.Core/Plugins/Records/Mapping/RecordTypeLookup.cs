﻿using System.Reflection;
using Noggog;

namespace Mutagen.Bethesda.Plugins.Records.Mapping;

public static class RecordTypeLookup
{
    public static RecordType GetMajorRecordType<TMajor>()
        where TMajor : IMajorRecordGetter
    {
        return MajorRecordTypeLookup<TMajor>.RecordType;
    }

    internal static IEnumerable<AssociatedRecordTypesAttribute> GetAssociatedRecordTypesAttributes(Type t)
    {
        return t.GetCustomAttributes()
            .Concat(t.GetInterfaces().SelectMany(GetAssociatedRecordTypesAttributes))
            .WhereCastable<Attribute, AssociatedRecordTypesAttribute>();
    }
}

public static class MajorRecordTypeLookup<TMajor>
    where TMajor : IMajorRecordGetter
{
    public static readonly RecordType RecordType;

    static MajorRecordTypeLookup()
    {
        RecordType = RecordTypeLookup.GetAssociatedRecordTypesAttributes(typeof(TMajor))
            .First().Types.First();
    }
}