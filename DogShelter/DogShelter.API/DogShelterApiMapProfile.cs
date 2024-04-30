using AutoMapper;
using DogShelter.API.V1.Models;
using DogShelter.API.V1.ValueObjects;
using DogShelter.Application.Models;
using DogShelter.Application.Queries;

namespace DogShelter.API
{
    public class DogShelterApiMapProfile : Profile
    {
        public DogShelterApiMapProfile()
        {
            CreateMap<BreedAppModel, BreedApiModel>();
            CreateMap<DogApiFilter, ListDogsQuery>();

            CreateMap<BreedAppModel, BreedDetailApiModel>()
                .ForMember(a => a.HeightAverage, b => b.MapFrom(c => c.Height.HeightAverage))
                .ForMember(a => a.Size, b => b.MapFrom(c => c.Height.SizeCategory.ToString()));

            CreateMap<DogAppModel, DogApiModel>();
        }
    }
}
