using DogShelter.Application.Models;
using MediatR;

namespace DogShelter.Application.Commands
{
    public class SaveDogCommand : INotification
    {
        public ulong? Id { get; set; }
        public string? Name { get; set; }
        public BreedAppModel? Breed { get; set; }
    }
}
