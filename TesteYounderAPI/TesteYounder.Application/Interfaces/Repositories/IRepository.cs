using System.Collections.Generic;
using System.Threading.Tasks;
using TesteYounder.Domain.Entidades.Base;

namespace TesteYounder.Application.Interfaces.Repositories
{
    public interface IRepository<TDomainModel> where TDomainModel : IDomainModel
    {
        Task<IDomainModel> Inserir(TDomainModel obj);

        Task<TDomainModel> Alterar(TDomainModel obj);

        Task Excluir(int id);

        Task<TDomainModel> ObterPorId(int id);

        Task<IEnumerable<TDomainModel>> ObterLista();

        Task<bool> Existe(int id);
    }
}