using DogShelter.Domain.SeedWork;

namespace DogShelter.Domain.Entities
{
    public class Breed : AuditEntity
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? Temperament { get; set; }
        public decimal? MinHeight { get; set; }
        public decimal? MaxHeight { get; set; }
        public virtual IEnumerable<Dog>? Dogs { get; set; }
    }
}
