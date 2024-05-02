using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Application.ValueObjects;
using DogShelter.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Reflection;

namespace DogShelter.Application.Queries
{
    public class ListAllBreedsQueryHandler(IDogShelterRepository repository, IMapper mapper, IConfiguration configuration) : MediatrHandlerBase(repository, mapper), IRequestHandler<ListAllBreedsQuery, IEnumerable<BreedAppModel>?>
    {
        private readonly RestClient client = new(configuration.GetValue<string>("DogBreedApi:BaseUrl") ?? string.Empty);

        public async Task<IEnumerable<BreedAppModel>?> Handle(ListAllBreedsQuery request, CancellationToken cancellationToken)
        {
            RestRequest restRequest = new(configuration.GetValue<string>("DogBreedApi:SearchMethod") ?? string.Empty, Method.Get);
            //restRequest.AddObject(new BreedsApiRequestParameters()); This is the correct way, but didn´t worked
            BreedsApiRequestParameters parameters = new BreedsApiRequestParameters();
            foreach (PropertyInfo property in parameters.GetType().GetProperties())
            {
                restRequest.AddParameter(property.Name[..1].ToLower() + property.Name[1..], property.GetValue(parameters, null), ParameterType.QueryString);
            }
            return await client.GetAsync<IEnumerable<BreedAppModel>>(restRequest, cancellationToken);
        }
    }
}
