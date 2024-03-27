using DogShelter.Domain;

namespace DogShelter.Application;

public interface IDogShelterService
{
    Task<Dog?> AddDog(DogPayload dogPayload);
    Task<List<Dog?>> GetDogsByQueryParameter(DogQueryParameters queryParameters);
}
