namespace DogShelter.Application.Models
{
    public class BreedAppModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Temperament { get; set; }
        public BreedHeightAppModel? Height { get; set; }
    }
}
