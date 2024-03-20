# Oblivion Aspect Interfaces
## Aspect Interfaces
Aspect Interfaces expose common aspects of records.  For example, `INamed` are implemented by all records that have a `Name`.

Functions can then be written that take in `INamed`, allowing any record that has a name to be passed in.
## Interfaces to Concrete Classes
### IModeled

- Activator
- AlchemicalApparatus
- Ammunition
- AnimatedObject
- BodyData
- Book
- Climate
- Container
- Creature
- Door
- FacePart
- Flora
- Furniture
- Grass
- Hair
- IdleAnimation
- Ingredient
- Key
- Light
- MagicEffect
- Miscellaneous
- Npc
- Potion
- SigilStone
- SoulGem
- Static
- Tree
- Weapon
- Weather
### INamed

- AClothing
- Activator
- AlchemicalApparatus
- Ammunition
- Armor
- Birthsign
- Book
- Cell
- Class
- Clothing
- Container
- Creature
- DialogTopic
- Door
- Enchantment
- Eye
- Faction
- Flora
- Furniture
- Hair
- Ingredient
- Key
- Light
- LocalVariable
- MagicEffect
- MapMarker
- Miscellaneous
- Npc
- Potion
- Quest
- Race
- ScriptEffect
- SigilStone
- SoulGem
- Spell
- SpellLeveled
- SpellUnleveled
- Weapon
- Worldspace
### IWeightValue

- AlchemicalApparatusData
- AmmunitionData
- ArmorData
- ClothingData
- KeyData
- LightData
- SigilStoneData
- SoulGemData
- WeaponData
## Concrete Classes to Interfaces
### AClothing

- INamed
### Activator

- IModeled
- INamed
### AlchemicalApparatus

- IModeled
- INamed
### AlchemicalApparatusData

- IWeightValue
### Ammunition

- IModeled
- INamed
### AmmunitionData

- IWeightValue
### AnimatedObject

- IModeled
### Armor

- INamed
### ArmorData

- IWeightValue
### Birthsign

- INamed
### BodyData

- IModeled
### Book

- IModeled
- INamed
### Cell

- INamed
### Class

- INamed
### Climate

- IModeled
### Clothing

- INamed
### ClothingData

- IWeightValue
### Container

- IModeled
- INamed
### Creature

- IModeled
- INamed
### DialogTopic

- INamed
### Door

- IModeled
- INamed
### Enchantment

- INamed
### Eye

- INamed
### FacePart

- IModeled
### Faction

- INamed
### Flora

- IModeled
- INamed
### Furniture

- IModeled
- INamed
### Grass

- IModeled
### Hair

- IModeled
- INamed
### IdleAnimation

- IModeled
### Ingredient

- IModeled
- INamed
### Key

- IModeled
- INamed
### KeyData

- IWeightValue
### Light

- IModeled
- INamed
### LightData

- IWeightValue
### LocalVariable

- INamed
### MagicEffect

- IModeled
- INamed
### MapMarker

- INamed
### Miscellaneous

- IModeled
- INamed
### Npc

- IModeled
- INamed
### Potion

- IModeled
- INamed
### Quest

- INamed
### Race

- INamed
### ScriptEffect

- INamed
### SigilStone

- IModeled
- INamed
### SigilStoneData

- IWeightValue
### SoulGem

- IModeled
- INamed
### SoulGemData

- IWeightValue
### Spell

- INamed
### SpellLeveled

- INamed
### SpellUnleveled

- INamed
### Static

- IModeled
### Tree

- IModeled
### Weapon

- IModeled
- INamed
### WeaponData

- IWeightValue
### Weather

- IModeled
### Worldspace

- INamed
