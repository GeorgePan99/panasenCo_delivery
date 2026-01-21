using Microsoft.AspNetCore.Mvc;
using Result;

namespace Representation.Mappings;

public static class ResultHttpMapper
{
    public static IActionResult ToActionResult<T>(
        this Result<T, AppError> result)
    {
        if (result.IsSuccess)
        {
            return result.Data is null
                ? new OkResult()
                : new OkObjectResult(result.Data);
        }

        return result.Error!.ToActionResult();
    }
}