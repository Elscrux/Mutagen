using System.Collections.Generic;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Plugins.Order;
using Mutagen.Bethesda.Plugins.Order.Internals;

namespace Mutagen.Bethesda.Fallout4
{
    public static class TypeOptionSolidifierMixIns
    {
        #region Normal
        /// <summary>
        /// Scope a load order query to AcousticSpace
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on AcousticSpace</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAcousticSpace, IAcousticSpaceGetter> AcousticSpace(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAcousticSpace, IAcousticSpaceGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IAcousticSpaceGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IAcousticSpace, IAcousticSpaceGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to AcousticSpace
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on AcousticSpace</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAcousticSpace, IAcousticSpaceGetter> AcousticSpace(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAcousticSpace, IAcousticSpaceGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IAcousticSpaceGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IAcousticSpace, IAcousticSpaceGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ActionRecord
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ActionRecord</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActionRecord, IActionRecordGetter> ActionRecord(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActionRecord, IActionRecordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IActionRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IActionRecord, IActionRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ActionRecord
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ActionRecord</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActionRecord, IActionRecordGetter> ActionRecord(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActionRecord, IActionRecordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IActionRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IActionRecord, IActionRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Activator
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Activator</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActivator, IActivatorGetter> Activator(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActivator, IActivatorGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IActivatorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IActivator, IActivatorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Activator
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Activator</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActivator, IActivatorGetter> Activator(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActivator, IActivatorGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IActivatorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IActivator, IActivatorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ActorValueInformation
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ActorValueInformation</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActorValueInformation, IActorValueInformationGetter> ActorValueInformation(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActorValueInformation, IActorValueInformationGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IActorValueInformationGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IActorValueInformation, IActorValueInformationGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ActorValueInformation
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ActorValueInformation</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActorValueInformation, IActorValueInformationGetter> ActorValueInformation(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IActorValueInformation, IActorValueInformationGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IActorValueInformationGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IActorValueInformation, IActorValueInformationGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ADamageType
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ADamageType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IADamageType, IADamageTypeGetter> ADamageType(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IADamageType, IADamageTypeGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IADamageTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IADamageType, IADamageTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ADamageType
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ADamageType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IADamageType, IADamageTypeGetter> ADamageType(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IADamageType, IADamageTypeGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IADamageTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IADamageType, IADamageTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to AnimationSoundTagSet
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on AnimationSoundTagSet</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAnimationSoundTagSet, IAnimationSoundTagSetGetter> AnimationSoundTagSet(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAnimationSoundTagSet, IAnimationSoundTagSetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IAnimationSoundTagSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IAnimationSoundTagSet, IAnimationSoundTagSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to AnimationSoundTagSet
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on AnimationSoundTagSet</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAnimationSoundTagSet, IAnimationSoundTagSetGetter> AnimationSoundTagSet(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAnimationSoundTagSet, IAnimationSoundTagSetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IAnimationSoundTagSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IAnimationSoundTagSet, IAnimationSoundTagSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Armor
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Armor</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmor, IArmorGetter> Armor(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmor, IArmorGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IArmorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IArmor, IArmorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Armor
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Armor</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmor, IArmorGetter> Armor(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmor, IArmorGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IArmorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IArmor, IArmorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ArmorAddon
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ArmorAddon</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmorAddon, IArmorAddonGetter> ArmorAddon(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmorAddon, IArmorAddonGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IArmorAddonGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IArmorAddon, IArmorAddonGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ArmorAddon
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ArmorAddon</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmorAddon, IArmorAddonGetter> ArmorAddon(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArmorAddon, IArmorAddonGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IArmorAddonGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IArmorAddon, IArmorAddonGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ArtObject
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ArtObject</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArtObject, IArtObjectGetter> ArtObject(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArtObject, IArtObjectGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IArtObjectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IArtObject, IArtObjectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ArtObject
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ArtObject</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArtObject, IArtObjectGetter> ArtObject(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IArtObject, IArtObjectGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IArtObjectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IArtObject, IArtObjectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to AttractionRule
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on AttractionRule</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAttractionRule, IAttractionRuleGetter> AttractionRule(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAttractionRule, IAttractionRuleGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IAttractionRuleGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IAttractionRule, IAttractionRuleGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to AttractionRule
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on AttractionRule</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAttractionRule, IAttractionRuleGetter> AttractionRule(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IAttractionRule, IAttractionRuleGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IAttractionRuleGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IAttractionRule, IAttractionRuleGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Book
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Book</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBook, IBookGetter> Book(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBook, IBookGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IBookGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IBook, IBookGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Book
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Book</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBook, IBookGetter> Book(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBook, IBookGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IBookGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IBook, IBookGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Cell
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Cell</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ICell, ICellGetter> Cell(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ICell, ICellGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ICellGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ICell, ICellGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Cell
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Cell</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ICell, ICellGetter> Cell(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ICell, ICellGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ICellGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ICell, ICellGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Class
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Class</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IClass, IClassGetter> Class(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IClass, IClassGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IClassGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IClass, IClassGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Class
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Class</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IClass, IClassGetter> Class(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IClass, IClassGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IClassGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IClass, IClassGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ColorRecord
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ColorRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IColorRecord, IColorRecordGetter> ColorRecord(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IColorRecord, IColorRecordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IColorRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IColorRecord, IColorRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ColorRecord
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ColorRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IColorRecord, IColorRecordGetter> ColorRecord(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IColorRecord, IColorRecordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IColorRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IColorRecord, IColorRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Component
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Component</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IComponent, IComponentGetter> Component(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IComponent, IComponentGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IComponentGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IComponent, IComponentGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Component
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Component</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IComponent, IComponentGetter> Component(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IComponent, IComponentGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IComponentGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IComponent, IComponentGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to DamageType
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on DamageType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageType, IDamageTypeGetter> DamageType(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageType, IDamageTypeGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IDamageTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDamageType, IDamageTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to DamageType
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on DamageType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageType, IDamageTypeGetter> DamageType(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageType, IDamageTypeGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IDamageTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDamageType, IDamageTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to DamageTypeIndexed
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on DamageTypeIndexed</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeIndexed, IDamageTypeIndexedGetter> DamageTypeIndexed(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeIndexed, IDamageTypeIndexedGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IDamageTypeIndexedGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDamageTypeIndexed, IDamageTypeIndexedGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to DamageTypeIndexed
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on DamageTypeIndexed</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeIndexed, IDamageTypeIndexedGetter> DamageTypeIndexed(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeIndexed, IDamageTypeIndexedGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IDamageTypeIndexedGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDamageTypeIndexed, IDamageTypeIndexedGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Debris
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Debris</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDebris, IDebrisGetter> Debris(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDebris, IDebrisGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IDebrisGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDebris, IDebrisGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Debris
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Debris</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDebris, IDebrisGetter> Debris(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDebris, IDebrisGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IDebrisGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDebris, IDebrisGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Door
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Door</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDoor, IDoorGetter> Door(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDoor, IDoorGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IDoorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDoor, IDoorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Door
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Door</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDoor, IDoorGetter> Door(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDoor, IDoorGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IDoorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDoor, IDoorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to EquipType
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on EquipType</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEquipType, IEquipTypeGetter> EquipType(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEquipType, IEquipTypeGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IEquipTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IEquipType, IEquipTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to EquipType
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on EquipType</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEquipType, IEquipTypeGetter> EquipType(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEquipType, IEquipTypeGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IEquipTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IEquipType, IEquipTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Explosion
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Explosion</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IExplosion, IExplosionGetter> Explosion(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IExplosion, IExplosionGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IExplosionGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IExplosion, IExplosionGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Explosion
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Explosion</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IExplosion, IExplosionGetter> Explosion(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IExplosion, IExplosionGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IExplosionGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IExplosion, IExplosionGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Faction
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Faction</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFaction, IFactionGetter> Faction(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFaction, IFactionGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IFactionGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFaction, IFactionGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Faction
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Faction</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFaction, IFactionGetter> Faction(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFaction, IFactionGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IFactionGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFaction, IFactionGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Fallout4MajorRecord
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Fallout4MajorRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter> Fallout4MajorRecord(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IFallout4MajorRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Fallout4MajorRecord
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Fallout4MajorRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter> Fallout4MajorRecord(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IFallout4MajorRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Footstep
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Footstep</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstep, IFootstepGetter> Footstep(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstep, IFootstepGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IFootstepGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFootstep, IFootstepGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Footstep
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Footstep</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstep, IFootstepGetter> Footstep(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstep, IFootstepGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IFootstepGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFootstep, IFootstepGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to FootstepSet
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on FootstepSet</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstepSet, IFootstepSetGetter> FootstepSet(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstepSet, IFootstepSetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IFootstepSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFootstepSet, IFootstepSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to FootstepSet
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on FootstepSet</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstepSet, IFootstepSetGetter> FootstepSet(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFootstepSet, IFootstepSetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IFootstepSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFootstepSet, IFootstepSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to FormList
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on FormList</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFormList, IFormListGetter> FormList(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFormList, IFormListGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IFormListGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFormList, IFormListGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to FormList
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on FormList</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFormList, IFormListGetter> FormList(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IFormList, IFormListGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IFormListGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IFormList, IFormListGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSetting
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GameSetting</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSetting, IGameSettingGetter> GameSetting(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSetting, IGameSettingGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGameSettingGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSetting, IGameSettingGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSetting
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GameSetting</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSetting, IGameSettingGetter> GameSetting(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSetting, IGameSettingGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGameSettingGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSetting, IGameSettingGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingBool
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GameSettingBool</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingBool, IGameSettingBoolGetter> GameSettingBool(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingBool, IGameSettingBoolGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGameSettingBoolGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingBool, IGameSettingBoolGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingBool
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GameSettingBool</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingBool, IGameSettingBoolGetter> GameSettingBool(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingBool, IGameSettingBoolGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGameSettingBoolGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingBool, IGameSettingBoolGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingFloat
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GameSettingFloat</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingFloat, IGameSettingFloatGetter> GameSettingFloat(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingFloat, IGameSettingFloatGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGameSettingFloatGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingFloat, IGameSettingFloatGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingFloat
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GameSettingFloat</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingFloat, IGameSettingFloatGetter> GameSettingFloat(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingFloat, IGameSettingFloatGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGameSettingFloatGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingFloat, IGameSettingFloatGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingInt
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GameSettingInt</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingInt, IGameSettingIntGetter> GameSettingInt(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingInt, IGameSettingIntGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGameSettingIntGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingInt, IGameSettingIntGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingInt
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GameSettingInt</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingInt, IGameSettingIntGetter> GameSettingInt(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingInt, IGameSettingIntGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGameSettingIntGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingInt, IGameSettingIntGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingString
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GameSettingString</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingString, IGameSettingStringGetter> GameSettingString(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingString, IGameSettingStringGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGameSettingStringGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingString, IGameSettingStringGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingString
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GameSettingString</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingString, IGameSettingStringGetter> GameSettingString(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingString, IGameSettingStringGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGameSettingStringGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingString, IGameSettingStringGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingUInt
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GameSettingUInt</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingUInt, IGameSettingUIntGetter> GameSettingUInt(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingUInt, IGameSettingUIntGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGameSettingUIntGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingUInt, IGameSettingUIntGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GameSettingUInt
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GameSettingUInt</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingUInt, IGameSettingUIntGetter> GameSettingUInt(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGameSettingUInt, IGameSettingUIntGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGameSettingUIntGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGameSettingUInt, IGameSettingUIntGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Global
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Global</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobal, IGlobalGetter> Global(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobal, IGlobalGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGlobalGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobal, IGlobalGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Global
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Global</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobal, IGlobalGetter> Global(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobal, IGlobalGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGlobalGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobal, IGlobalGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalBool
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GlobalBool</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalBool, IGlobalBoolGetter> GlobalBool(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalBool, IGlobalBoolGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGlobalBoolGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalBool, IGlobalBoolGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalBool
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GlobalBool</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalBool, IGlobalBoolGetter> GlobalBool(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalBool, IGlobalBoolGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGlobalBoolGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalBool, IGlobalBoolGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalFloat
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GlobalFloat</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalFloat, IGlobalFloatGetter> GlobalFloat(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalFloat, IGlobalFloatGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGlobalFloatGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalFloat, IGlobalFloatGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalFloat
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GlobalFloat</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalFloat, IGlobalFloatGetter> GlobalFloat(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalFloat, IGlobalFloatGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGlobalFloatGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalFloat, IGlobalFloatGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalInt
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GlobalInt</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalInt, IGlobalIntGetter> GlobalInt(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalInt, IGlobalIntGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGlobalIntGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalInt, IGlobalIntGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalInt
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GlobalInt</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalInt, IGlobalIntGetter> GlobalInt(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalInt, IGlobalIntGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGlobalIntGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalInt, IGlobalIntGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalShort
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on GlobalShort</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalShort, IGlobalShortGetter> GlobalShort(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalShort, IGlobalShortGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGlobalShortGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalShort, IGlobalShortGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to GlobalShort
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on GlobalShort</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalShort, IGlobalShortGetter> GlobalShort(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGlobalShort, IGlobalShortGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGlobalShortGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGlobalShort, IGlobalShortGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Grass
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Grass</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGrass, IGrassGetter> Grass(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGrass, IGrassGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IGrassGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGrass, IGrassGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Grass
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Grass</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGrass, IGrassGetter> Grass(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IGrass, IGrassGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IGrassGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IGrass, IGrassGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to HeadPart
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on HeadPart</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IHeadPart, IHeadPartGetter> HeadPart(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IHeadPart, IHeadPartGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IHeadPartGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IHeadPart, IHeadPartGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to HeadPart
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on HeadPart</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IHeadPart, IHeadPartGetter> HeadPart(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IHeadPart, IHeadPartGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IHeadPartGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IHeadPart, IHeadPartGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ImpactDataSet
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ImpactDataSet</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IImpactDataSet, IImpactDataSetGetter> ImpactDataSet(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IImpactDataSet, IImpactDataSetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IImpactDataSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IImpactDataSet, IImpactDataSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ImpactDataSet
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ImpactDataSet</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IImpactDataSet, IImpactDataSetGetter> ImpactDataSet(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IImpactDataSet, IImpactDataSetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IImpactDataSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IImpactDataSet, IImpactDataSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Keyword
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Keyword</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeyword, IKeywordGetter> Keyword(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeyword, IKeywordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IKeywordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IKeyword, IKeywordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Keyword
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Keyword</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeyword, IKeywordGetter> Keyword(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeyword, IKeywordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IKeywordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IKeyword, IKeywordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to LandscapeTexture
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on LandscapeTexture</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILandscapeTexture, ILandscapeTextureGetter> LandscapeTexture(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILandscapeTexture, ILandscapeTextureGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ILandscapeTextureGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILandscapeTexture, ILandscapeTextureGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to LandscapeTexture
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on LandscapeTexture</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILandscapeTexture, ILandscapeTextureGetter> LandscapeTexture(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILandscapeTexture, ILandscapeTextureGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ILandscapeTextureGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILandscapeTexture, ILandscapeTextureGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to LeveledSpell
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on LeveledSpell</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILeveledSpell, ILeveledSpellGetter> LeveledSpell(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILeveledSpell, ILeveledSpellGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ILeveledSpellGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILeveledSpell, ILeveledSpellGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to LeveledSpell
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on LeveledSpell</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILeveledSpell, ILeveledSpellGetter> LeveledSpell(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILeveledSpell, ILeveledSpellGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ILeveledSpellGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILeveledSpell, ILeveledSpellGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to LocationReferenceType
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on LocationReferenceType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationReferenceType, ILocationReferenceTypeGetter> LocationReferenceType(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationReferenceType, ILocationReferenceTypeGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ILocationReferenceTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILocationReferenceType, ILocationReferenceTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to LocationReferenceType
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on LocationReferenceType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationReferenceType, ILocationReferenceTypeGetter> LocationReferenceType(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationReferenceType, ILocationReferenceTypeGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ILocationReferenceTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILocationReferenceType, ILocationReferenceTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MagicEffect
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on MagicEffect</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMagicEffect, IMagicEffectGetter> MagicEffect(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMagicEffect, IMagicEffectGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IMagicEffectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMagicEffect, IMagicEffectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MagicEffect
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on MagicEffect</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMagicEffect, IMagicEffectGetter> MagicEffect(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMagicEffect, IMagicEffectGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IMagicEffectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMagicEffect, IMagicEffectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MaterialSwap
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on MaterialSwap</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialSwap, IMaterialSwapGetter> MaterialSwap(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialSwap, IMaterialSwapGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IMaterialSwapGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMaterialSwap, IMaterialSwapGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MaterialSwap
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on MaterialSwap</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialSwap, IMaterialSwapGetter> MaterialSwap(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialSwap, IMaterialSwapGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IMaterialSwapGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMaterialSwap, IMaterialSwapGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MaterialType
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on MaterialType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialType, IMaterialTypeGetter> MaterialType(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialType, IMaterialTypeGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IMaterialTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMaterialType, IMaterialTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MaterialType
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on MaterialType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialType, IMaterialTypeGetter> MaterialType(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMaterialType, IMaterialTypeGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IMaterialTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMaterialType, IMaterialTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Message
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Message</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMessage, IMessageGetter> Message(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMessage, IMessageGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IMessageGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMessage, IMessageGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Message
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Message</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMessage, IMessageGetter> Message(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMessage, IMessageGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IMessageGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMessage, IMessageGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MiscItem
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on MiscItem</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMiscItem, IMiscItemGetter> MiscItem(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMiscItem, IMiscItemGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IMiscItemGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMiscItem, IMiscItemGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to MiscItem
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on MiscItem</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMiscItem, IMiscItemGetter> MiscItem(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IMiscItem, IMiscItemGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IMiscItemGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IMiscItem, IMiscItemGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ObjectEffect
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ObjectEffect</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectEffect, IObjectEffectGetter> ObjectEffect(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectEffect, IObjectEffectGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IObjectEffectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IObjectEffect, IObjectEffectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ObjectEffect
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ObjectEffect</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectEffect, IObjectEffectGetter> ObjectEffect(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectEffect, IObjectEffectGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IObjectEffectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IObjectEffect, IObjectEffectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Outfit
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Outfit</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfit, IOutfitGetter> Outfit(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfit, IOutfitGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IOutfitGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IOutfit, IOutfitGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Outfit
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Outfit</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfit, IOutfitGetter> Outfit(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfit, IOutfitGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IOutfitGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IOutfit, IOutfitGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Perk
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Perk</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPerk, IPerkGetter> Perk(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPerk, IPerkGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IPerkGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IPerk, IPerkGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Perk
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Perk</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPerk, IPerkGetter> Perk(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPerk, IPerkGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IPerkGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IPerk, IPerkGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to PlacedObject
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on PlacedObject</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPlacedObject, IPlacedObjectGetter> PlacedObject(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPlacedObject, IPlacedObjectGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IPlacedObjectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IPlacedObject, IPlacedObjectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to PlacedObject
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on PlacedObject</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPlacedObject, IPlacedObjectGetter> PlacedObject(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IPlacedObject, IPlacedObjectGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IPlacedObjectGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IPlacedObject, IPlacedObjectGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Quest
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Quest</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IQuest, IQuestGetter> Quest(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IQuest, IQuestGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IQuestGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IQuest, IQuestGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Quest
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Quest</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IQuest, IQuestGetter> Quest(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IQuest, IQuestGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IQuestGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IQuest, IQuestGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Race
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Race</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRace, IRaceGetter> Race(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRace, IRaceGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IRaceGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRace, IRaceGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Race
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Race</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRace, IRaceGetter> Race(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRace, IRaceGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IRaceGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRace, IRaceGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Region
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Region</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegion, IRegionGetter> Region(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegion, IRegionGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IRegionGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRegion, IRegionGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Region
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Region</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegion, IRegionGetter> Region(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegion, IRegionGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IRegionGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRegion, IRegionGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ReverbParameters
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ReverbParameters</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IReverbParameters, IReverbParametersGetter> ReverbParameters(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IReverbParameters, IReverbParametersGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IReverbParametersGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IReverbParameters, IReverbParametersGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ReverbParameters
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ReverbParameters</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IReverbParameters, IReverbParametersGetter> ReverbParameters(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IReverbParameters, IReverbParametersGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IReverbParametersGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IReverbParameters, IReverbParametersGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to SoundDescriptor
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on SoundDescriptor</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundDescriptor, ISoundDescriptorGetter> SoundDescriptor(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundDescriptor, ISoundDescriptorGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ISoundDescriptorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISoundDescriptor, ISoundDescriptorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to SoundDescriptor
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on SoundDescriptor</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundDescriptor, ISoundDescriptorGetter> SoundDescriptor(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundDescriptor, ISoundDescriptorGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ISoundDescriptorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISoundDescriptor, ISoundDescriptorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to SoundMarker
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on SoundMarker</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundMarker, ISoundMarkerGetter> SoundMarker(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundMarker, ISoundMarkerGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ISoundMarkerGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISoundMarker, ISoundMarkerGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to SoundMarker
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on SoundMarker</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundMarker, ISoundMarkerGetter> SoundMarker(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISoundMarker, ISoundMarkerGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ISoundMarkerGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISoundMarker, ISoundMarkerGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Spell
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Spell</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpell, ISpellGetter> Spell(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpell, ISpellGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ISpellGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISpell, ISpellGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Spell
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Spell</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpell, ISpellGetter> Spell(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpell, ISpellGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ISpellGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISpell, ISpellGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Static
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Static</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IStatic, IStaticGetter> Static(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IStatic, IStaticGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IStaticGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IStatic, IStaticGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Static
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Static</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IStatic, IStaticGetter> Static(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IStatic, IStaticGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IStaticGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IStatic, IStaticGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to TalkingActivator
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on TalkingActivator</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITalkingActivator, ITalkingActivatorGetter> TalkingActivator(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITalkingActivator, ITalkingActivatorGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ITalkingActivatorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ITalkingActivator, ITalkingActivatorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to TalkingActivator
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on TalkingActivator</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITalkingActivator, ITalkingActivatorGetter> TalkingActivator(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITalkingActivator, ITalkingActivatorGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ITalkingActivatorGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ITalkingActivator, ITalkingActivatorGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to TextureSet
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on TextureSet</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITextureSet, ITextureSetGetter> TextureSet(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITextureSet, ITextureSetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ITextureSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ITextureSet, ITextureSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to TextureSet
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on TextureSet</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITextureSet, ITextureSetGetter> TextureSet(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITextureSet, ITextureSetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ITextureSetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ITextureSet, ITextureSetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Transform
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Transform</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITransform, ITransformGetter> Transform(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITransform, ITransformGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ITransformGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ITransform, ITransformGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Transform
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Transform</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITransform, ITransformGetter> Transform(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ITransform, ITransformGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ITransformGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ITransform, ITransformGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to VoiceType
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on VoiceType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IVoiceType, IVoiceTypeGetter> VoiceType(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IVoiceType, IVoiceTypeGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IVoiceTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IVoiceType, IVoiceTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to VoiceType
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on VoiceType</returns>
        public static TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IVoiceType, IVoiceTypeGetter> VoiceType(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TopLevelTypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IVoiceType, IVoiceTypeGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IVoiceTypeGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IVoiceType, IVoiceTypeGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Water
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on Water</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IWater, IWaterGetter> Water(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IWater, IWaterGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IWaterGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IWater, IWaterGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to Water
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on Water</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IWater, IWaterGetter> Water(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IWater, IWaterGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IWaterGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IWater, IWaterGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        #endregion

        #region Link Interfaces
        /// <summary>
        /// Scope a load order query to IIdleRelation
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IIdleRelation</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IIdleRelation, IIdleRelationGetter> IIdleRelation(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IIdleRelation, IIdleRelationGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IIdleRelationGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IIdleRelation, IIdleRelationGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IIdleRelation
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IIdleRelation</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IIdleRelation, IIdleRelationGetter> IIdleRelation(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IIdleRelation, IIdleRelationGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IIdleRelationGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IIdleRelation, IIdleRelationGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IObjectId
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IObjectId</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectId, IObjectIdGetter> IObjectId(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectId, IObjectIdGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IObjectIdGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IObjectId, IObjectIdGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IObjectId
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IObjectId</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectId, IObjectIdGetter> IObjectId(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IObjectId, IObjectIdGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IObjectIdGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IObjectId, IObjectIdGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IDamageTypeTarget
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IDamageTypeTarget</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeTarget, IDamageTypeTargetGetter> IDamageTypeTarget(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeTarget, IDamageTypeTargetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IDamageTypeTargetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDamageTypeTarget, IDamageTypeTargetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IDamageTypeTarget
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IDamageTypeTarget</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeTarget, IDamageTypeTargetGetter> IDamageTypeTarget(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IDamageTypeTarget, IDamageTypeTargetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IDamageTypeTargetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IDamageTypeTarget, IDamageTypeTargetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IItem
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IItem</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IItem, IItemGetter> IItem(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IItem, IItemGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IItemGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IItem, IItemGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IItem
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IItem</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IItem, IItemGetter> IItem(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IItem, IItemGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IItemGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IItem, IItemGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IOutfitTarget
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IOutfitTarget</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfitTarget, IOutfitTargetGetter> IOutfitTarget(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfitTarget, IOutfitTargetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IOutfitTargetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IOutfitTarget, IOutfitTargetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IOutfitTarget
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IOutfitTarget</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfitTarget, IOutfitTargetGetter> IOutfitTarget(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOutfitTarget, IOutfitTargetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IOutfitTargetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IOutfitTarget, IOutfitTargetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IConstructible
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IConstructible</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IConstructible, IConstructibleGetter> IConstructible(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IConstructible, IConstructibleGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IConstructibleGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IConstructible, IConstructibleGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IConstructible
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IConstructible</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IConstructible, IConstructibleGetter> IConstructible(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IConstructible, IConstructibleGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IConstructibleGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IConstructible, IConstructibleGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IBindableEquipment
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IBindableEquipment</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBindableEquipment, IBindableEquipmentGetter> IBindableEquipment(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBindableEquipment, IBindableEquipmentGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IBindableEquipmentGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IBindableEquipment, IBindableEquipmentGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IBindableEquipment
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IBindableEquipment</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBindableEquipment, IBindableEquipmentGetter> IBindableEquipment(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IBindableEquipment, IBindableEquipmentGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IBindableEquipmentGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IBindableEquipment, IBindableEquipmentGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ILocationTargetable
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ILocationTargetable</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationTargetable, ILocationTargetableGetter> ILocationTargetable(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationTargetable, ILocationTargetableGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ILocationTargetableGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILocationTargetable, ILocationTargetableGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ILocationTargetable
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ILocationTargetable</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationTargetable, ILocationTargetableGetter> ILocationTargetable(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationTargetable, ILocationTargetableGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ILocationTargetableGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILocationTargetable, ILocationTargetableGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IOwner
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IOwner</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOwner, IOwnerGetter> IOwner(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOwner, IOwnerGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IOwnerGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IOwner, IOwnerGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IOwner
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IOwner</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOwner, IOwnerGetter> IOwner(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IOwner, IOwnerGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IOwnerGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IOwner, IOwnerGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IRelatable
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IRelatable</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRelatable, IRelatableGetter> IRelatable(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRelatable, IRelatableGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IRelatableGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRelatable, IRelatableGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IRelatable
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IRelatable</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRelatable, IRelatableGetter> IRelatable(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRelatable, IRelatableGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IRelatableGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRelatable, IRelatableGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IKeywordLinkedReference
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IKeywordLinkedReference</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeywordLinkedReference, IKeywordLinkedReferenceGetter> IKeywordLinkedReference(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeywordLinkedReference, IKeywordLinkedReferenceGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IKeywordLinkedReferenceGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IKeywordLinkedReference, IKeywordLinkedReferenceGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IKeywordLinkedReference
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IKeywordLinkedReference</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeywordLinkedReference, IKeywordLinkedReferenceGetter> IKeywordLinkedReference(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IKeywordLinkedReference, IKeywordLinkedReferenceGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IKeywordLinkedReferenceGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IKeywordLinkedReference, IKeywordLinkedReferenceGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IRegionTarget
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IRegionTarget</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegionTarget, IRegionTargetGetter> IRegionTarget(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegionTarget, IRegionTargetGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IRegionTargetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRegionTarget, IRegionTargetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IRegionTarget
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IRegionTarget</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegionTarget, IRegionTargetGetter> IRegionTarget(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IRegionTarget, IRegionTargetGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IRegionTargetGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IRegionTarget, IRegionTargetGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ISpellRecord
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ISpellRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpellRecord, ISpellRecordGetter> ISpellRecord(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpellRecord, ISpellRecordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ISpellRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISpellRecord, ISpellRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ISpellRecord
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ISpellRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpellRecord, ISpellRecordGetter> ISpellRecord(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ISpellRecord, ISpellRecordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ISpellRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ISpellRecord, ISpellRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ILocationRecord
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on ILocationRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationRecord, ILocationRecordGetter> ILocationRecord(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationRecord, ILocationRecordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<ILocationRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILocationRecord, ILocationRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to ILocationRecord
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on ILocationRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationRecord, ILocationRecordGetter> ILocationRecord(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, ILocationRecord, ILocationRecordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<ILocationRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, ILocationRecord, ILocationRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IEffectRecord
        /// </summary>
        /// <param name="listings">ModListings to query</param>
        /// <returns>A typed object to do further queries on IEffectRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEffectRecord, IEffectRecordGetter> IEffectRecord(this IEnumerable<IModListingGetter<IFallout4ModGetter>> listings)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEffectRecord, IEffectRecordGetter>(
                (bool includeDeletedRecords) => listings.WinningOverrides<IEffectRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => listings.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IEffectRecord, IEffectRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        /// <summary>
        /// Scope a load order query to IEffectRecord
        /// </summary>
        /// <param name="mods">Mods to query</param>
        /// <returns>A typed object to do further queries on IEffectRecord</returns>
        public static TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEffectRecord, IEffectRecordGetter> IEffectRecord(this IEnumerable<IFallout4ModGetter> mods)
        {
            return new TypedLoadOrderAccess<IFallout4Mod, IFallout4ModGetter, IEffectRecord, IEffectRecordGetter>(
                (bool includeDeletedRecords) => mods.WinningOverrides<IEffectRecordGetter>(includeDeletedRecords: includeDeletedRecords),
                (ILinkCache linkCache, bool includeDeletedRecords) => mods.WinningOverrideContexts<IFallout4Mod, IFallout4ModGetter, IEffectRecord, IEffectRecordGetter>(linkCache, includeDeletedRecords: includeDeletedRecords));
        }

        #endregion

    }
}
