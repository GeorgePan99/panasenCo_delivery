using Result;
using UseCases.Dtos;
using UseCases.Classes;

namespace UseCases.Enterfaces;

public interface IRegistration
{
    public Task<Result<RegisterUserResult, AppError>> CreateUser(UserRegistrationDto userCreateDto);
}
