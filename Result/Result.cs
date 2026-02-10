namespace Result;

public sealed class Result<TData, TError> where TError: IError
{
    public bool IsSuccess { get; }
    public TData? Data { get; }
    public TError? Error { get; }

    private Result(bool isSuccess, TData? data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }
    private Result(bool isSuccess, TError error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result<TData, TError> Success()
    {
        return new Result<TData, TError>(true, default(TData));
    }
    public static Result<TData, TError> Success(TData data)
    {
        return new(true, data);
    }

    public static Result<TData, TError> Failure(TError error)
    {
        return new(false, error);
    }

    public static implicit operator Result<TData, TError>(TData data)
    {
        return Success(data);
    }

    public static implicit operator Result<TData, TError>(TError error)
    {
        return Failure(error);
    }
}
