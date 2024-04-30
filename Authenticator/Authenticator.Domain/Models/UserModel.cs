namespace Authenticator.Domain.Models
{
    public class UserModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public IEnumerable<RoleModel>? Roles { get; set; }
    }
}
