# Skyrim Aspect Interfaces
## Aspect Interfaces
Aspect Interfaces expose common aspects of records.  For example, `INamed` are implemented by all records that have a `Name`.

Functions can then be written that take in `INamed`, allowing any record that has a name to be passed in.
## Interfaces to Concrete Classes
### IHasIcons

- AlchemicalApparatus
- Ammunition
- ArmorModel
- Book
- Ingestible
- Ingredient
- Key
- Light
- LoadScreen
- MiscItem
- Perk
- RegionData
- SoulGem
- Weapon
### IKeyworded

- Activator
- Ammunition
- Armor
- Book
- Flora
- Furniture
- Ingestible
- Ingredient
- Key
- Location
- MagicEffect
- MiscItem
- Npc
- QuestAlias
- Race
- Scroll
- SoulGem
- Spell
- TalkingActivator
- Weapon
### IModeled

- Activator
- AddonNode
- AlchemicalApparatus
- Ammunition
- AnimatedObject
- ArmorModel
- ArtObject
- BodyData
- BodyPartData
- Book
- CameraShot
- Climate
- Container
- DestructionStage
- Door
- Explosion
- Flora
- Furniture
- Grass
- Hazard
- HeadData
- HeadPart
- IdleMarker
- Impact
- Ingestible
- Ingredient
- Key
- LeveledNpc
- Light
- MaterialObject
- MiscItem
- MoveableStatic
- Projectile
- Scroll
- SoulGem
- Static
- TalkingActivator
- Tree
- Weapon
### INamed

- Activator
- ActorValueInformation
- AlchemicalApparatus
- AlternateTexture
- Ammunition
- APackageData
- Armor
- BodyPart
- Book
- Cell
- Class
- CollisionLayer
- ColorRecord
- Container
- DialogTopic
- Door
- Explosion
- Eyes
- Faction
- Flora
- Furniture
- Hazard
- HeadPart
- Ingestible
- Ingredient
- Key
- Light
- Location
- MagicEffect
- MapMarker
- MaterialType
- Message
- MiscItem
- MoveableStatic
- MovementType
- Npc
- ObjectEffect
- PackageDataBool
- PackageDataFloat
- PackageDataInt
- PackageDataLocation
- PackageDataObjectList
- PackageDataTarget
- PackageDataTopic
- Perk
- Phoneme
- Projectile
- Quest
- QuestAlias
- Race
- RegionMap
- SceneAction
- ScenePhase
- ScriptBoolListProperty
- ScriptBoolProperty
- ScriptEntry
- ScriptFloatListProperty
- ScriptFloatProperty
- ScriptIntListProperty
- ScriptIntProperty
- ScriptObjectListProperty
- ScriptObjectProperty
- ScriptProperty
- ScriptStringListProperty
- ScriptStringProperty
- Scroll
- Shout
- SoulGem
- SoundCategory
- Spell
- TalkingActivator
- Tree
- Water
- Weapon
- WordOfPower
- Worldspace
### IObjectBounded

- AcousticSpace
- Activator
- AddonNode
- AlchemicalApparatus
- Ammunition
- Armor
- ArtObject
- Book
- Container
- Door
- DualCastData
- Explosion
- Flora
- Furniture
- Grass
- Hazard
- IdleMarker
- Ingestible
- Ingredient
- Key
- LeveledItem
- LeveledNpc
- LeveledSpell
- Light
- MiscItem
- MoveableStatic
- Npc
- ObjectEffect
- Projectile
- Scroll
- SoulGem
- SoundMarker
- Spell
- Static
- TalkingActivator
- TextureSet
- Tree
- Weapon
### IWeightValue

- AlchemicalApparatus
- Ammunition
- Armor
- Book
- Ingestible
- Ingredient
- Key
- Light
- MiscItem
- Scroll
- SoulGem
- WeaponBasicStats
### Keyword

- Keyword
## Concrete Classes to Interfaces
### AcousticSpace

- IObjectBounded
### Activator

- IKeyworded
- IModeled
- INamed
- IObjectBounded
### ActorValueInformation

- INamed
### AddonNode

