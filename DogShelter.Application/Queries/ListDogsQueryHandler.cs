using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using DogShelter.Domain.ValueObjects;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class ListDogsQueryHandler(IDogRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), IRequestHandler<ListDogsQuery, IEnumerable<DogDetailsAppModel>?>
    {
        public async Task<IEnumerable<DogDetailsAppModel>?> Handle(ListDogsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<DogDetailsAppModel>>(await repository.ListDogsAsync(mapper.Map<DogFilter>(request)));
        }
    }
}