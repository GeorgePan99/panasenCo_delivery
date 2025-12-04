using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Entites;


public class Result
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }

    protected Result(bool isSuccess,  List<string>? errors = null)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? new List<string>();
    }
    public static Result Success() => 
        new(true);
    public static Result Failure(string error) => 
        new(false, new  List<string> { error });

    public static Result Failure(List<string> errors) =>
        new(false, errors);
}

public class Result<T>: Result
{
    public T Value { get; }

    protected Result(bool isSuccess, T value, List<string>? errors = null)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => 
        new(true, value);
    public static Result<T> Failure(string error) => 
        new(false, default, new List<string>  {error});
    public static Result<T> Failure(List<string> errors) =>
        new(false, default, errors);
}
