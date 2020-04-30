using System;

namespace TesteYounder.Application.CasosDeUso.Cliente.Request
{
    public class InserirClienteRequest
    {
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Rg { get; set; }
        public virtual DateTime DataNascimento { get; set; }
    }
}