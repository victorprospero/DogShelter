using DogShelter.Domain;

namespace DogShelter.Infrastructure;

public interface IFilterQuery
{
    IEnumerable<Dog> SetQueryByFilter();
}
