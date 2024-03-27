namespace DogShelter.Application;
public interface IExternalBreedRepository
{
    Task<BreedDTO> GetAsync(string parameter, string value);
}