- IModeled
- IObjectBounded
### AlchemicalApparatus

- IHasIcons
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### AlternateTexture

- INamed
### Ammunition

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### AnimatedObject

- IModeled
### APackageData

- INamed
### Armor

- IKeyworded
- INamed
- IObjectBounded
- IWeightValue
### ArmorModel

- IHasIcons
- IModeled
### ArtObject

- IModeled
- IObjectBounded
### BodyData

- IModeled
### BodyPart

- INamed
### BodyPartData

- IModeled
### Book

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### CameraShot

- IModeled
### Cell

- INamed
### Class

- INamed
### Climate

- IModeled
### CollisionLayer

- INamed
### ColorRecord

- INamed
### Container

- IModeled
- INamed
- IObjectBounded
### DestructionStage

- IModeled
### DialogTopic

- INamed
### Door

- IModeled
- INamed
- IObjectBounded
### DualCastData

- IObjectBounded
### Explosion

- IModeled
- INamed
- IObjectBounded
### Eyes

- INamed
### Faction

- INamed
### Flora

- IKeyworded
- IModeled
- INamed
- IObjectBounded
### Furniture

- IKeyworded
- IModeled
- INamed
- IObjectBounded
### Grass

- IModeled
- IObjectBounded
### Hazard

- IModeled
- INamed
- IObjectBounded
### HeadData

- IModeled
### HeadPart

- IModeled
- INamed
### IdleMarker

- IModeled
- IObjectBounded
### Impact

- IModeled
### Ingestible

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### Ingredient

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### Key

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### Keyword

- Keyword
### LeveledItem

- IObjectBounded
### LeveledNpc

- IModeled
- IObjectBounded
### LeveledSpell

- IObjectBounded
### Light

- IHasIcons
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### LoadScreen

- IHasIcons
### Location

- IKeyworded
- INamed
### MagicEffect

- IKeyworded
- INamed
### MapMarker

- INamed
### MaterialObject

- IModeled
### MaterialType

- INamed
### Message

- INamed
### MiscItem

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### MoveableStatic

- IModeled
- INamed
- IObjectBounded
### MovementType

- INamed
### Npc

- IKeyworded
- INamed
- IObjectBounded
### ObjectEffect

- INamed
- IObjectBounded
### PackageDataBool

- INamed
### PackageDataFloat

- INamed
### PackageDataInt

- INamed
### PackageDataLocation

- INamed
### PackageDataObjectList

- INamed
### PackageDataTarget

- INamed
### PackageDataTopic

- INamed
### Perk

- IHasIcons
- INamed
### Phoneme

- INamed
### Projectile

- IModeled
- INamed
- IObjectBounded
### Quest

- INamed
### QuestAlias

- IKeyworded
- INamed
### Race

- IKeyworded
- INamed
### RegionData

- IHasIcons
### RegionMap

- INamed
### SceneAction

- INamed
### ScenePhase

- INamed
### ScriptBoolListProperty

- INamed
### ScriptBoolProperty

- INamed
### ScriptEntry

- INamed
### ScriptFloatListProperty

- INamed
### ScriptFloatProperty

- INamed
### ScriptIntListProperty

- INamed
### ScriptIntProperty

- INamed
### ScriptObjectListProperty

- INamed
### ScriptObjectProperty

- INamed
### ScriptProperty

- INamed
### ScriptStringListProperty

- INamed
### ScriptStringProperty

- INamed
### Scroll

- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### Shout

- INamed
### SoulGem

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
- IWeightValue
### SoundCategory

- INamed
### SoundMarker

- IObjectBounded
### Spell

- IKeyworded
- INamed
- IObjectBounded
### Static

- IModeled
- IObjectBounded
### TalkingActivator

- IKeyworded
- IModeled
- INamed
- IObjectBounded
### TextureSet

- IObjectBounded
### Tree

- IModeled
- INamed
- IObjectBounded
### Water

- INamed
### Weapon

- IHasIcons
- IKeyworded
- IModeled
- INamed
- IObjectBounded
### WeaponBasicStats

- IWeightValue
### WordOfPower

- INamed
### Worldspace

- INamed
