﻿using System;
using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Fallout4
{
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
            Darkness = 13,
            Nighteye = 14,
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
            CureParalysis = 27,
            CureAddiction = 28,
            CurePoison = 29,
            Concussion = 30,
            Stimpack = 31,
            AccumulateMagnitude = 32,
            Stagger = 33,
            PeakValueModifier = 34,
            Cloak = 35,
            SlowTime = 37,
            Rally = 38,
            EnhanceWeapon = 39,
            SpawnHazard = 40,
            Etherealize = 41,
            Banish = 42,
            SpawnScriptedRef = 43,
            Disguise = 44,
            Damage = 45,
            Immunity = 46,
            PermanentReanimate = 47,
            Jetpack = 48,
            Chameleon = 49,
        }

        public virtual FormKey AssociationKey { get; set; } = FormKey.Null;

        public MagicEffectArchetype(TypeEnum type = TypeEnum.ValueModifier)
        {
            this.Type = type;
        }
    }

    namespace Internals
    {
        public partial class MagicEffectArchetypeBinaryOverlay
        {
            public MagicEffectArchetype.TypeEnum Type => throw new NotImplementedException();

            public FormKey AssociationKey => throw new NotImplementedException();

            public IFormLinkGetter<IActorValueInformationGetter> ActorValue => throw new NotImplementedException();
        }
    }
}