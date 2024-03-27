using DogShelter.Application;
using DogShelter.Domain;

namespace DogShelter.Infrastructure;
public class InMemoryDogRepository : IInMemoryDogRepository
{
    private static ICollection<Dog> _inMemoryData = new List<Dog>();
    public Task<Dog> CreateAsync(Dog entity)
    {
        _inMemoryData.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<List<Dog>> GetDogByQueryParameterAsync(DogQueryParameters queryParameters)
    {
        FilterContext filterContext;

        if (_inMemoryData.Count == 0)
            return Task.FromResult(_inMemoryData.ToList());

        var query = _inMemoryData.AsEnumerable();

        filterContext = new FilterContext(new FilterBySize(query, queryParameters.Size));
        query = filterContext.SetFilterByQuery();

        filterContext = new FilterContext(new FilterByBreed(query, queryParameters.Breed));
        query = filterContext.SetFilterByQuery();

        filterContext = new FilterContext(new FilterByTemperament(query, queryParameters.Temperament));
        query = filterContext.SetFilterByQuery();

        return Task.FromResult(query.ToList());
    }

    public Task<Dog> RemoveAsync(Dog entity)
    {
        var dogToRemove = _inMemoryData.SingleOrDefault(r => r.Id == entity.Id);

        if (dogToRemove is null)
            throw new NullReferenceException("Dog does not exist");

        _inMemoryData.Remove(dogToRemove);
        return Task.FromResult(entity);
    }
}