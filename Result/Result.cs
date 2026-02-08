namespace Result;

public sealed class Result<TData, TError>
{
    private readonly List<TError> _errors = new();
    
    public bool IsSuccess => _errors.Count == 0;
    public TData? Data { get; }
    public IReadOnlyList<TError> Errors => _errors;

    private Result(TData? data)
    {
        Data = data;
    }
    private Result(IEnumerable<TError> errors)
    {
        _errors.AddRange(errors);
    }

    public static Result<TData, TError> Success()
    {
        return new Result<TData, TError>(default(TData));
    }
    public static Result<TData, TError> Success(TData data)
    {
        return new(data);
    }

    public static Result<TData, TError> Failure(TError error)
    {
        return new(new[] {error});
    }
    public static Result<TData, TError> Failure(IEnumerable<TError> errors)
    {
        return new(errors);
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
