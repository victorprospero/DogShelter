using DogShelter.Domain;
using DogShelter.Domain.Models;

namespace DogShelter.Tests;

public static class DogDummyList
{
    public static async Task<DogModel[]> Create(IDogShelterRepository repository)
    {
        await repository.SaveBreedAsync(new BreedModel { Id = 1, MaxHeight = 100, MinHeight = 20, Temperament = "Angry", Name = "Big Dog" });
        await repository.SaveBreedAsync(new BreedModel { Id = 2, MaxHeight = 100, MinHeight = 20, Temperament = "Angry", Name = "Medium Dog" });
        await repository.SaveBreedAsync(new BreedModel { Id = 3, MaxHeight = 100, MinHeight = 20, Temperament = "Angry", Name = "Small Dog" });

        DogModel[] result = [new DogModel() { Name = "Bobby", BreedId = 1 },
                             new DogModel() { Name = "Snoopy", BreedId = 2 },
                             new DogModel() { Name = "Lassie", BreedId = 2 },
                             new DogModel() { Name = "Small", BreedId = 3 }];

        foreach (var dog in result)
        {
            await repository.SaveDogAsync(dog);
        }
        return result;
    }
}
