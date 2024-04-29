using AutoMapper;
using DogShelter.API.Helpers;
using DogShelter.API.V1.Models;
using DogShelter.API.V1.ValueObjects;
using DogShelter.API.V1.ValueObjects.Validators;
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
public class DogShelterController(ILogger<DogShelterController> logger, IMapper mapper, IMediator mediator) : DogShelterControllerBase<DogShelterController>(logger, mapper, mediator)
{
    [HttpDelete]
    public Task DeleteDog(ulong dogId)
    {
        return mediator.Publish(new DeleteDogCommand() { DogId = dogId });
    }

    [HttpGet]
    public async Task<DogApiModel> GetDog(ulong dogId)
    {
        return mapper.Map<DogApiModel>(await mediator.Send(new GetDogQuery() { Id = dogId }));
    }

    [HttpGet]
    public async Task<IEnumerable<BreedApiModel>> ListAllBreeds()
    {
        return mapper.Map<IEnumerable<BreedApiModel>>(await mediator.Send(new ListAllBreedsQuery()));
    }

    [HttpGet]
    public async Task<IEnumerable<DogApiModel>> ListDogs([FromQuery] DogApiFilter filter)
    {
        return mapper.Map<IEnumerable<DogApiModel>>(await mediator.Send(mapper.Map<ListDogsQuery>(filter)));
    }
    
    [HttpPost]
    public async Task<ValidationApiModel> SaveDog([FromBody] SavingDogVO dog)
    {
        ValidationResult validationResult = await new SavingDogVOValidator().ValidateAsync(dog);
        if (validationResult.IsValid)
        {
            BreedAppModel? breed = await mediator.Send(new GetBreedQuery() { Name = dog.BreedName });
            if (breed != null)
            {
                await mediator.Publish(new SaveDogCommand()
                {
                    Id = dog.DogId,
                    Name = dog.DogName,
                    BreedId = breed.Id
                });
            }
            else
            {
                validationResult.Errors.Add(new ValidationFailure("BreedName", "Breed '" + dog.BreedName + "' not found"));
            }
        }
        return new ValidationApiModel()
        {
            Messages = validationResult.Errors.Select(x => x.ErrorMessage).ToArray()
        };
    }
}
