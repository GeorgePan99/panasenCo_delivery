using Entites;
using UseCases.Dtos;
using UseCases.Enterfaces;

namespace UseCases;

public class Registration
{
    private readonly IRepository<User> _userRepository;

    public Registration(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(UserRegistrationDto userCreateDto)
    {
        if (_userRepository.ExistsEmail(userCreateDto.Email))
            throw new InvalidOperationException("User with this email already exists");

        var newUser = new User(
            userCreateDto.UserName,
            userCreateDto.Email);
        
        var createdUser = _userRepository.Create(newUser,  userCreateDto.Password);
        return createdUser;
    }
}
