using Autofac;
using TesteYounder.Application.Interfaces.Repositories;

namespace TesteYounder.Infra.CrossCutting.Ioc
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
               .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}