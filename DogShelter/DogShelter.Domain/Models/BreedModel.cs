using DogShelter.Domain.SeedWork;

namespace DogShelter.Domain.Models
{
    public class BreedModel : ModelBase
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? Temperament { get; set; }
        public decimal? MinHeight { get; set; }
        public decimal? MaxHeight { get; set; }
        public IEnumerable<DogModel>? Dogs { get; set; }
    }
}
