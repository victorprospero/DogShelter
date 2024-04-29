using DogShelter.Domain.SeedWork;

namespace DogShelter.Domain.Entities
{
    public class Dog : AuditEntity
    {
        public ulong Id { get; set; }
        public string? Name { get; set; }
        public uint BreedId { get; set; }
        public virtual Breed? Breed { get; set; }
    }
}