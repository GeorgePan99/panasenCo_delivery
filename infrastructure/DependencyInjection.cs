using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Enterfaces;
using Entites;

namespace infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IUserService, UserService>()
            .AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5433;Database=db;Username=user;Password=12345"))
            .AddIdentityCore<User>();
            

        return services;
    }
}
