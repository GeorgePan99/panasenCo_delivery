using Entites;
using UseCases.Dtos;
using UseCases.Enterfaces;

namespace UseCases.Classes;

public class Registration
{
    private readonly IUserService _userService;

    public Registration(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<User> CreateUser(UserRegistrationDto userCreateDto)
    {
        var newUser = new User { 
            UserName = userCreateDto.UserName, 
            Email = userCreateDto.Email
        };

        var result = await _userService.CreateAsync(newUser, userCreateDto.PasswordHash);
        return result;
    }
}
