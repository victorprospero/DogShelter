using Authenticator.Infrastructure.Repositories;
using Autofac;

namespace Authenticator.Infrastructure
{
    public class AuthenticatorInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticatorRepository>().AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
