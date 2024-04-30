using Authenticator.Domain;
using AutoMapper;

namespace Authenticator.Application.SeedWork
{
    public class MediatrHandlerBase(IAuthenticatorRepository repository, IMapper mapper)
    {
        protected readonly IAuthenticatorRepository repository = repository;
        protected readonly IMapper mapper = mapper;
    }
}
