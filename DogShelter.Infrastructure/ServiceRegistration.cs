using DogShelter.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace DogShelter.Infrastructure;
public static class ServiceRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IInMemoryDogRepository, InMemoryDogRepository>();
        services.AddScoped<IExternalBreedRepository, ExternalBreedRepository>();

        return services;
    }

    public static IServiceCollection AddHttpClientFactory(this IServiceCollection services)
    {
        services.AddHttpClient("Breeds", httpclient =>
        {
            httpclient.BaseAddress = new Uri("https://api.thedogapi.com/v1/breeds/search");
            httpclient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        });

        return services;
    }
}