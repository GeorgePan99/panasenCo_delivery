using System.Collections.Generic;

namespace Entites;


public class Result
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }

    private Result(bool isSuccess, List<string>? errors = null)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? new List<string>();
    }

    public static Result Success() =>
        new Result(true);
    
    public static Result Failure(string error) =>
        new Result(false, new List<string> { error });

    public static Result Failure(List<string> errors) =>
        new Result(false, errors);
    
}
