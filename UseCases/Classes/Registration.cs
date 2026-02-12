using System.Diagnostics;
using Entites;
using UseCases.Dtos;
using UseCases.Enterfaces;
using Result;

namespace UseCases.Classes;

public class Registration: IRegistration
{
    private readonly IUserService _userService;

    public Registration(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result<RegisterUserResult, IError>> CreateUser(UserRegistrationDto userCreateDto)
    {
        var existingByEmail = await _userService.FindByEmailAsync(userCreateDto.Email);
        if (existingByEmail != null)
            return new Error("ExistingError",
                         "User with such email already exists", 
                                  ErrorType.Conflict);
        
        var newUser = new User { 
            UserName = userCreateDto.UserName, 
            Email = userCreateDto.Email
        };
        
        var identityResult = await _userService.CreateAsync(newUser, userCreateDto.Password);

        if (!identityResult.Succeeded)
        {
            return new Error(
                "Unidentified error", 
                "Something went wrong", 
                ErrorType.Unexpected);
        }
        
        return new RegisterUserResult(newUser.Id);
    }
}
