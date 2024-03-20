namespace Mutagen.Bethesda.Starfield;

public partial class GetGraphVariableFloatConditionData : IConditionStringParameter
{
    string? IConditionStringParameterGetter.FirstStringParameter => FirstParameter;

    string? IConditionStringParameterGetter.SecondStringParameter => SecondUnusedStringParameter;

    string? IConditionStringParameter.FirstStringParameter
    {
        get => FirstParameter;
        set => FirstParameter = value;
    }

    string? IConditionStringParameter.SecondStringParameter
    {
        get => SecondUnusedStringParameter;
        set => SecondUnusedStringParameter = value;
    }

    Condition.Function IConditionDataGetter.Function => Condition.Function.GetGraphVariableFloat;

}

