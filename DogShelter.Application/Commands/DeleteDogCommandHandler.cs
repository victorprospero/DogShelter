using AutoMapper;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using MediatR;

namespace DogShelter.Application.Commands
{
    public class DeleteDogCommandHandler(IDogShelterRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), INotificationHandler<DeleteDogCommand>
    {
        public Task Handle(DeleteDogCommand notification, CancellationToken cancellationToken)
        {
            return repository.DeleteDogAsync(notification.DogId);
        }
    }
}
