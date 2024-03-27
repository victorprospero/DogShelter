using DogShelter.Domain;

namespace DogShelter.Infrastructure;

internal class FilterBySize : IFilterQuery
{
    public IEnumerable<Dog> _query { get; set; }
    public string _filterParameter{ get; set; }
    public FilterBySize(IEnumerable<Dog> query, string filterParameter)
    {
        _query = query;
        _filterParameter = filterParameter;
    }
    public IEnumerable<Dog> SetQueryByFilter()
    {
        if (!string.IsNullOrWhiteSpace(_filterParameter))
            _query = _query.Where(x => x.Size == _filterParameter);

        return _query;
    }
}
