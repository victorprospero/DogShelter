using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace DogShelter.Application
{
    public class DogShelterApplicationModule : Module
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
