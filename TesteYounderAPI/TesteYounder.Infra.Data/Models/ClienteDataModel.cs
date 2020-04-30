using System;
using TesteYounder.Infra.Data.Models.Base;

namespace TesteYounder.Infra.Data.Models
{
    public class ClienteDataModel : DataModel
    {
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Rg { get; set; }
        public virtual DateTime DataNascimento { get; set; }
    }
}