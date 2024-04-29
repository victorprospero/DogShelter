using AutoMapper;
using DogShelter.API.V1.Models;
using DogShelter.API.V1.ValueObjects;
using DogShelter.Application.Commands;
using DogShelter.Application.Models;
using DogShelter.Application.Queries;

namespace DogShelter.API
{
    public class DogShelterApiMapProfile : Profile
    {
        public DogShelterApiMapProfile()
        {
            CreateMap<DogApiFilter, ListDogsQuery>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.DogId))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.DogName))
                .ForMember(a => a.Breed, b => b.MapFrom(c => c.BreedName));

            CreateMap<DogAppModel, DogApiModel>()
                .ForMember(a => a.BreedName, b => b.MapFrom(c => c.Breed));

            CreateMap<DogDetailsAppModel, DogDetailsApiModel>()
                .ForMember(a => a.SizeCategory, b => b.MapFrom(c => c.SizeCategory.ToString()))
                .ForMember(a => a.BreedName, b => b.MapFrom(c => c.Breed));

            CreateMap<BreedApiFilter, ListBreedsQuery>();

            CreateMap<BreedAppModel, BreedApiModel>()
                .ForMember(a => a.HeightBounds, b => b.MapFrom(c => c.Height.Metric));

            CreateMap<DogApiModel, SaveDogCommand>();
        }
    }
}
