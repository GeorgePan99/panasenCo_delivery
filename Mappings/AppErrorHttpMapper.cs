using Microsoft.AspNetCore.Mvc;
using Result;
using Mappings.DTOs;
using Microsoft.AspNetCore.Http;

namespace Mappings;


public static class AppErrorsHttpMapper
{
    public static IActionResult ToActionResult(
        this IReadOnlyCollection<AppError> errors)
    {
        var statusCode = ResolveStatusCode(errors);

        var response = new ErrorResponse(
            errors.Select(e => new ErrorItem(e.Code, e.Message)));

        return new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }

    private static int ResolveStatusCode(
        IReadOnlyCollection<AppError> errors)
    {
        if (errors.Any(e => e.Type == AppErrorType.Validation))
            return StatusCodes.Status400BadRequest;

        if (errors.Any(e => e.Type == AppErrorType.Unauthorized))
            return StatusCodes.Status401Unauthorized;

        if (errors.Any(e => e.Type == AppErrorType.Forbidden))
            return StatusCodes.Status403Forbidden;

        if (errors.Any(e => e.Type == AppErrorType.NotFound))
            return StatusCodes.Status404NotFound;

        if (errors.Any(e => e.Type == AppErrorType.Conflict))
            return StatusCodes.Status409Conflict;

        return StatusCodes.Status500InternalServerError;
    }
}



