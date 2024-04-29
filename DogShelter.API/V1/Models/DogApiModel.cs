namespace DogShelter.API.V1.Models
{
    public class DogApiModel
    {
        public ulong? Id { get; set; }
        public string? Name { get; set; }
        public BreedDetailApiModel? Breed { get; set; }
    }
}
