using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;

namespace DogShelter.Domain
{
    public interface IDogShelterRepository
    {
        Task DeleteDogAsync(ulong id);
        Task<DogModel?> GetDogAsync(ulong id);
        Task<IEnumerable<BreedModel>> ListBreedsAsync(BreedFilter filter);
        Task<IEnumerable<DogModel>> ListDogsAsync(DogFilter filter);
        Task SaveBreedAsync(BreedModel model);
        Task<DogModel> SaveDogAsync(DogModel model);
    }
}
