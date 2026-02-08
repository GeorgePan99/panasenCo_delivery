using Microsoft.AspNetCore.Mvc;
using Result;
using Common.Presentation.DTOs;
using Microsoft.AspNetCore.Http;

namespace Common.Presentation;


public static class AppErrorsHttpMapper
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

    private static int ResolveStatusCode(IError error)
    {
        switch (error.Type)
        {
            case AppErrorType.Validation:
                break;
            case AppErrorType.NotFound:
                break;
            case AppErrorType.Conflict:
                break;
            case AppErrorType.Unauthorized:
                break;
            case AppErrorType.Forbidden:
                break;
            case AppErrorType.Unexpected:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return StatusCodes.Status500InternalServerError;
    }
}



