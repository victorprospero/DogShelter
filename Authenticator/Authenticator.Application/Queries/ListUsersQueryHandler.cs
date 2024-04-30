using Authenticator.Application.Models;
using Authenticator.Application.SeedWork;
using Authenticator.Domain;
using Authenticator.Domain.Models;
using AutoMapper;
using MediatR;

namespace Authenticator.Application.Queries
{
    public class ListUsersQueryHandler(IAuthenticatorRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), IRequestHandler<ListUsersQuery, IEnumerable<UserAppModel>?>
    {
        public async Task<IEnumerable<UserAppModel>?> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserModel> result = await repository.ListUsersAsync();
            return mapper.Map<IEnumerable<UserAppModel>>(result);
        }
    }
}
