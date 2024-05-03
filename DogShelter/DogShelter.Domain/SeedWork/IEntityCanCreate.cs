namespace DogShelter.Domain.SeedWork
{
    public interface IEntityCanCreate
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
