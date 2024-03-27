using DogShelter.Domain;

namespace DogShelter.Infrastructure;

internal class FilterByBreed : IFilterQuery
{
    public IEnumerable<Dog> _query { get; set; }
    public string _filterParameter { get; set; }
    public FilterByBreed(IEnumerable<Dog> query, string filterParameter)
    {
        _query = query;
        _filterParameter = filterParameter;
    }
    public IEnumerable<Dog> SetQueryByFilter()
    {
        if (!string.IsNullOrWhiteSpace(_filterParameter))
            _query = _query.Where(x => x.Breed.Contains(_filterParameter));

        return _query;
    }
}