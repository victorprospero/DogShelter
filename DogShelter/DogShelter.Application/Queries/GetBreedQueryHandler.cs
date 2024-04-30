using AutoMapper;
using DogShelter.Application.Models;
using DogShelter.Application.SeedWork;
using DogShelter.Application.ValueObjects;
using DogShelter.Domain;
using DogShelter.Domain.Models;
using DogShelter.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Reflection;

namespace DogShelter.Application.Queries
{
    public class GetBreedQueryHandler(IDogShelterRepository repository, IMapper mapper, IConfiguration configuration) : MediatrHandlerBase(repository, mapper), IRequestHandler<GetBreedQuery, BreedAppModel?>
    {
        private readonly RestClient client = new(configuration.GetValue<string>("DogBreedApiBaseUrl") ?? string.Empty);
        public async Task<BreedAppModel?> Handle(GetBreedQuery request, CancellationToken cancellationToken)
        {
            BreedAppModel? result = mapper.Map<BreedAppModel>((await repository.ListBreedsAsync(mapper.Map<BreedFilter>(request))).FirstOrDefault(x => x.Name == request.Name));
            if (result == null)
            {
                RestRequest restRequest = new(configuration.GetValue<string>("DogBreedApiSearchMethod") ?? string.Empty, Method.Get);
                //restRequest.AddObject(mapper.Map<BreedsApiRequestParameters>(request)); // this is the correct way but didn´t worked
                BreedsApiRequestParameters parameters = mapper.Map<BreedsApiRequestParameters>(request);
                foreach (PropertyInfo property in parameters.GetType().GetProperties())
                {
                    restRequest.AddParameter(property.Name[..1].ToLower() + property.Name[1..], property.GetValue(parameters, null), ParameterType.QueryString);
                }
                result = (await client.GetAsync<IEnumerable<BreedAppModel>>(restRequest, cancellationToken))?.FirstOrDefault();

                if (result != null)
                {
                    await repository.SaveBreedAsync(mapper.Map<BreedModel>(result));
                }
            }
            return result;
        }
    }
}
