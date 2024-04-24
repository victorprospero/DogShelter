using AutoMapper;
using DogShelter.Application.Commands;
using DogShelter.Application.Models;
using DogShelter.Application.Queries;
using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;

namespace DogShelter.Application
{
    public class DogShelterApplicationMapProfile : Profile
    {
        public DogShelterApplicationMapProfile()
        {
            CreateMap<SaveDogCommand, DogModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Temperament, b => b.MapFrom(c => c.Breed.Temperament))
                .ForMember(a => a.Breed, b => b.MapFrom(c => c.Breed.Name))
                .ForMember(a => a.MinHeight, b => b.MapFrom(c => decimal.Parse(c.Breed.Height.Metric.Substring(0, c.Breed.Height.Metric.IndexOf("-") ).Trim())))
                .ForMember(a => a.MaxHeight, b => b.MapFrom(c => decimal.Parse(c.Breed.Height.Metric.Substring(c.Breed.Height.Metric.IndexOf("-") + 1).Trim())));
            CreateMap<DogModel, DogDetailsAppModel>();
            CreateMap<ListDogsQuery, DogFilter>();
        }
    }
}