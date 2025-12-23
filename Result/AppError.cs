namespace Result;

public class AppError
{
    public string Code { get; }
    public string Message { get; }
    public AppErrorType Type { get; }

    public AppError(string code, string message, AppErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }
}