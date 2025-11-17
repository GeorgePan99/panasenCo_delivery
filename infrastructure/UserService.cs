using Entites;
using Microsoft.AspNetCore.Identity;
using UseCases.Enterfaces;


namespace infrastructure;

public class UserService: IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    async public Task<User> CreateAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return user;
    }
}