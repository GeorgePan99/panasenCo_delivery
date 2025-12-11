namespace Result;

public sealed class Result<TData, TError>
{
    public bool IsSuccess { get; }
    public TData?  Data { get; }
    public TError? Error { get; }

    private Result(bool isSuccess, TData? data, TError? error)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
    }
    public static Result<TData, TError> Success()
    {
        return new(true, default, default);
    }
    public static Result<TData, TError> Success(TData data)
    {
        return new(true, data, default);
    }

    public static Result<TData, TError> Failure(TError error)
    {
        return new(false, default, error);
    }
    
}