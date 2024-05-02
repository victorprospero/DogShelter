using Authenticator.Application.Models;
using Authenticator.Application.SeedWork;
using Authenticator.Domain;
using AutoMapper;
using MediatR;

namespace Authenticator.Application.Queries
{
    public class GetUserQueryHandler(IAuthenticatorRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), IRequestHandler<GetUserQuery, UserAppModel?>
    {
        public async Task<UserAppModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<UserAppModel>(await repository.GetUserAsync(request.Email, request.Password));
        }
    }
}
