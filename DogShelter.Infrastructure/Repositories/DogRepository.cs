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
    public class DogRepository(DogShelterContext dbContext) : RepositoryBase(dbContext), IDogRepository
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
            return (from a in dbContext.Dogs.Where(x => x.Id == id)
                   select new DogModel()
                   {
                       Id = a.Id,
                       Breed = a.Breed,
                       MaxHeight = a.MaxHeight,
                       MinHeight = a.MinHeight,
                       Name = a.Name,
                       Temperament = a.Temperament
                   }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DogModel>> ListDogsAsync(DogFilter filter)
        {
            ExpressionStarter<Dog> predicate = PredicateBuilder.New<Dog>(true);
            if (filter.Id.HasValue)
            {
                predicate = predicate.And(x => x.Id == filter.Id);
            }
            if (!string.IsNullOrEmpty(filter.Breed))
            {
                predicate = predicate.And(x => x.Breed.IndexOf(filter.Breed) > -1);
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                predicate = predicate.And(x => x.Name.IndexOf(filter.Name) > -1);
            }

            return await (from a in dbContext.Dogs.Where(predicate)
                          select new DogModel()
                          {
                              Id = a.Id,
                              Breed = a.Breed,
                              MaxHeight = a.MaxHeight,
                              MinHeight = a.MinHeight,
                              Name = a.Name,
                              Temperament = a.Temperament
                          }).ToListAsync();
        }

        public async Task<DogModel> SaveDogAsync(DogModel model)
        {
            Dog? dog = null;
            if (model.Id.HasValue) 
            {
                dog = await dbContext.Dogs.FirstOrDefaultAsync(d => d.Id == model.Id);
            }
            dog ??= base.New<Dog>();
            dog.MinHeight = model.MinHeight;
            dog.MaxHeight = model.MaxHeight;
            dog.Temperament = model.Temperament;
            dog.Breed = model.Breed;
            dog.Name = model.Name;
            base.CreateOrUpdateOnSave(dog);
            await base.SaveChangesAsync();
            model.Id = dog.Id;
            return model;
        }
    }
}
