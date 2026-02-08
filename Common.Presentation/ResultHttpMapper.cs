using Common.Presentation;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Mappings;

public enum HttpOperationStatus
{
    Get,
    Created,
    Deleted
}
public static class ResultHttpMapper
{
    public static IActionResult ToActionResult<T>(this Result<T, IError> result, HttpOperationStatus? status)
    {
        if (result.IsSuccess)
        {
            if (result.Data is null)
            {
                switch (status)
                {
                    case HttpOperationStatus.Get:
                        break;
                    case HttpOperationStatus.Created:
                        break;
                    case HttpOperationStatus.Deleted:
                        break;
                    case null:
                    // return 200;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(status), status, null);
                }
            }
        }

        return result.Error.ToActionResult();
    }
}