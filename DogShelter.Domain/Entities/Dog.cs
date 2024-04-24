using DogShelter.Domain.SeedWork;

namespace DogShelter.Domain.Entities
{
    public class Dog : AuditEntity
    {
        public ulong Id { get; set; }
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public string? Temperament { get; set; }
        public decimal? MinHeight { get; set; }
        public decimal? MaxHeight { get; set; }
    }
}