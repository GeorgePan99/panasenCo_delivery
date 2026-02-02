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

    public async Task<Result<RegisterUserResult, AppError>> CreateUser(UserRegistrationDto userCreateDto)
    {
        var existingByEmail = await _userService.FindByEmailAsync(userCreateDto.Email);
        if (existingByEmail != null)
            return new AppError("ExistingError",
                         "User with such email already exists", 
                                  AppErrorType.Conflict);
        
        var newUser = new User { 
            UserName = userCreateDto.UserName, 
            Email = userCreateDto.Email
        };

        var identityResult = await _userService.CreateAsync(newUser, userCreateDto.Password);

        if (!identityResult.Succeeded)
        {
            return new AppError(
                "Unidentified error", 
                "Something went wrong", 
                AppErrorType.Unexpected);
        }
        
        return new RegisterUserResult(newUser.Id);
    }
}
