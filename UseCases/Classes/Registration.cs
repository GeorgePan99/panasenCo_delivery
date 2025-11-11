using Entites;
using Microsoft.AspNetCore.Identity;

namespace UseCases;

public class Registration
{
    private readonly UserManager<User> _userManager;

    public Registration(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Register(User user)
    {
        if (await _userManager.FindByNameAsync("admin") != null)
            return "User already exists";
        User newUser = new User
        {
            UserName = user.UserName,
            Email = user.Email
        };
        var result = await _userManager.CreateAsync(newUser, user.PasswordHash);
        if (result.Succeeded)
            return "User created";
        return "Failed to create user";
    }
}