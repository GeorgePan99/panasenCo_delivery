namespace Result;

public class ErrorList: IError
{
    private List<Error> _errors = new();
    public IReadOnlyList<Error> Errors => _errors;
    public ErrorType Type { get; }

    public ErrorList(ErrorType type, List<Error> errors)
    {
        Type = type;
        _errors.AddRange(errors);
    }
}