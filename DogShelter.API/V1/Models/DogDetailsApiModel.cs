namespace DogShelter.API.V1.Models
{
    public class DogDetailsApiModel : DogApiModel
    {
        public string? Temperament { get; set; }
        public decimal? MinHeight { get; set; }
        public decimal? MaxHeight { get; set; }
        public decimal? HeightAverage { get; set; }
        public string? SizeCategory { get; set; }
    }
}
