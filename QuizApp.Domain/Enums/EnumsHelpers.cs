namespace QuizApp.Domain.Enums;

public static class EnumsHelpers
{
    public static Array getEnumQuestionTypes()
    {
        var enums = Enum.GetValues(typeof(QuestionType));
        return enums;
    }

    public static QuestionType getEnumByIndex(int id)
    {
        if (id == 0)
        {
            return QuestionType.UNDEFINED;
        }
        if (id > Enum.GetValues(typeof(QuestionType)).Length)
        {
            return QuestionType.UNDEFINED;
        }
        return (QuestionType) id;
    }

    public static bool EnumIndexValidate(int id)
    {
        return id < Enum.GetValues(typeof(QuestionType)).Length;
    }
}