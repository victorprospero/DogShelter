using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class ListBreedsQuery : IRequest<IEnumerable<BreedAppModel>?>
    {
        public string? Name { get; set; }
    }
}
