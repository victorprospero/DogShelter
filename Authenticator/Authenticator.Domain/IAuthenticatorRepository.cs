using Authenticator.Domain.Models;

namespace Authenticator.Domain
{
    public interface IAuthenticatorRepository
    {
        Task CreateSampleDatabaseAsync();
        Task<IEnumerable<UserModel>> ListUsersAsync();
        Task<UserModel?> GetUserAsync(string eMail, string password);
    }
}
