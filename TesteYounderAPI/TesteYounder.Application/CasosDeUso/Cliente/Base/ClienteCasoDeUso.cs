using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteYounder.Application.CasosDeUso.Cliente.Request;
using TesteYounder.Application.CasosDeUso.Cliente.Response;
using TesteYounder.Application.Interfaces.CasosDeUso;
using TesteYounder.Application.Interfaces.Repositories;
using TesteYounder.Domain.Entidades;

namespace TesteYounder.Application.CasosDeUso.Cliente.Base
{
    internal class ClienteCasoDeUso : IClienteCasoDeUso
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IValidator<InserirClienteRequest> _inserirClienteValidator;
        private readonly IValidator<AlterarClienteRequest> _alterarClienteValidator;
        private readonly IMapper _mapper;

        public ClienteCasoDeUso(IClienteRepository ClienteRepository,
           IValidator<InserirClienteRequest> inserirClienteValidator,
           IValidator<AlterarClienteRequest> alterarClienteValidator,
           IMapper mapper)
        {
            _ClienteRepository = ClienteRepository;
            _inserirClienteValidator = inserirClienteValidator;
            _alterarClienteValidator = alterarClienteValidator;
            _mapper = mapper;
        }

        public async Task Inserir(InserirClienteRequest inserirCliente, IOutputPort<ClienteResponse> outputPort)
        {
            var validations = _inserirClienteValidator.Validate(inserirCliente);

            if (!validations.IsValid)
            {
                outputPort.Handler(new ClienteResponse(validations.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            var cli = _mapper.Map<ClienteModel>(inserirCliente);
            await _ClienteRepository.Inserir(cli);

            outputPort.Handler(_mapper.Map<ClienteResponse>(cli));
        }

        public async Task Alterar(AlterarClienteRequest alterarCliente, IOutputPort<ClienteResponse> outputPort)
        {
            var validations = _alterarClienteValidator.Validate(alterarCliente);

            if (!validations.IsValid)
            {
                outputPort.Handler(new ClienteResponse(validations.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            if (!await Existe(alterarCliente.Id, outputPort))
                return;

            var cli = _mapper.Map<ClienteModel>(alterarCliente);
            await _ClienteRepository.Alterar(cli);

            outputPort.Handler(_mapper.Map<ClienteResponse>(cli));
        }

        public async Task Excluir(int id, IOutputPort<ClienteResponse> outputPort)
        {
            if (!await Existe(id, outputPort))
                return;

            await _ClienteRepository.Excluir(id);
        }

        public async Task ObterPorId(int id, IOutputPort<ClienteResponse> outputPort)
        {
            var cli = await _ClienteRepository.ObterPorId(id);

            if (cli != null)
                outputPort.Handler(_mapper.Map<ClienteResponse>(cli));
        }

        public async Task ObterLista(IOutputPort<IEnumerable<ClienteResponse>> outputPort)
        {
            outputPort.Handler(_mapper.Map<IEnumerable<ClienteResponse>>(await _ClienteRepository.ObterLista()));
        }

        private async Task<bool> Existe(int id, IOutputPort<ClienteResponse> outputPort)
        {
            var existe = await _ClienteRepository.Existe(id);

            if (!existe)
                outputPort.Handler(new ClienteResponse("Id não encoontrado", true));

            return existe;
        }
    }
}