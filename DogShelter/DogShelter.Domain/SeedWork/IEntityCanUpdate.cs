namespace DogShelter.Domain.SeedWork
{
    public interface IEntityCanUpdate
    {
        public DateTime? LastUpdateOn { get; set; }
        public string? LastUpdateBy { get; set; }
    }
}
