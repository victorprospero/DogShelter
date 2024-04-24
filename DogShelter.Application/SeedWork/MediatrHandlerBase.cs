using AutoMapper;
using DogShelter.Domain;

namespace DogShelter.Application.SeedWork
{
    public class MediatrHandlerBase(IDogRepository repository, IMapper mapper)
    {
        protected readonly IDogRepository repository = repository;
        protected readonly IMapper mapper = mapper;
    }
}
