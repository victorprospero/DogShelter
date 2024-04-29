using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;

namespace DogShelter.Domain
{
    public interface IDogRepository
    {
        Task<DogModel?> GetDogAsync(ulong id);
        Task DeleteDogAsync(ulong id);
        Task<DogModel> SaveDogAsync(DogModel model);
        Task<IEnumerable<DogModel>> ListDogsAsync(DogFilter filter);
    }
}
