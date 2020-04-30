using AutoMapper;
using NHibernate;
using TesteYounder.Application.Interfaces.Repositories;
using TesteYounder.Domain.Entidades;
using TesteYounder.Infra.Data.Models;

namespace TesteYounder.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<ClienteModel, ClienteDataModel>, IClienteRepository
    {
        public ClienteRepository(ISessionFactory sessionFactory, IMapper mapper) : base(sessionFactory, mapper)
        {
        }
    }
}