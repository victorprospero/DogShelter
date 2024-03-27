using DogShelter.Domain;

namespace DogShelter.Application;

public class DogShelterService : IDogShelterService
{
    private readonly IInMemoryDogRepository _inMemoryDogRepository;
    private readonly IExternalBreedRepository _externalBreedApiRepository;

    public DogShelterService(IInMemoryDogRepository inMemoryRepository,IExternalBreedRepository externalApiRepository)
    {
        _inMemoryDogRepository = inMemoryRepository;
        _externalBreedApiRepository = externalApiRepository;
    }

    public async Task<Dog?> AddDog(DogPayload dogPayload)
    {
        BreedDTO breedDTO = await _externalBreedApiRepository.GetAsync(BreedFilterParametersConstants.QueryByName, dogPayload.Breed);
        Dog dog = Dog.NewDog(dogPayload.Name, dogPayload.Breed, breedDTO.Height, breedDTO.Temperament);
        return await _inMemoryDogRepository.CreateAsync(dog);
    }

    public async Task<List<Dog?>> GetDogsByQueryParameter(DogQueryParameters queryParameters)
    {
       return await _inMemoryDogRepository.GetDogByQueryParameterAsync(queryParameters);
    }
}
