namespace Mutagen.Bethesda.Fallout4;

public partial class GlobalFloat
{
    public const char TRIGGER_CHAR = 'f';
    char IGlobalGetter.TypeChar => TRIGGER_CHAR;

    public override float? RawFloat
    {
        get => this.Data;
        set => this.Data = value;
    }
}

partial class GlobalFloatBinaryOverlay
{
    char IGlobalGetter.TypeChar => GlobalFloat.TRIGGER_CHAR;
    public override float? RawFloat => this.Data;
}
