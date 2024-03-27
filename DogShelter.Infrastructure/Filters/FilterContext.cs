using DogShelter.Domain;

namespace DogShelter.Infrastructure;

internal class FilterContext
{
    private readonly IFilterQuery _filterQuery;
    public FilterContext(IFilterQuery filterQuery)
    {
        _filterQuery = filterQuery;
    }

    public IEnumerable<Dog> SetFilterByQuery()
    {
        return _filterQuery.SetQueryByFilter();
    }
}
