namespace DogShelter.Domain.SeedWork
{
    public class AuditEntity : EntityBase, IEntityCanCreate, IEntityCanUpdate
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdateOn { get; set; }
        public string? LastUpdateBy { get; set; }
    }
}
