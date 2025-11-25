using Entites;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Classes;
using UseCases.Enterfaces;

namespace UseCases;

public static class DI
{
    public static IServiceCollection AddUsecasesServices(this IServiceCollection services)
    {
        services
            .AddTransient<IRegistration, Registration>();
        
        return services;
    }
}