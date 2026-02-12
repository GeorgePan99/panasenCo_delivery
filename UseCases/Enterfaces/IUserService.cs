using Entites;
using Microsoft.AspNetCore.Identity;

namespace UseCases.Enterfaces;

public interface IUserService
{
    Task<IdentityResult> CreateAsync(User user, string password);
    Task<User?> FindByEmailAsync(string email);
}