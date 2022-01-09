# Link Interfaces
Link Interfaces are used by FormLinks to point to several record types at once.  For example, a Container record might be able to contain Armors, Weapons, Ingredients, etc.

An interface would be defined such as 'IItem', which all Armor, Weapon, Ingredients would all implement.

A `FormLink<IItem>` could then point to all those record types by pointing to the interface instead.
## Interfaces to Concrete Classes
### IBindableEquipment
- Armor
### IConstructible
- Armor
### IDamageTypeTarget
- ActorValueInformation
### IEffectRecord
- ObjectEffect
- Spell
### IIdleRelation
- ActionRecord
### IItem
- Armor
### IKeywordLinkedReference
- Keyword
### ILocationRecord
- LocationReferenceType
### ILocationTargetable
- Door
### IObjectId
- Activator
- Armor
- Door
- Faction
- Spell
- TextureSet
### IOutfitTarget
- Armor
### IOwner
- Faction
### IRegionTarget
- LandscapeTexture
### IRelatable
- Faction
- Race
### ISpellRecord
- LeveledSpell
- Spell
## Concrete Classes to Interfaces
### ActionRecord
- IIdleRelation
### Activator
- IObjectId
### ActorValueInformation
- IDamageTypeTarget
### Armor
- IBindableEquipment
- IConstructible
- IItem
- IObjectId
- IOutfitTarget
### Door
- ILocationTargetable
- IObjectId
### Faction
- IObjectId
- IOwner
- IRelatable
### Keyword
- IKeywordLinkedReference
### LandscapeTexture
- IRegionTarget
### LeveledSpell
- ISpellRecord
### LocationReferenceType
- ILocationRecord
### ObjectEffect
- IEffectRecord
### Race
- IRelatable
### Spell
- IEffectRecord
- IObjectId
- ISpellRecord
### TextureSet
- IObjectId
