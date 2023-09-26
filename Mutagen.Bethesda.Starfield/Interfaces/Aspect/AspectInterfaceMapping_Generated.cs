/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections.Generic;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Plugins.Aspects;
using Loqui;

namespace Mutagen.Bethesda.Starfield
{
    internal class StarfieldAspectInterfaceMapping : IInterfaceMapping
    {
        public IReadOnlyDictionary<Type, InterfaceMappingResult> InterfaceToObjectTypes { get; }

        public GameCategory GameCategory => GameCategory.Starfield;

        public StarfieldAspectInterfaceMapping()
        {
            var dict = new Dictionary<Type, InterfaceMappingResult>();
            dict[typeof(IKeywordCommon)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Keyword_Registration.Instance,
            });
            dict[typeof(IKeywordCommonGetter)] = dict[typeof(IKeywordCommon)] with { Setter = false };
            dict[typeof(IKeyworded<IKeywordGetter>)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                KeywordFormComponent_Registration.Instance,
                Race_Registration.Instance,
            });
            dict[typeof(IKeywordedGetter<IKeywordGetter>)] = dict[typeof(IKeyworded<IKeywordGetter>)] with { Setter = false };
            dict[typeof(IModeled)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                AnimatedObject_Registration.Instance,
                BodyData_Registration.Instance,
                HeadPart_Registration.Instance,
                LegendaryItem_Registration.Instance,
                ModelComponent_Registration.Instance,
                PlanetModelComponent_Registration.Instance,
                SkeletalModel_Registration.Instance,
                StaticCollection_Registration.Instance,
                Weapon_Registration.Instance,
            });
            dict[typeof(IModeledGetter)] = dict[typeof(IModeled)] with { Setter = false };
            dict[typeof(INamed)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activity_Registration.Instance,
                Class_Registration.Instance,
                DamageType_Registration.Instance,
                FaceMorphItem_Registration.Instance,
                Faction_Registration.Instance,
                FullNameComponent_Registration.Instance,
                HeadPart_Registration.Instance,
                Keyword_Registration.Instance,
                MorphGroup_Registration.Instance,
                Planet_Registration.Instance,
                ProgressionEvaluatorArgument_Registration.Instance,
                Race_Registration.Instance,
                StaticCollection_Registration.Instance,
            });
            dict[typeof(INamedGetter)] = dict[typeof(INamed)] with { Setter = false };
            dict[typeof(INamedRequired)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activity_Registration.Instance,
                ActorValueModulation_Registration.Instance,
                BipedObjectData_Registration.Instance,
                Class_Registration.Instance,
                DamageType_Registration.Instance,
                FaceMorphItem_Registration.Instance,
                Faction_Registration.Instance,
                FullNameComponent_Registration.Instance,
                HeadPart_Registration.Instance,
                Keyword_Registration.Instance,
                MorphGroup_Registration.Instance,
                Planet_Registration.Instance,
                ProgressionEvaluatorArgument_Registration.Instance,
                Race_Registration.Instance,
                StaticCollection_Registration.Instance,
            });
            dict[typeof(INamedRequiredGetter)] = dict[typeof(INamedRequired)] with { Setter = false };
            dict[typeof(ITranslatedNamed)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activity_Registration.Instance,
                Class_Registration.Instance,
                DamageType_Registration.Instance,
                FaceMorphItem_Registration.Instance,
                Faction_Registration.Instance,
                FullNameComponent_Registration.Instance,
                HeadPart_Registration.Instance,
                Keyword_Registration.Instance,
                Race_Registration.Instance,
                StaticCollection_Registration.Instance,
            });
            dict[typeof(ITranslatedNamedGetter)] = dict[typeof(ITranslatedNamed)] with { Setter = false };
            dict[typeof(ITranslatedNamedRequired)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activity_Registration.Instance,
                Class_Registration.Instance,
                DamageType_Registration.Instance,
                FaceMorphItem_Registration.Instance,
                Faction_Registration.Instance,
                FullNameComponent_Registration.Instance,
                HeadPart_Registration.Instance,
                Keyword_Registration.Instance,
                Race_Registration.Instance,
                StaticCollection_Registration.Instance,
            });
            dict[typeof(ITranslatedNamedRequiredGetter)] = dict[typeof(ITranslatedNamedRequired)] with { Setter = false };
            dict[typeof(IObjectBounded)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                AudioOcclusionPrimitive_Registration.Instance,
                SoundEchoMarker_Registration.Instance,
                StaticCollection_Registration.Instance,
                TextureSet_Registration.Instance,
            });
            dict[typeof(IObjectBoundedGetter)] = dict[typeof(IObjectBounded)] with { Setter = false };
            dict[typeof(IObjectBoundedOptional)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                BendableSpline_Registration.Instance,
                LegendaryItem_Registration.Instance,
            });
            dict[typeof(IObjectBoundedOptionalGetter)] = dict[typeof(IObjectBoundedOptional)] with { Setter = false };
            dict[typeof(IPositionRotation)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                StaticPlacement_Registration.Instance,
                Transform_Registration.Instance,
            });
            dict[typeof(IPositionRotationGetter)] = dict[typeof(IPositionRotation)] with { Setter = false };
            InterfaceToObjectTypes = dict;
        }
    }
}

