namespace Result;

public interface IError
{  
    public AppErrorType Type { get; }
}

public sealed class AppError: IError
{
    public string Code { get; }
    public string Message { get; }

    public AppError(string code, string message, AppErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public AppErrorType Type { get; }
}

public sealed class AppErrorList: IError
{
   public IList<AppError> Errors { get; set; }
   
   public AppErrorType Type { get; }
}

public sealed class AppErrorModelValidation: IError
{
    public Dictionary<string, AppError> Errors { get; set; }
    
    public AppErrorType Type { get; }
}