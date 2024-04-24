using DogShelter.Domain;
using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;
using DogShelter.Infrastructure.Contexts;
using DogShelter.Infrastructure.SeedWork;

namespace DogShelter.Infrastructure.Repositories
{
    public class DogRepository : RepositoryBase, IDogRepository
    {
        private readonly DogShelterContext dbContext;
        public DogRepository(DogShelterContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        //TODO: Implement these methods
        public Task DeleteDogAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<DogModel> GetDogAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DogModel>> ListDogsAsync(DogFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<DogModel> SaveDogAsync(DogModel model)
        {
            throw new NotImplementedException();
        }
    }
}
