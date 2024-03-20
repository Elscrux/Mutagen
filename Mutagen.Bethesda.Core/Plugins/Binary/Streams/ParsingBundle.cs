using Mutagen.Bethesda.Plugins.Masters;
using Mutagen.Bethesda.Plugins.Meta;
using Mutagen.Bethesda.Plugins.Utility;
using Mutagen.Bethesda.Strings;
using Mutagen.Bethesda.Strings.DI;

namespace Mutagen.Bethesda.Plugins.Binary.Streams;

/// <summary>
/// Class containing all the extra meta bits for parsing
/// </summary>
public sealed class ParsingBundle
{
    /// <summary>
    /// Game constants meta object to reference for header length measurements
    /// </summary>
    public GameConstants Constants { get; }

    /// <summary>
    /// MasterReferenceReader to reference while reading
    /// </summary>
    public IMasterReferenceCollection MasterReferences { get; }

    /// <summary>
    /// Optional RecordInfoCache to reference while reading
    /// </summary>
    public RecordTypeInfoCacheReader? RecordInfoCache { get; set; }

    /// <summary>
    /// Optional strings lookup to reference while reading
    /// </summary>
    public IStringsFolderLookup? StringsLookup { get; set; }

    /// <summary>
    /// Whether to do parallel work when possible
    /// </summary>
    public bool Parallel { get; set; }

    /// <summary>
    /// Tracker of whether within worldspace data section
    /// </summary>
    public bool InWorldspace { get; set; }

    /// <summary>
    /// Tracker of current major record version
    /// </summary>
    public ushort? FormVersion { get; set; }

    /// <summary>
    /// ModKey of the mod being parsed
    /// </summary>
    public ModKey ModKey { get; set; }

    public EncodingBundle Encodings { get; set; } = new(MutagenEncoding._1252, MutagenEncoding._1252);

    public Language TranslatedTargetLanguage { get; set; } = Language.English;

    public ParsingBundle(GameConstants constants, IMasterReferenceCollection masterReferences)
    {
        Constants = constants;
        MasterReferences = masterReferences;
    }

    public static implicit operator GameConstants(ParsingBundle bundle)
    {
        return bundle.Constants;
    }

    public void ReportIssue(RecordType? recordType, string note)
    {
        // Nothing for now.  Need to implement
    }

    public void Absorb(StringsReadParameters? stringsReadParameters)
    {
        if (stringsReadParameters == null) return;
        if (stringsReadParameters.TargetLanguage != null)
        {
            TranslatedTargetLanguage = stringsReadParameters.TargetLanguage.Value;
        }

        if (stringsReadParameters.NonLocalizedEncodingOverride == null)
        {
            var encodingProv = stringsReadParameters.EncodingProvider ?? MutagenEncoding.Default;
            Encodings = Encodings with
            {
                NonLocalized = encodingProv.GetEncoding(Constants.Release, TranslatedTargetLanguage)
            };
        }
        else
        {
            Encodings = Encodings with
            {
                NonLocalized = stringsReadParameters.NonLocalizedEncodingOverride
            };
        }

        if (stringsReadParameters.NonTranslatedEncodingOverride != null)
        {
            Encodings = Encodings with
            {
                NonTranslated = stringsReadParameters.NonTranslatedEncodingOverride
            };
        }
    }
}