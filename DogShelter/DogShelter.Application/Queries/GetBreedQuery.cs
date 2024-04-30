using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class GetBreedQuery : IRequest<BreedAppModel?>
    {
        public string? Name { get; set; }
    }
}
