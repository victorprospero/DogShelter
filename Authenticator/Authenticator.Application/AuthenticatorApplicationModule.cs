using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Authenticator.Application
{
    public class AuthenticatorApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(MediatRConfigurationBuilder
                .Create(GetType().Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build());
            builder.RegisterAutoMapper(GetType().Assembly);
            base.Load(builder);
        }
    }
}
