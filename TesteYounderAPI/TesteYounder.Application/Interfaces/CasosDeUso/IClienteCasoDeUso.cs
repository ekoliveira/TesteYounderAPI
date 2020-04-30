using System.Collections.Generic;
using System.Threading.Tasks;
using TesteYounder.Application.CasosDeUso.Cliente.Request;
using TesteYounder.Application.CasosDeUso.Cliente.Response;

namespace TesteYounder.Application.Interfaces.CasosDeUso
{
    public interface IClienteCasoDeUso
    {
        Task Inserir(InserirClienteRequest inserirCliente, IOutputPort<ClienteResponse> outputPort);

        Task Alterar(AlterarClienteRequest alterarCliente, IOutputPort<ClienteResponse> outputPort);

        Task Excluir(int id, IOutputPort<ClienteResponse> outputPort);

        Task ObterPorId(int id, IOutputPort<ClienteResponse> outputPort);

        Task ObterLista(IOutputPort<IEnumerable<ClienteResponse>> outputPort);
    }
}