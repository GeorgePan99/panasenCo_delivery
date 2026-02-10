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
            if (result.Data is null)
            {
                switch (status)
                {
                    case HttpOperationStatus.Get:
                        return new OkObjectResult(result.Data);
                        break;
                    case HttpOperationStatus.Created:
                        return new CreatedResult(String.Empty, result.Data);
                        break;
                    case HttpOperationStatus.Deleted:
                        return new NoContentResult();
                        break;
                    case null:
                        return new OkObjectResult(null);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(status), status, null);
                }
            }
        }

        return result.Error.ToActionResult();
    }
}
