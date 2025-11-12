using Entites;

namespace UseCases.Enterfaces;

public interface IRepository<T>
    where T : class
{
    public bool ExistsEmail(string email);
    public User Create(User user, string password);
}