using Authenticator.Application.SeedWork;
using Authenticator.Domain;
using AutoMapper;
using MediatR;

namespace Authenticator.Application.Commands
{
    public class CreateSampleDatabaseCommandHandler(IAuthenticatorRepository repository, IMapper mapper) : MediatrHandlerBase(repository, mapper), INotificationHandler<CreateSampleDatabaseCommand>
    {
        public Task Handle(CreateSampleDatabaseCommand request, CancellationToken cancellationToken)
        {
            return repository.CreateSampleDatabaseAsync();
        }
    }
}
