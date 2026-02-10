using Microsoft.AspNetCore.Mvc;
using Result;
using Microsoft.AspNetCore.Http;

namespace Mappings;


public static class ErrorsHttpMapper
{
    public static IActionResult ToActionResult(
        this IError error)
    {
        var statusCode = ResolveStatusCode(error);

        return new ObjectResult(error)
        {
            StatusCode = statusCode
        };
    }

    private static int ResolveStatusCode(
        IError error)
    {
        switch (error.Type)
        {
            case ErrorType.Validation:
                return StatusCodes.Status400BadRequest;
                break;
            case ErrorType.NotFound:
                return StatusCodes.Status404NotFound;
                break;
            case ErrorType.Conflict:
                return StatusCodes.Status409Conflict;
                break;
            case ErrorType.Unauthorized:
                return StatusCodes.Status401Unauthorized;
                break;
            case ErrorType.Forbidden:
                return StatusCodes.Status403Forbidden;
                break;
            case ErrorType.Unexpected:
                return StatusCodes.Status500InternalServerError;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
