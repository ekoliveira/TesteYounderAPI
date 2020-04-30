using TesteYounder.Infra.Data.Models;

namespace TesteYounder.Infra.Data.Mappings.Cliente
{
    public class ClienteMap : MapBase<ClienteDataModel>
    {
        public ClienteMap()
        {
            CreateIdColumn("Cliente", "Id");

            Map(m => m.Nome, "Nome");
            Map(m => m.Cpf, "Cpf");
            Map(m => m.Rg, "Rg");
            Map(m => m.DataNascimento, "DataNascimento");
        }
    }
}