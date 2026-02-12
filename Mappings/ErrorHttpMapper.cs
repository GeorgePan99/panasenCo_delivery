using Microsoft.AspNetCore.Mvc;
using Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Mappings;


public static class ErrorsHttpMapper
{
    public static IActionResult ToActionResult(
        this IError error)
    {
        Console.WriteLine(error.Type);
        var statusCode = ResolveStatusCode(error);

        return new ObjectResult(error)
        {
            
        };
    }

    private static IActionResult ResolveStatusCode(
        IError error)
    {
        switch (error.Type)
        {
            case ErrorType.Validation:
                return new BadRequestObjectResult(error);
            case ErrorType.NotFound:
                return new  NotFoundObjectResult(error);
            case ErrorType.Conflict:
                return new ConflictObjectResult(error);
            case ErrorType.Unauthorized:
                return new UnauthorizedObjectResult(error);
            case ErrorType.Forbidden:
                return new ForbidResult();
            case ErrorType.Unexpected:
                return new  StatusCodeResult(500);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
