namespace Authenticator.Domain.Entities
{
    public class Role
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual IEnumerable<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
