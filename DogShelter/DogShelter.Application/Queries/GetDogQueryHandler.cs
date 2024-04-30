using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using MediatR;

namespace DogShelter.Application.Queries
{
    public class GetDogQueryHandler(IDogShelterRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), IRequestHandler<GetDogQuery, DogAppModel?>
    {
        public async Task<DogAppModel?> Handle(GetDogQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<DogAppModel>(await repository.GetDogAsync(request.Id));
        }
    }
}