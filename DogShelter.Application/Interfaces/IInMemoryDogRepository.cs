using DogShelter.Domain;

namespace DogShelter.Application;
public interface IInMemoryDogRepository
{
    Task<Dog> CreateAsync(Dog entity);
    Task<List<Dog>> GetDogByQueryParameterAsync(DogQueryParameters queryParameters);
    Task<Dog> RemoveAsync(Dog entity);
}