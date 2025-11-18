using Entites;

namespace UseCases.Enterfaces;

public interface IUserService
{
    Task CreateAsync(User user, string password);
}