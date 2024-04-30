using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using DogShelter.Domain.ValueObjects;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class ListDogsQueryHandler(IDogShelterRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), IRequestHandler<ListDogsQuery, IEnumerable<DogAppModel>?>
    {
        public async Task<IEnumerable<DogAppModel>?> Handle(ListDogsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<DogAppModel>>(await repository.ListDogsAsync(mapper.Map<DogFilter>(request)));
        }
    }
}