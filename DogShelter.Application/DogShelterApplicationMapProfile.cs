using AutoMapper;
using DogShelter.Application.Commands;
using DogShelter.Application.Models;
using DogShelter.Application.Queries;
using DogShelter.Application.ValueObjects;
using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;

namespace DogShelter.Application
{
    public class DogShelterApplicationMapProfile : Profile
    {
        public DogShelterApplicationMapProfile()
        {
            CreateMap<SaveDogCommand, DogModel>();
            CreateMap<BreedModel, BreedAppModel>()
                .ForPath(a => a.Height.MaxHeight, b => b.MapFrom(c => c.MaxHeight))
                .ForPath(a => a.Height.MinHeight, b => b.MapFrom(c => c.MinHeight)).ReverseMap();
            CreateMap<DogModel, DogAppModel>();
            CreateMap<ListDogsQuery, DogFilter>();
            CreateMap<GetBreedQuery, BreedFilter>();
            CreateMap<GetBreedQuery, BreedsApiRequestParameters>();
        }
    }
}