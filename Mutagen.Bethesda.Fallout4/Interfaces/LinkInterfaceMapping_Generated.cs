/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections.Generic;
using Mutagen.Bethesda.Plugins.Records.Internals;

namespace Mutagen.Bethesda.Fallout4.Internals
{
    public class LinkInterfaceMapping : ILinkInterfaceMapping
    {
        public IReadOnlyDictionary<Type, Type[]> InterfaceToObjectTypes { get; }

        public GameCategory GameCategory => GameCategory.Fallout4;

        public LinkInterfaceMapping()
        {
            var dict = new Dictionary<Type, Type[]>();
            dict[typeof(IIdleRelation)] = new Type[]
            {
                typeof(ActionRecord),
                typeof(IdleAnimation),
            };
            dict[typeof(IIdleRelationGetter)] = dict[typeof(IIdleRelation)];
            dict[typeof(IObjectId)] = new Type[]
            {
                typeof(Activator),
                typeof(Ammunition),
                typeof(Armor),
                typeof(Book),
                typeof(Container),
                typeof(Door),
                typeof(Faction),
                typeof(FormList),
                typeof(Furniture),
                typeof(IdleMarker),
                typeof(Ingestible),
                typeof(Ingredient),
                typeof(Key),
                typeof(Light),
                typeof(MiscItem),
                typeof(MoveableStatic),
                typeof(Note),
                typeof(Npc),
                typeof(ObjectModification),
                typeof(Projectile),
                typeof(Spell),
                typeof(Static),
                typeof(TextureSet),
                typeof(Weapon),
            };
            dict[typeof(IObjectIdGetter)] = dict[typeof(IObjectId)];
            dict[typeof(IDamageTypeTarget)] = new Type[]
            {
                typeof(ActorValueInformation),
            };
            dict[typeof(IDamageTypeTargetGetter)] = dict[typeof(IDamageTypeTarget)];
            dict[typeof(IItem)] = new Type[]
            {
                typeof(Armor),
                typeof(Book),
                typeof(Ingestible),
                typeof(Ingredient),
                typeof(Key),
                typeof(LeveledItem),
                typeof(Light),
                typeof(MiscItem),
            };
            dict[typeof(IItemGetter)] = dict[typeof(IItem)];
            dict[typeof(IOutfitTarget)] = new Type[]
            {
                typeof(Armor),
                typeof(LeveledItem),
            };
            dict[typeof(IOutfitTargetGetter)] = dict[typeof(IOutfitTarget)];
            dict[typeof(IConstructible)] = new Type[]
            {
                typeof(Armor),
                typeof(Book),
                typeof(Furniture),
                typeof(Ingestible),
                typeof(Ingredient),
                typeof(Key),
                typeof(Light),
                typeof(MiscItem),
            };
            dict[typeof(IConstructibleGetter)] = dict[typeof(IConstructible)];
            dict[typeof(IBindableEquipment)] = new Type[]
            {
                typeof(Armor),
            };
            dict[typeof(IBindableEquipmentGetter)] = dict[typeof(IBindableEquipment)];
            dict[typeof(IFurnitureAssociation)] = new Type[]
            {
                typeof(Armor),
            };
            dict[typeof(IFurnitureAssociationGetter)] = dict[typeof(IFurnitureAssociation)];
            dict[typeof(IOwner)] = new Type[]
            {
                typeof(Faction),
            };
            dict[typeof(IOwnerGetter)] = dict[typeof(IOwner)];
            dict[typeof(IRelatable)] = new Type[]
            {
                typeof(Faction),
                typeof(Race),
            };
            dict[typeof(IRelatableGetter)] = dict[typeof(IRelatable)];
            dict[typeof(IRegionTarget)] = new Type[]
            {
                typeof(Flora),
                typeof(LandscapeTexture),
                typeof(MoveableStatic),
                typeof(Tree),
            };
            dict[typeof(IRegionTargetGetter)] = dict[typeof(IRegionTarget)];
            dict[typeof(IPlacedTrapTarget)] = new Type[]
            {
                typeof(Hazard),
                typeof(Projectile),
            };
            dict[typeof(IPlacedTrapTargetGetter)] = dict[typeof(IPlacedTrapTarget)];
            dict[typeof(IHarvestTarget)] = new Type[]
            {
                typeof(Ingestible),
                typeof(Ingredient),
                typeof(LeveledItem),
                typeof(MiscItem),
            };
            dict[typeof(IHarvestTargetGetter)] = dict[typeof(IHarvestTarget)];
            dict[typeof(IKeywordLinkedReference)] = new Type[]
            {
                typeof(Keyword),
            };
            dict[typeof(IKeywordLinkedReferenceGetter)] = dict[typeof(IKeywordLinkedReference)];
            dict[typeof(INpcSpawn)] = new Type[]
            {
                typeof(LeveledNpc),
            };
            dict[typeof(INpcSpawnGetter)] = dict[typeof(INpcSpawn)];
            dict[typeof(ISpellRecord)] = new Type[]
            {
                typeof(LeveledSpell),
                typeof(Spell),
            };
            dict[typeof(ISpellRecordGetter)] = dict[typeof(ISpellRecord)];
            dict[typeof(IEmittance)] = new Type[]
            {
                typeof(Light),
                typeof(Region),
            };
            dict[typeof(IEmittanceGetter)] = dict[typeof(IEmittance)];
            dict[typeof(ILocationRecord)] = new Type[]
            {
                typeof(LocationReferenceType),
            };
            dict[typeof(ILocationRecordGetter)] = dict[typeof(ILocationRecord)];
            dict[typeof(IEffectRecord)] = new Type[]
            {
                typeof(ObjectEffect),
                typeof(Spell),
            };
            dict[typeof(IEffectRecordGetter)] = dict[typeof(IEffectRecord)];
            dict[typeof(ILocationTargetable)] = new Type[]
            {
                typeof(PlacedNpc),
                typeof(PlacedObject),
                typeof(APlacedTrap),
            };
            dict[typeof(ILocationTargetableGetter)] = dict[typeof(ILocationTargetable)];
            InterfaceToObjectTypes = dict;
        }
    }
}

