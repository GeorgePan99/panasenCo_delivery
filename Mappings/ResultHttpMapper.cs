using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Mappings;

public static class ResultHttpMapper
{
    public static IActionResult ToActionResult<T>(
        this Result<T, IError> result, HttpOperationStatus? status)
    {
        if (result.IsSuccess)
        {
            switch (status)
            {
                case HttpOperationStatus.Get:
                    return new OkObjectResult(result.Data);
                case HttpOperationStatus.Created:
                    return new CreatedResult(String.Empty, result.Data);
                case HttpOperationStatus.Deleted:
                    return new NoContentResult();
                case null:
                    return new OkObjectResult(null);
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        return result.Error!.ToActionResult();
    }
}
