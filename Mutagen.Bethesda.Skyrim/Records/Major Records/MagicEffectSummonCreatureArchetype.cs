using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Skyrim
{
    public partial class MagicEffectSummonCreatureArchetype
    {
        public FormLink<INpcGetter> Association => this.AssociationKey.AsLink<INpcGetter>();

        IFormLink<INpcGetter> IMagicEffectSummonCreatureArchetype.Association => this.Association;
        IFormLinkGetter<INpcGetter> IMagicEffectSummonCreatureArchetypeGetter.Association => this.Association;

        public MagicEffectSummonCreatureArchetype()
            : base(TypeEnum.SummonCreature)
        {
        }
    }

    public partial interface IMagicEffectSummonCreatureArchetype
    {
        new IFormLink<INpcGetter> Association { get; }
    }

    public partial interface IMagicEffectSummonCreatureArchetypeGetter
    {
        IFormLinkGetter<INpcGetter> Association { get; }
    }

    namespace Internals
    {
        public partial class MagicEffectSummonCreatureArchetypeBinaryOverlay
        {
            public IFormLinkGetter<INpcGetter> Association => this.AssociationKey.AsLink<INpcGetter>();
        }
    }
}
