﻿using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectEnhanceWeaponArchetype
    {
        public FormLink<IObjectEffectGetter> Association => this.AssociationKey.AsLink<IObjectEffectGetter>();

        IFormLink<IObjectEffectGetter> IMagicEffectEnhanceWeaponArchetype.Association => this.Association;
        IFormLinkGetter<IObjectEffectGetter> IMagicEffectEnhanceWeaponArchetypeGetter.Association => this.Association;

        public MagicEffectEnhanceWeaponArchetype()
            : base(TypeEnum.EnhanceWeapon)
        {
        }
    }

    public partial interface IMagicEffectEnhanceWeaponArchetype
    {
        new IFormLink<IObjectEffectGetter> Association { get; }
    }

    public partial interface IMagicEffectEnhanceWeaponArchetypeGetter
    {
        IFormLinkGetter<IObjectEffectGetter> Association { get; }
    }

    namespace Internals
    {
        public partial class MagicEffectEnhanceWeaponArchetypeBinaryOverlay
        {
            public IFormLinkGetter<IObjectEffectGetter> Association => this.AssociationKey.AsLink<IObjectEffectGetter>();
        }
    }
}