using AutoMapper;
using DogShelter.Domain;

namespace DogShelter.Application.SeedWork
{
    public class MediatrHandlerBase(IDogShelterRepository repository, IMapper mapper)
    {
        protected readonly IDogShelterRepository repository = repository;
        protected readonly IMapper mapper = mapper;
    }
}
