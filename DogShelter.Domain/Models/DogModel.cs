using DogShelter.Domain.SeedWork;

namespace DogShelter.Domain.Models;
public class DogModel : ModelBase
{
    public ulong? Id { get; set; }
    public string? Name { get; set; }
    public uint? BreedId { get; set; }
    public BreedModel? Breed { get; set; }
}