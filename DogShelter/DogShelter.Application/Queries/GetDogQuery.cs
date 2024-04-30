using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class GetDogQuery : IRequest<DogAppModel?>
    {
        public ulong Id { get; set; }
    }
}
