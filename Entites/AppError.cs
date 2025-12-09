namespace Entites;

public class AppError
{
    public string Code { get; }
    public string Message { get; }

    public AppError(string code, string message)
    {
        Code = code;
        Message = message;
    }
}