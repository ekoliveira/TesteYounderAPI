using System;
using System.Collections.Generic;

namespace TesteYounder.Application.CasosDeUso.Cliente.Response
{
    public class ClienteResponse : CasoDeUsoResponseMessage
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }

        public ClienteResponse()
        {
        }

        public ClienteResponse(string message, bool error) : base(message, error)
        {
        }

        public ClienteResponse(IEnumerable<string> errors) : base(errors)
        {
        }
    }
}