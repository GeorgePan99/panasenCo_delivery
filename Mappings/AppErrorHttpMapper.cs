using Microsoft.AspNetCore.Mvc;
using Result;

namespace Mappings;


public static class AppErrorHttpMapper
{
    public static IActionResult ToActionResult(this AppError error)
    {
        return error.Type switch
        {
            AppErrorType.Validation =>
                new BadRequestObjectResult(error),

            AppErrorType.NotFound =>
                new NotFoundObjectResult(error),

            AppErrorType.Conflict =>
                new ConflictObjectResult(error),

            AppErrorType.Unauthorized =>
                new UnauthorizedObjectResult(error),

            AppErrorType.Forbidden =>
                new ForbidResult(),

            _ =>
                new ObjectResult(error) { StatusCode = 500 }
        };
    }
}



