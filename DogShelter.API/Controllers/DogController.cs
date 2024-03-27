using DogShelter.Application;
using DogShelter.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.API.Controllers;

[ApiController]
public class DogController : ControllerBase
{
    private readonly IDogShelterService _dogShelterService;

    public DogController(IDogShelterService dogShelterService)
    {
        _dogShelterService = dogShelterService;
    }

    [HttpPost]
    [Route("api/dogs")]
    [ProducesResponseType(typeof(Dog), 201)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> NewDog(DogPayload dogPayload)
    {
        try
        {
            Dog? result = await _dogShelterService.AddDog(dogPayload);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("api/dogs")]
    [ProducesResponseType(typeof(Dog), 200)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Dog>> GetDogsByQueryParameter([FromQuery] DogQueryParameters queryParameters)
    {
        try
        {
            List<Dog?> result = await _dogShelterService.GetDogsByQueryParameter(queryParameters);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
