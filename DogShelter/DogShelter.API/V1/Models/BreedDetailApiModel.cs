namespace DogShelter.API.V1.Models
{
    public class BreedDetailApiModel : BreedApiModel
    {
        public string? Temperament { get; set; }
        public decimal? HeightAverage { get; set; }
        public string? Size { get; set; }
    }
}
