using Moq;
using System.Threading.Tasks;
using TesteYounder.ApiProject.Controllers;
using TesteYounder.ApiProject.Response;
using TesteYounder.Application.Interfaces.CasosDeUso;
using Xunit;

namespace TesteYounder.Test
{
    public class ClienteTest
    {
        [Fact(DisplayName = "Deve retornar clientes cadastrados")]
        public async Task deve_retornar_clientes_cadastrados()
        {
            // Arrange
            var mockRepo = new Mock<IClienteCasoDeUso>();

            var controller = new ClienteController(mockRepo.Object, new Presenter());

            // Act
            var result = await controller.ObterLista();

            // Assert
            Assert.True(result != null);
        }

        [Fact(DisplayName = "Deve retornar cliente por id")]
        public async Task deve_retornar_autor_por_id()
        {
            // Arrange
            var mockRepo = new Mock<IClienteCasoDeUso>();

            var controller = new ClienteController(mockRepo.Object, new Presenter());

            // Act
            var result = await controller.ObterPorId(1);

            // Assert
            Assert.True(result != null);
        }
    }
}