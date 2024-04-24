using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class GetDogQuery : IRequest<DogDetailsAppModel?>
    {
        public ulong Id { get; set; }
    }
}
