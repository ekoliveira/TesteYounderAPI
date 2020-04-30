using System;
using TesteYounder.Domain.Entidades.Base;

namespace TesteYounder.Domain.Entidades
{
    public class ClienteModel : DomainModel
    {
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Rg { get; set; }
        public virtual DateTime DataNascimento { get; set; }
    }
}