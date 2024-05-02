using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;
using DogShelter.Infrastructure.Contexts;
using DogShelter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Tests;

public class DogFilteringTests : IDisposable
{
    private readonly DogShelterRepository repository;
    private DogModel[] dogDummyList = [];
    public DogFilteringTests() 
    {
        DogShelterContext context = new DogShelterContext(new DbContextOptionsBuilder<DogShelterContext>().UseInMemoryDatabase("DogShelter").Options);
        repository = new DogShelterRepository(context);
    }

    private async Task PersistDummyDogList()
    {
        if (dogDummyList.Length == 0) 
            dogDummyList = await DogDummyList.Create(repository);
    }

    [Fact]
    public async Task Returns_Full_Dog_List_When_Fitlers_Are_Null()
    {
        //Arrange
        DogFilter filter = new();

        //Act
        await PersistDummyDogList();
        IEnumerable<DogModel> result = await repository.ListDogsAsync(filter);

        //Assert
        Assert.Equal(dogDummyList.Length, result.Count());
    }

    [Fact]
    public async Task Returns_1_Snoopy_Dog_From_List_When_Filter_Is_Snoopy()
    {
        //Arrange
        int expectedSmallSizesCount = 1;
        DogFilter filter = new() { DogName = "Snoopy" };

        //Act
        await PersistDummyDogList();
        IEnumerable<DogModel> result = await repository.ListDogsAsync(filter);

        //Assert
        Assert.Equal(expectedSmallSizesCount, result.Count());
    }

    [Fact]
    public async Task Returns_2_Medium_Dogs_From_List_When_Filter_Is_Medium()
    {
        //Arrange
        int expectedMediumSizesCount = 2;
        DogFilter filter = new DogFilter { BreedName = "Medium Dog" };

        //Act
        await PersistDummyDogList();
        IEnumerable<DogModel> result = await repository.ListDogsAsync(filter);

        //Assert
        Assert.Equal(expectedMediumSizesCount, result.Count());
    }

    [Fact]
    public async Task Returns_1_Large_Dog_From_List_When_Filter_Is_Large()
    {
        //Arrange
        int expectedBigSizesCount = 1;
        DogFilter filter = new DogFilter { BreedName = "Big Dog" };

        //Act
        await PersistDummyDogList();
        IEnumerable<DogModel> result = await repository.ListDogsAsync(filter);

        //Assert
        Assert.Equal(expectedBigSizesCount, result.Count());
    }

    public async void Dispose()
    {
        foreach (var dog in dogDummyList)
        {
            await repository.DeleteDogAsync(dog.Id ?? 0);
        }
    }
}
