using Entites;

namespace UseCases.Enterfaces;

public interface IUserService
{
    Task<User> CreateAsync(User user, string password);
}