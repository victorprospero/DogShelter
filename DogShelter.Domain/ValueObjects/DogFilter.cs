namespace DogShelter.Domain.ValueObjects
{
    public class DogFilter
    {
        public ulong? DogId { get; set; }
        public string? DogName { get; set; }
        public uint ? BreedId { get; set; }
        public string? BreedName { get; set; }
    }
}
