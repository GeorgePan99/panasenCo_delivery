using Entites;
using UseCases.Dtos;

namespace UseCases.Enterfaces;

public interface IRegistration
{
    public Task<Result<User>> CreateUser(UserRegistrationDto userCreateDto);
}
