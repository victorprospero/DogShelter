using DogShelter.Domain;

namespace DogShelter.Infrastructure;

internal class FilterByTemperament : IFilterQuery
{
    public IEnumerable<Dog> _query { get; set; }
    public string _filterParameter { get; set; }
    public FilterByTemperament(IEnumerable<Dog> query, string filterParameter)
    {
        _query = query;
        _filterParameter = filterParameter;
    }
    public IEnumerable<Dog> SetQueryByFilter()
    {
        if (!string.IsNullOrWhiteSpace(_filterParameter))
            _query = _query.Where(x => x.Temperament.Contains(_filterParameter));

        return _query;
    }
}
