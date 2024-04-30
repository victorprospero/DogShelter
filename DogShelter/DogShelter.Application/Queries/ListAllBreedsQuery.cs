using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class ListAllBreedsQuery : IRequest<IEnumerable<BreedAppModel>?>
    {
    }
}
