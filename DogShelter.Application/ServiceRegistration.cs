using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Application;
public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDogShelterService, DogShelterService>();
        return services;
    }
}