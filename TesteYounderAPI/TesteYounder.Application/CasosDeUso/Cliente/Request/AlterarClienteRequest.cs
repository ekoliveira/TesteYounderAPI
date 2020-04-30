using System;

namespace TesteYounder.Application.CasosDeUso.Cliente.Request
{
    public class AlterarClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}