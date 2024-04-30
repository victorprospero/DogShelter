using DogShelter.Application;
using DogShelter.Domain.Models;
using DogShelter.Infrastructure.Obsolete.Repositories;

namespace DogShelter.Tests;

public class DogFilteringTests : IDisposable
{
    private InMemoryDogRepository _sut;
    private DummyDogList _dummyDogList = new DummyDogList();
    private List<DogModel> _dogList = new List<DogModel>();
    private List<DogModel?> result;

    public DogFilteringTests()
    {
        _dogList = _dummyDogList.CreateDummyDogList();
        _sut = new InMemoryDogRepository();

        SetDogListInInMemoryList();
    }

    private  async void SetDogListInInMemoryList()
    {
        if (result is null)
            result = new List<DogModel?>();

        foreach (var dog in _dogList)
            result.Add(await _sut.CreateAsync(dog));
    }

    [Fact]
    public async void Returns_Full_Dog_List_When_Fitlers_Are_Null()
    {
        //Arrange
        DogQueryParameters dogQueryParameters = new(null, null, null);

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(_dogList.Count, result.Count);
    }

    [Fact]
    public async void Returns_1_Small_Dogs_From_List_When_Filter_Is_Small()
    {
        //Arrange
        int expectedSmallSizesCount = 1;

        DogQueryParameters dogQueryParameters = new("Small", null, null);

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(expectedSmallSizesCount, result.Count);
    }

    [Fact]
    public async void Returns_2_Medium_Dogs_From_List_When_Filter_Is_Medium()
    {
        //Arrange
        int expectedMediumSizesCount = 2;
        DogQueryParameters dogQueryParameters = new("Medium", null, null);

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(expectedMediumSizesCount, result.Count);
    }

    [Fact]
    public async void Returns_1_Large_Dog_From_List_When_Filter_Is_Large()
    {
        //Arrange
        int expectedLargeSizesCount = 1;

        DogQueryParameters dogQueryParameters = new("Large", null, null);

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(expectedLargeSizesCount, result.Count);
    }

    [Fact]
    public async void Returns_1_Dog_When_Mixed_Query_Large_And_Doberman_Are_Applied()
    {
        //Arrange
        int expectedNumberOfDogs = 1;

        DogQueryParameters dogQueryParameters = new("Large", "Doberman", null);

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(expectedNumberOfDogs, result.Count);
    }

    [Fact]
    public async void Returns_2_Dogs_When_Temperament_Happy_Query_Is_Applied()
    {
        //Arrange
        int expectedNumberOfDogs = 2;
        DogQueryParameters dogQueryParameters = new(null, null, "Happy");

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(expectedNumberOfDogs, result.Count);
    }

    [Fact]
    public async void Returns_No_Dogs_When_Temperament_All_Queries_Dont_Match_Any_Dog()
    {
        //Arrange
        int expectedNumberOfDogs = 0;
        DogQueryParameters dogQueryParameters = new("Extra Large", "Doberman", "Happy2");

        //Act
        result = await _sut.GetDogByQueryParameterAsync(dogQueryParameters);

        //Assert
        Assert.Equal(expectedNumberOfDogs, result.Count);
    }

    public async void Dispose()
    {
        foreach (var dog in _dogList)
        {
            result.Remove(dog);
            await _sut.RemoveAsync(dog);
        }
    }
}
