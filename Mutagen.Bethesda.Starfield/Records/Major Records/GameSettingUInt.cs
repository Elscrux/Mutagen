using Mutagen.Bethesda.Plugins.Records;

namespace Mutagen.Bethesda.Starfield;

public partial class GameSettingUInt : IGameSettingNumeric
{
    public override GameSettingType SettingType => GameSettingType.UInt;

    public float? RawData
    {
        get => this.Data;
        set => this.Data = value.HasValue ? (uint)value.Value : default;
    }
}