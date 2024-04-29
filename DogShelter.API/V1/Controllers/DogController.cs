using AutoMapper;
using DogShelter.API.Helpers;
using DogShelter.API.V1.Models;
using DogShelter.API.V1.Models.Validators;
using DogShelter.API.V1.ValueObjects;
using DogShelter.Application.Commands;
using DogShelter.Application.Models;
using DogShelter.Application.Queries;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace DogShelter.API.V1.Controllers;

[Route("[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]/[action]")]
public class DogController(ILogger<DogController> logger, IMapper mapper, IMediator mediator) : DogShelterControllerBase<DogController>(logger, mapper, mediator)
{
    [HttpPost]
    public async Task<ValidationApiModel> SaveDog([FromBody] DogApiModel model)
    {
        ValidationApiModel result = new();
        ValidationResult validationResult = await new DogApiValidator().ValidateAsync(model);
        if (validationResult.IsValid)
        {
            IEnumerable<BreedAppModel>? breeds = await mediator.Send(new ListBreedsQuery() { Name = model.BreedName });
            if (breeds != null && breeds.Any())
            {
                SaveDogCommand command = mapper.Map<SaveDogCommand>(model);
                command.Breed = breeds.First();
                await mediator.Publish(command);
            }
            else
            {
                validationResult.Errors.Add(new ValidationFailure("BreedName", "Breed '" + model.BreedName + "' does not exists"));
            }
        }
        result.Messages = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
        return result;
    }

    [HttpGet]
    public async Task<DogDetailsApiModel> GetDog(ulong dogId)
    {
        GetDogQuery query = new() { Id = dogId };
        return mapper.Map<DogDetailsApiModel>(await mediator.Send(query));
    }
    [HttpGet]
    public async Task<IEnumerable<DogDetailsApiModel>> ListDogs([FromQuery] DogApiFilter filter)
    {
        ListDogsQuery query = mapper.Map<ListDogsQuery>(filter);
        return mapper.Map<IEnumerable<DogDetailsApiModel>>(await mediator.Send(query));
    }
    [HttpGet]
    public async Task<IEnumerable<BreedApiModel>> ListBreeds([FromQuery] BreedApiFilter filter)
    {
        ListBreedsQuery query = mapper.Map<ListBreedsQuery>(filter);
        return mapper.Map<IEnumerable<BreedApiModel>>(await mediator.Send(query));
    }
}
