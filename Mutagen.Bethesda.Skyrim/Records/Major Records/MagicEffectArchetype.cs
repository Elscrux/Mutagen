using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Skyrim;

public partial class MagicEffectArchetype
{
    public enum TypeEnum
    {
        ValueModifier = 0,
        Script = 1,
        Dispel = 2,
        CureDisease = 3,
        Absorb = 4,
        DualValueModifier = 5,
        Calm = 6,
        Demoralize = 7,
        Frenzy = 8,
        Disarm = 9,
        CommandSummoned = 10,
        Invisibility = 11,
        Light = 12,
        Lock = 15,
        Open = 16,
        Bound = 17,
        SummonCreature = 18,
        DetectLife = 19,
        Telekinesis = 20,
        Paralysis = 21,
        Reanimate = 22,
        SoulTrap = 23,
        TurnUndead = 24,
        Guide = 25,
        WerewolfFeed = 26,
        CureParalysis = 27,
        CureAddiction = 28,
        CurePoison = 29,
        Concussion = 30,
        ValueAndParts = 31,
        AccumulateMagnitude = 32,
        Stagger = 33,
        PeakValueModifier = 34,
        Cloak = 35,
        Werewolf = 36,
        SlowTime = 37,
        Rally = 38,
        EnhanceWeapon = 39,
        SpawnHazard = 40,
        Etherealize = 41,
        Banish = 42,
        SpawnScriptedRef = 43,
        Disguise = 44,
        GrabActor = 45,
        VampireLord = 46,
    }

    public MagicEffectArchetype(TypeEnum type = TypeEnum.ValueModifier)
    {
        this.Type = type;
    }

    MagicEffectArchetype.TypeEnum IAMagicEffectArchetypeGetter.Type => Type;
    public override IFormLinkIdentifier AssociationKey => Association;
}
