using Entites;
using UseCases.Dtos;
using UseCases.Enterfaces;

namespace UseCases.Classes;

public class Registration: IRegistration
{
    private readonly IUserService _userService;

    public Registration(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result> CreateUser(UserRegistrationDto userCreateDto)
    {
        var existingByEmail = await _userService.FindByEmailAsync(userCreateDto.Email);
        if (existingByEmail != null)
            return Result.Failure("User with such email already exists");
        
        var newUser = new User { 
            UserName = userCreateDto.UserName, 
            Email = userCreateDto.Email
        };

        var result = await _userService.CreateAsync(newUser, userCreateDto.Password);
        
        if (result.Succeeded) 
            return Result.Success();
        
        return Result.Failure(result.Errors.Select(e => e.Description).ToList());
    }
}
