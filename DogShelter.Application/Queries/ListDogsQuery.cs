using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class ListDogsQuery : IRequest<IEnumerable<DogDetailsAppModel>?>
    {
        public ulong? Id { get; set; }
        public string? Name { get; set; }
        public string? Breed { get; set; }
    }
}
