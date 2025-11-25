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
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
    async public Task<IdentityResult> CreateAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }
}