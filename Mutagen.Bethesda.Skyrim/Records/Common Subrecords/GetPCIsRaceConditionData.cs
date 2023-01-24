namespace Mutagen.Bethesda.Skyrim;

public partial class GetPCIsRaceConditionData : IConditionStringParameter
{
    string? IConditionStringParameterGetter.FirstStringParameter => FirstUnusedStringParameter;

    string? IConditionStringParameterGetter.SecondStringParameter => SecondUnusedStringParameter;

    string? IConditionStringParameter.FirstStringParameter
    {
        get => FirstUnusedStringParameter;
        set => FirstUnusedStringParameter = value;
    }

    string? IConditionStringParameter.SecondStringParameter
    {
        get => SecondUnusedStringParameter;
        set => SecondUnusedStringParameter = value;
    }

}

internal partial class GetPCIsRaceConditionDataBinaryOverlay
{
    public string? FirstUnusedStringParameter => ParameterOneString;

    public string? SecondUnusedStringParameter => ParameterTwoString;

}
