namespace Mutagen.Bethesda.Starfield;

public partial class GetVMQuestVariableConditionData : IConditionStringParameter
{
    string? IConditionStringParameterGetter.FirstStringParameter => FirstUnusedStringParameter;

    string? IConditionStringParameterGetter.SecondStringParameter => SecondParameter;

    string? IConditionStringParameter.FirstStringParameter
    {
        get => FirstUnusedStringParameter;
        set => FirstUnusedStringParameter = value;
    }

    string? IConditionStringParameter.SecondStringParameter
    {
        get => SecondParameter;
        set => SecondParameter = value;
    }

    Condition.Function IConditionDataGetter.Function => Condition.Function.GetVMQuestVariable;

}

