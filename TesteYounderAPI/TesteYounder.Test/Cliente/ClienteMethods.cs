using System;
using System.Collections.Generic;
using System.Linq;
using TesteYounder.Application.CasosDeUso.Cliente.Request;
using TesteYounder.Application.CasosDeUso.Cliente.Response;

namespace VoceFelizSys.Test.Cliente
{
    public class ClienteMethods
    {
        private List<ClienteResponse> lista = new List<ClienteResponse>();

        public ClienteMethods()
        {
            lista.Add(new ClienteResponse()
            {
                Id = 1,
                Cpf = "44243792801",
                DataNascimento = new DateTime(1994, 03, 19),
                Nome = "ERICK HENRIQUE DE OLIVEIRA",
                Rg = "460743181",
            }
            );

            lista.Add(new ClienteResponse()
            {
                Id = 2,
                Cpf = "44243792801",
                DataNascimento = new DateTime(1994, 03, 19),
                Nome = "CLAUDIA CARVALHO DOS SANTOS",
                Rg = "460743181",
            }
            );
        }

        public IEnumerable<ClienteResponse> ObterLista()
        {
            return lista;
        }

        public ClienteResponse ObterPorId(int id)
        {
            return lista.Where(x => x.Id == id).FirstOrDefault();
        }

        public ClienteResponse Inserir(InserirClienteRequest cliente)
        {
            var retorno = new ClienteResponse()
            {
                Id = 1,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Nome = cliente.Nome,
                Rg = cliente.Rg,
            };

            return retorno;
        }

        public ClienteResponse Alterar(AlterarClienteRequest cliente)
        {
            var clienteBase = lista.Where(x => x.Id == cliente.Id).FirstOrDefault();
            clienteBase.Id = cliente.Id;
            clienteBase.Cpf = cliente.Cpf;
            clienteBase.DataNascimento = (DateTime)cliente.DataNascimento;
            clienteBase.Nome = cliente.Nome;
            clienteBase.Rg = cliente.Rg;

            var retorno = new ClienteResponse()
            {
                Id = clienteBase.Id,
                Cpf = clienteBase.Cpf,
                DataNascimento = clienteBase.DataNascimento,
                Nome = clienteBase.Nome,
                Rg = clienteBase.Rg,
            };

            return retorno;
        }

        public ClienteResponse Excluir(int id)
        {
            var cliente = lista.Where(x => x.Id == id).FirstOrDefault();

            lista.Remove(cliente);

            return cliente;
        }
    }
}