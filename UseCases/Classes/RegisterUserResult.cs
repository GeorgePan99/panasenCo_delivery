namespace UseCases.Classes;

public sealed class RegisterUserResult
{
    public string Id { get; }
    public RegisterUserResult(string id)
    {
        Id = id;
    }
}