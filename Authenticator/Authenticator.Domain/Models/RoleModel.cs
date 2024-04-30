namespace Authenticator.Domain.Models
{
    public class RoleModel
    {
        public uint? Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<UserModel>? Users { get; set; }
    }
}
