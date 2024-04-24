using DogShelter.Application.Enumerators;

namespace DogShelter.Application.Models
{
    public class DogDetailsAppModel : DogAppModel
    {
        public string? Temperament { get; set; }
        public decimal? MinHeight { get; set; }
        public decimal? MaxHeight { get; set; }
        public decimal? HeightAverage
        {
            get
            {
                return MinHeight.HasValue && MaxHeight.HasValue ? (MinHeight + MaxHeight) * 0.5m : null;
            }
        }
        public Size? SizeCategory
        {
            get
            {
                if (HeightAverage.HasValue)
                {
                    if (HeightAverage.Value < 35) return Size.Small;
                    if (HeightAverage.Value <= 55) return Size.Medium;
                    return Size.Large;
                }
                return null;
            }
        }
    }
}
