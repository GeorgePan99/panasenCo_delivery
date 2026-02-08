namespace Common.Presentation.DTOs;

public sealed class ErrorItem
{
    public string Code { get; }
    public string Message { get; }

    public ErrorItem(string code, string message)
    {
        Code = code;
        Message = message;
    }
}