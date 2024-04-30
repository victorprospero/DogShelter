using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class ListDogsQuery : IRequest<IEnumerable<DogAppModel>?>
    {
        public ulong? DogId { get; set; }
        public string? DogName { get; set; }
        public uint? BreedId { get; set; }
        public string? BreedName { get; set; }
    }
}
