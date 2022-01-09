# Link Interfaces
Link Interfaces are used by FormLinks to point to several record types at once.  For example, a Container record might be able to contain Armors, Weapons, Ingredients, etc.

An interface would be defined such as 'IItem', which all Armor, Weapon, Ingredients would all implement.

A `FormLink<IItem>` could then point to all those record types by pointing to the interface instead.
## Interfaces to Concrete Classes
### IDamageTypeTarget
- ActorValueInformation
### IEffectRecord
- ObjectEffect
- Spell
### IIdleRelation
- ActionRecord
### IKeywordLinkedReference
- Keyword
### ILocationRecord
- LocationReferenceType
### ILocationTargetable
- Door
### IObjectId
- Activator
- Door
- Faction
- Spell
- TextureSet
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
