using AutoMapper;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using DogShelter.Domain.Models;
using MediatR;

namespace DogShelter.Application.Commands
{
    public class SaveDogCommandHandler(IDogRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), INotificationHandler<SaveDogCommand>
    {
        public async Task Handle(SaveDogCommand notification, CancellationToken cancellationToken)
        {
            await repository.SaveDogAsync(mapper.Map<DogModel>(notification));
        }
    }
}
