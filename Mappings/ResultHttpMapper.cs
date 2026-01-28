using Microsoft.AspNetCore.Mvc;
using Result;
using Entites;
using Mappings.DTOs;

namespace Mappings;

public static class ResultHttpMapper
{
    public static IActionResult ToActionResult<T>(
        this Result<T, AppError> result)
    {
        if (result.IsSuccess)
        {
            return MapSuccess(result.Data);
        }

        return result.Error!.ToActionResult();
    }

    private static IActionResult MapSuccess<T>(T? data)
    {
        if (data is null)
            return new OkResult();

        if (data is User user)
        {
            return new CreatedResult(string.Empty,
                                     new UserRegistrationResponseDto
                                     {
                                         Id = user.Id,
                                     });
        }
        return new OkObjectResult(data);
    }
}