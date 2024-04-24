using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class GetDogQueryHandler(IDogRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), IRequestHandler<GetDogQuery, DogDetailsAppModel?>
    {
        public async Task<DogDetailsAppModel?> Handle(GetDogQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<DogDetailsAppModel>(await repository.GetDogAsync(request.Id));
        }
    }
}