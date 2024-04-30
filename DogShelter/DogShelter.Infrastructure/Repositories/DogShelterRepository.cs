using DogShelter.Domain;
using DogShelter.Domain.Entities;
using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;
using DogShelter.Infrastructure.Contexts;
using DogShelter.Infrastructure.SeedWork;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Infrastructure.Repositories
{
    public class DogShelterRepository(DogShelterContext dbContext) : RepositoryBase(dbContext), IDogShelterRepository
    {
        private readonly DogShelterContext dbContext = dbContext;
        
        public async Task DeleteDogAsync(ulong id)
        {
            Dog? dog = await dbContext.Dogs.FirstOrDefaultAsync(d => d.Id == id);
            if (dog != null)
            {
                dbContext.Dogs.Remove(dog);
                await base.SaveChangesAsync();
            }
        }
        public Task<DogModel?> GetDogAsync(ulong id)
        {
            return (from a in dbContext.Dogs
                    join b in dbContext.Breeds on a.BreedId equals b.Id into bb
                    from b in bb
                    where a.Id == id
                    select new DogModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        BreedId = a.BreedId,
                        Breed = new BreedModel()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            MinHeight = b.MinHeight,
                            MaxHeight = b.MaxHeight,
                            Temperament = b.Temperament
                        }
                    }).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<BreedModel>> ListBreedsAsync(BreedFilter filter)
        {
            ExpressionStarter<Breed> predicate = PredicateBuilder.New<Breed>(true);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                predicate = predicate.And(x => x.Name != null && x.Name.IndexOf(filter.Name) > -1);
            }
            return await (from a in dbContext.Breeds.Where(predicate)
                          select new BreedModel()
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Temperament = a.Temperament,
                              MinHeight = a.MinHeight,
                              MaxHeight = a.MaxHeight
                          }).ToListAsync();
        }
        public async Task<IEnumerable<DogModel>> ListDogsAsync(DogFilter filter)
        {
            ExpressionStarter<Dog> predicateDog = PredicateBuilder.New<Dog>(true);
            ExpressionStarter<Breed> predicateBreed = PredicateBuilder.New<Breed>(true);

            if (filter.DogId.HasValue)
            {
                predicateDog = predicateDog.And(x => x.Id == filter.DogId.Value);
            }
            if (!string.IsNullOrEmpty(filter.DogName))
            {
                predicateDog = predicateDog.And(x => x.Name != null && x.Name.IndexOf(filter.DogName) > -1);
            }
            if (filter.BreedId.HasValue)
            {
                predicateBreed = predicateBreed.And(x => x.Id == filter.BreedId.Value);
            }
            if (!string.IsNullOrEmpty(filter.BreedName))
            {
                predicateBreed = predicateBreed.And(x => x.Name != null && x.Name.IndexOf(filter.BreedName) > -1);
            }

            return await (from a in dbContext.Dogs.Where(predicateDog)
                          join b in dbContext.Breeds.Where(predicateBreed) on a.BreedId equals b.Id into bb
                          from b in bb
                          select new DogModel()
                          {
                              Id = a.Id,
                              Name = a.Name
                          }).ToListAsync();
        }
        public async Task SaveBreedAsync(BreedModel model)
        {
            Breed? breed = await dbContext.Breeds.FirstOrDefaultAsync(b => b.Id == model.Id);
            if (breed == null)
            {
                breed = base.New<Breed>();
                base.CreateOnSave(breed);
            }
            else
            {
                base.UpdateOnSave(breed);
            }
            breed.Id = model.Id;
            breed.Name = model.Name;
            breed.Temperament = model.Temperament;
            breed.MinHeight = model.MinHeight;
            breed.MaxHeight = model.MaxHeight;
            await base.SaveChangesAsync();
        }
        public async Task<DogModel> SaveDogAsync(DogModel model)
        {
            Dog? dog = null;
            if (model.Id.HasValue) 
            {
                dog = await dbContext.Dogs.FirstOrDefaultAsync(d => d.Id == model.Id);
            }
            if (dog == null)
            {
                dog = base.New<Dog>();
                base.CreateOnSave(dog);
            } else
            {
                base.UpdateOnSave(dog);
            }
            dog.BreedId = model.BreedId ?? uint.MinValue;
            dog.Name = model.Name;
            await base.SaveChangesAsync();
            model.Id = dog.Id;
            return model;
        }
    }
}
