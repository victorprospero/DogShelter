namespace DogShelter.API.V1.ValueObjects
{
    public class DogApiFilter
    {
        public ulong? DogId { get; set; }
        public string? DogName { get; set; }
        public string? BreedName { get; set; }
    }
}
