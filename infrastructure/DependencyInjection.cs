using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Enterfaces;
using Entites;
using Microsoft.Extensions.Configuration;

namespace infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration config)
    {
        services
            .AddTransient<IUserService, UserService>()
            .AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")))
            .AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationContext>();
            

        return services;
    }
}
