namespace QuizApp.Domain.Common;

public class Error
{
    public int Code { get; set; }
    public string? Content { get; set; }

    public Error(int code)
    {
        Code = code;
    }
    
    public Error(int code, string? content)
    {
        Code = code;
        Content = content;
    }
}