using Authenticator.Application.Models;
using MediatR;

namespace Authenticator.Application.Queries
{
    public class GetUserQuery : IRequest<UserAppModel?>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
