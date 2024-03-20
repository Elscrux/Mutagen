using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Testing;

public static class TestConstants
{
    public static readonly ModKey PluginModKey = new ModKey("MutagenPluginKey", ModType.Plugin);
    public static readonly ModKey PluginModKey2 = new ModKey("MutagenPluginKey2", ModType.Plugin);
    public static readonly ModKey PluginModKey3 = new ModKey("MutagenPluginKey3", ModType.Plugin);
    public static readonly ModKey PluginModKey4 = new ModKey("MutagenPluginKey4", ModType.Plugin);
    public static readonly ModKey MasterModKey = new ModKey("MutagenMasterKey", ModType.Master);
    public static readonly ModKey MasterModKey2 = new ModKey("MutagenMasterKey2", ModType.Master);
    public static readonly ModKey MasterModKey3 = new ModKey("MutagenMasterKey3", ModType.Master);
    public static readonly ModKey MasterModKey4 = new ModKey("MutagenMasterKey4", ModType.Master);
    public static readonly ModKey LightModKey = new ModKey("MutagenLightMasterKey", ModType.Light);
    public static readonly ModKey LightModKey2 = new ModKey("MutagenLightMasterKey2", ModType.Light);
    public static readonly ModKey LightModKey3 = new ModKey("MutagenLightMasterKey3", ModType.Light);
    public static readonly ModKey LightModKey4 = new ModKey("MutagenLightMasterKey4", ModType.Light);
    public static readonly string Edid1 = "AnEdid1";
    public static readonly string Edid2 = "AnEdid2";
    public static readonly string Edid3 = "AnEdid2";
    public static readonly string UnusedEdid = "UnusedEdid";
    public static readonly FormKey Form1 = new FormKey(PluginModKey, 0x123456);
    public static readonly FormKey Form2 = new FormKey(PluginModKey, 0x12345F);
    public static readonly FormKey Form3 = new FormKey(PluginModKey, 0x223456);
    public static readonly FormKey Form4 = new FormKey(PluginModKey, 0x22345F);
    public static readonly FormKey UnusedForm = new FormKey(PluginModKey, 0x323456);
        
    public static readonly ModKey Skyrim = new ModKey("Skyrim", ModType.Master);
    public static readonly ModKey Update = new ModKey("Update", ModType.Master);
    public static readonly ModKey Dawnguard = new ModKey("Dawnguard", ModType.Master);
    public static readonly ModKey Hearthfires = new ModKey("HearthFires", ModType.Master);
    public static readonly ModKey Dragonborn = new ModKey("Dragonborn", ModType.Master);
        
    public static readonly ModKey Oblivion = "Oblivion.esm";
    public static readonly ModKey Knights = "Knights.esp";
}