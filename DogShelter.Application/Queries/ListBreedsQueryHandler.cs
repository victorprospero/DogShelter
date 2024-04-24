using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace DogShelter.Application.Queries
{
    public class ListBreedsQueryHandler(IDogRepository repository, IMapper mapper, IConfiguration configuration) : MediatrHandlerBase(repository, mapper), IRequestHandler<ListBreedsQuery, IEnumerable<BreedAppModel>?>
    {
        private readonly RestClient client = new(configuration.GetValue<string>("DogBreedApi"));

        public async Task<IEnumerable<BreedAppModel>?> Handle(ListBreedsQuery request, CancellationToken cancellationToken)
        {
            RestRequest restRequest = new("search", Method.Get);
            restRequest.AddObject(request);
            IEnumerable<BreedAppModel>? result = await client.GetAsync<IEnumerable<BreedAppModel>>(restRequest, cancellationToken);
            return result;
        }
    }
}
