using Autofac;
using DogShelter.Infrastructure.Repositories;

namespace DogShelter.Infrastructure
{
    public class DogShelterInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DogShelterRepository>().AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
