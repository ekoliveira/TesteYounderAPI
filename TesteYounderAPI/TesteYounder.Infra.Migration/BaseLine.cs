using FluentMigrator;
using TesteYounder.Infra.Migration.Base;

namespace TesteYounder.Infra.Migration
{
    [MigrationBase(1, "Tools")]
    public class BaseLine : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Cliente")
                  .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                  .WithColumn("Nome").AsAnsiString(100).NotNullable()
                  .WithColumn("Cpf").AsAnsiString(11).NotNullable()
                  .WithColumn("Rg").AsAnsiString(9).NotNullable()
                  .WithColumn("DataNascimento").AsDateTime().NotNullable();

            Execute.Sql("INSERT INTO CLIENTE (NOME, CPF, RG, DATANASCIMENTO) " +
                        "VALUES ('Erick Henrique de Oliveira', '44243792801', '460743181', CONVERT(datetime,'19-03-1994',105))," +
                               "('Claudia Carvalho dos Santos', '39848358099', '507045804', CONVERT(datetime,'20-06-1990',105))");
        }

        public override void Down()
        {
            Delete.Table("Cliente");
        }
    }
}