namespace Mutagen.Bethesda.Plugins;

public enum ModType
{
    /// <summary>
    /// .esm
    /// </summary>
    Master,

    /// <summary>
    /// .esl
    /// </summary>
    Light,

    /// <summary>
    /// .esp
    /// </summary>
    Plugin,
}

public static class ModTypeExt
{
    public static string GetFileExtension(this ModType modType)
    {
        return modType switch
        {
            ModType.Master => Mutagen.Bethesda.Kernel.Constants.Esm,
            ModType.Light => Mutagen.Bethesda.Kernel.Constants.Esl,
            ModType.Plugin => Mutagen.Bethesda.Kernel.Constants.Esp,
            _ => throw new NotImplementedException()
        };
    }
}