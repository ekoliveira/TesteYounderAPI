using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteYounder.ApiProject.Response;
using TesteYounder.Application.CasosDeUso.Cliente.Request;
using TesteYounder.Application.Interfaces.CasosDeUso;

namespace TesteYounder.ApiProject.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteCasoDeUso _clienteCasoDeUso;
        private readonly Presenter _presenter;

        public ClienteController(IClienteCasoDeUso clienteCasoDeUso, Presenter presenter)
        {
            _clienteCasoDeUso = clienteCasoDeUso;
            _presenter = presenter;
        }

        [HttpPost]
        [Route(nameof(Inserir))]
        public async Task<IActionResult> Inserir([FromBody]InserirClienteRequest inserirCliente)
        {
            await _clienteCasoDeUso.Inserir(inserirCliente, _presenter);
            return _presenter.ContentResult;
        }

        [HttpPut]
        [Route(nameof(Alterar))]
        public async Task<IActionResult> Alterar([FromBody]AlterarClienteRequest alterarCliente)
        {
            await _clienteCasoDeUso.Alterar(alterarCliente, _presenter);
            return _presenter.ContentResult;
        }

        [HttpDelete]
        [Route(nameof(Excluir))]
        public async Task<IActionResult> Excluir(int id)
        {
            await _clienteCasoDeUso.Excluir(id, _presenter);
            return _presenter.ContentResult;
        }

        [HttpGet]
        [Route(nameof(ObterPorId))]
        public async Task<IActionResult> ObterPorId(int id)
        {
            await _clienteCasoDeUso.ObterPorId(id, _presenter);
            return _presenter.ContentResult;
        }

        [HttpGet]
        [Route(nameof(ObterLista))]
        public async Task<IActionResult> ObterLista()
        {
            await _clienteCasoDeUso.ObterLista(_presenter);
            return _presenter.ContentResult;
        }
    }
}