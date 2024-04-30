using MediatR;

namespace DogShelter.Application.Commands
{
    public class DeleteDogCommand : INotification
    {
        public ulong DogId { get; set; }
    }
}
