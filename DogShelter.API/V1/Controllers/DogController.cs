using AutoMapper;
using DogShelter.API.Helpers;
using DogShelter.API.V1.Models;
using DogShelter.API.V1.ValueObjects;
using DogShelter.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.API.V1.Controllers;

[Route("[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]/[action]")]
public class DogController(ILogger logger, IMapper mapper, IMediator mediator) : DogShelterControllerBase(logger, mapper, mediator)
{
    [HttpPost]
    public async Task SaveDog(DogApiModel model)
    {
        //fluent validations
        // 1 valida inputs
        // 2 valida se o breed foi encontrado
        // 3 salva o dog
    }

    [HttpGet]
    public async Task<DogDetailsApiModel> GetDog(ulong dogId)
    {
        try
        {
            logger.LogInformation("Calling DogController.GetDog");
            GetDogQuery query = new() { Id = dogId };
            return mapper.Map<DogDetailsApiModel>(await mediator.Send(query));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error on DogController.GetDog");
            throw;
        }
    }
    [HttpGet]
    public async Task<IEnumerable<DogDetailsApiModel>> ListDogs(DogApiFilter filter)
    {
        try
        {
            logger.LogInformation("Calling DogController.ListDogs");
            ListDogsQuery query = mapper.Map<ListDogsQuery>(filter);
            return mapper.Map<IEnumerable<DogDetailsApiModel>>(await mediator.Send(query));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error on DogController.ListDogs");
            throw;
        }
        }
    [HttpGet]
    public async Task<IEnumerable<BreedApiModel>> ListBreeds(BreedApiFilter filter)
    {
        logger.LogInformation("Calling DogController.ListBreeds");
        try
        {
            ListBreedsQuery query = mapper.Map<ListBreedsQuery>(filter);
            return mapper.Map<IEnumerable<BreedApiModel>>(await mediator.Send(query));
        } 
        catch (Exception ex)
        {
            logger.LogError(ex, "Error on DogController.ListBreeds");
            throw;
        }
    }
}
