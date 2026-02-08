namespace Common.Presentation.DTOs;

public sealed class ErrorResponse
{
    public IReadOnlyList<ErrorItem> Errors { get; }

    public ErrorResponse(IEnumerable<ErrorItem> errors)
    {
        Errors = errors.ToList();
    }
}