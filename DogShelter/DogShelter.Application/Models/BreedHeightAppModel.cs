using DogShelter.Application.Enumerators;

namespace DogShelter.Application.Models
{
    public class BreedHeightAppModel
    {
        public string Metric { 
            set
            {
                string[] bounds = value.Split('-');
                MinHeight = decimal.Parse(bounds[0].Trim());
                try { MaxHeight = decimal.Parse(bounds[1].Trim()); } catch { }
            }
            get
            {
                return $"{MinHeight} - {MaxHeight}";
            }
        }

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
