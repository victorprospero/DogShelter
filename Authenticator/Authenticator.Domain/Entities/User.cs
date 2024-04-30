namespace Authenticator.Domain.Entities
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual IEnumerable<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
