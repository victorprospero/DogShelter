using Authenticator.Application.Models;
using MediatR;

namespace Authenticator.Application.Queries
{
    public class ListUsersQuery : IRequest<IEnumerable<UserAppModel>?>
    {
    }
}
