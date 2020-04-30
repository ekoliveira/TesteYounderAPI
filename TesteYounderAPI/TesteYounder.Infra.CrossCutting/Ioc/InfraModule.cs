using Autofac;
using TesteYounder.Infra.Data;
using TesteYounder.Infra.Data.Repositories;

namespace TesteYounder.Infra.CrossCutting.Ioc
{
    public class InfraModule : Module
    {
        private readonly string _connectionString;

        public InfraModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterAssemblyTypes(typeof(RepositoryBase<,>).Assembly)
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            var sessionFactory = NHibernateHelper.ConfigureSessionFactory(a =>
            {
                a.ConnectionString = _connectionString;
                a.DatabaseType = DatabaseType.mssql_12;
                a.ShowSql = false;
            });

            builder.Register(f => sessionFactory).SingleInstance();
        }
    }
}