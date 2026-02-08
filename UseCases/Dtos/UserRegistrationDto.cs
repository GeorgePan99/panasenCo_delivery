namespace UseCases.Dtos;

public class UserRegistrationDto
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}