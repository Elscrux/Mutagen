namespace Mutagen.Bethesda.Skyrim;

public partial class Static
{
    [Flags]
    public enum MajorFlag
    {
        NeverFades = 0x0000_0004,
        HasTreeLOD = 0x0000_0040,
        AddOnLODObject = 0x0000_0080,
        HiddenFromLocalMap = 0x0000_0200,
        HasDistantLOD = 0x0000_8000,
        UsesHdLodTexture = 0x0002_0000,
        HasCurrents = 0x0008_0000,
        IsMarker = 0x0080_0000,
        Obstacle = 0x0200_0000,
        NavMeshGenerationFilter = 0x0400_0000,
        NavMeshGenerationBoundingBox = 0x0800_0000,
        ShowInWorldMap = 0x1000_0000,
        NavMeshGenerationGround = 0x4000_0000,
    }

    [Flags]
    public enum Flag
    {
        ConsideredSnow = 0x01
    }
}