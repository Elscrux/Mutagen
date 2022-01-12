using Loqui;
using Mutagen.Bethesda.Fallout4;

namespace Loqui
{
    public class ProtocolDefinition_Fallout4 : IProtocolRegistration
    {
        public readonly static ProtocolKey ProtocolKey = new ProtocolKey("Fallout4");
        void IProtocolRegistration.Register() => Register();
        public static void Register()
        {
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Fallout4MajorRecord_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Fallout4Mod_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Fallout4ModHeader_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ModStats_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Fallout4Group_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GameSetting_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GameSettingInt_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GameSettingFloat_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GameSettingString_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GameSettingBool_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GameSettingUInt_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.TransientType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.AttractionRule_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Keyword_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationReferenceType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ActionRecord_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Transform_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ObjectBounds_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Component_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Global_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.SoundDescriptor_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Decal_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.TextureSet_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GlobalInt_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GlobalShort_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GlobalFloat_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GlobalBool_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ActorValueInformation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ADamageType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.DamageType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.DamageTypeIndexed_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Properties_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Class_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Condition_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ConditionGlobal_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ConditionFloat_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ConditionData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationTargetRadius_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ALocationTarget_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationTarget_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationCell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationObjectId_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationObjectType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationKeyword_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LocationFallback_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Relation_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Cell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Faction_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.CrimeValues_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.VendorValues_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Rank_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.FormList_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Outfit_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.PlacedObject_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Door_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ColorRecord_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.HeadPart_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Part_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MaterialSwap_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.SimpleModel_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Model_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BipedBodyTemplate_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.AnimationSoundTagSet_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Race_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Debris_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Explosion_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ImpactDataSet_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LeveledSpell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.SoundMarker_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.SoundRepeat_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.AcousticSpace_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ReverbParameters_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Grass_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LandscapeTexture_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MaterialType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Effect_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.EffectData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MagicEffect_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ObjectEffect_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Destructible_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.DestructableData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.DestructionStage_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.DestructionStageData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.AVirtualMachineAdapter_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.VirtualMachineAdapter_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptEntry_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptObjectProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptStringProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptIntProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptFloatProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptBoolProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptObjectListProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptStringListProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptIntListProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptFloatListProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptBoolListProperty_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptFragment_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.IndexedScriptFragment_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ScriptFragments_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Activator_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.EquipType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Perk_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Spell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Water_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.TalkingActivator_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.VoiceType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BodyTemplate_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Icons_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Armor_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ArmorModel_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ArmorAddon_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ArtObject_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Footstep_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.FootstepSet_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.PreviewTransform_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ResistanceDestructible_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ArmorAddonModel_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ResistanceArmor_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BookTeachTarget_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BookActorValue_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BookPerk_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BookSpell_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.BookTeachesNothing_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Message_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MessageButton_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Quest_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Static_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Book_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ContainerEntry_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ContainerItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ExtraData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.OwnerTarget_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.NpcOwner_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.FactionOwner_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.NoOwner_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Container_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Npc_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.SoundOutputModel_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.NavigationMesh_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MiscItem_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MiscItemComponent_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.ComponentDisplayIndex_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.WeatherType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MusicTrack_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MusicTrackLoopData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MusicType_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MusicTypeData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Region_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionArea_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionData_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionDataHeader_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionSounds_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionSound_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionMap_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionObjects_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionObject_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionWeather_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionGrasses_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionGrass_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.RegionLand_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Weather_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Worldspace_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Ingredient_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Terminal_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.GodRays_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.LensFlare_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Light_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.StaticCollection_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.StaticPart_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.Placement_Registration.Instance);
            LoquiRegistration.Register(Mutagen.Bethesda.Fallout4.Internals.MoveableStatic_Registration.Instance);
        }
    }
}
