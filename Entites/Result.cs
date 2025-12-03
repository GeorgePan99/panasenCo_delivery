using System.Collections.Generic;

namespace Entites;


public class Result<T>
{
    public T Value { get; }
    public bool IsSuccess { get; }
    public List<string> Errors { get; }

    private Result(T value, bool isSuccess, List<string>? errors = null)
    {
        Value = value ?? default(T);
        IsSuccess = isSuccess;
        Errors = errors ?? new List<string>();
    }

    public static Result<T> Success(T value) =>
        new(value, true);
    
    public static Result<T> Failure(T value, string error) =>
        new(value, false, new List<string> { error });

    public static Result<T> Failure(T value, List<string> errors) =>
        new(value, false, errors);
    
}
