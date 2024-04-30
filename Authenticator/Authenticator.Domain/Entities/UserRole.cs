namespace Authenticator.Domain.Entities
{
    public class UserRole
    {
        public string Email { get; set; } = string.Empty;
        public uint RoleId { get; set; }
        public virtual User User { get; set; } = new User();
        public virtual Role Role { get; set; } = new Role();
    }
}
