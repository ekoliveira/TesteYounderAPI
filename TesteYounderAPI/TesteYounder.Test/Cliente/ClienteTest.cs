using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TesteYounder.ApiProject.Controllers;
using TesteYounder.ApiProject.Response;
using TesteYounder.ApiProject.Serialization;
using TesteYounder.Application;
using TesteYounder.Application.CasosDeUso.Cliente.Request;
using TesteYounder.Application.CasosDeUso.Cliente.Response;
using TesteYounder.Application.Interfaces.CasosDeUso;
using VoceFelizSys.Test.Cliente;
using Xunit;

namespace TesteYounder.Test
{
    public class ClienteTest
    {
        private InserirClienteRequest inserirCliente = new InserirClienteRequest()
        {
            Cpf = "44243792801",
            DataNascimento = new DateTime(1994, 03, 19),
            Nome = "ERICK HENRIQUE DE OLIVEIRA",
            Rg = "460743181",
        };

        private AlterarClienteRequest alterarCliente = new AlterarClienteRequest()
        {
            Id = 1,
            Cpf = "44243792801",
            DataNascimento = new DateTime(1994, 03, 19),
            Nome = "ERICK H DE OLIVEIRA",
            Rg = "460743181",
        };

        [Fact(DisplayName = "Deve retornar clientes cadastrados")]
        public async void ObterLista()
        {
            // Arrange
            var _presenter = new Presenter()
            {
                ContentResult = new JsonContentResult()
                {
                    ContentType = "application/json",
                    Content = JsonSerializer.SerializeObject(new ClienteMethods().ObterLista()),
                    StatusCode = (int)HttpStatusCode.OK,
                }
            };

            var mockRepo = new Mock<IClienteCasoDeUso>();
            mockRepo.Setup(repo => repo.ObterLista(_presenter))
                .Returns(Task.FromResult(_presenter));

            var controller = new ClienteController(mockRepo.Object, _presenter);

            // Act
            var result = await controller.ObterLista();

            // Assert
            var viewResult = Assert.IsType<JsonContentResult>(result);

            var conteudo = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ClienteResponse>>(viewResult.Content);

            var listaDeClientes = Assert.IsAssignableFrom<IEnumerable<ClienteResponse>>(conteudo);

            Assert.True(listaDeClientes != null);
        }

        [Fact(DisplayName = "Deve retornar clientes por ID")]
        public async void ObterPorId()
        {
            // Arrange
            var _presenter = new Presenter()
            {
                ContentResult = new JsonContentResult()
                {
                    ContentType = "application/json",
                    Content = JsonSerializer.SerializeObject(new ClienteMethods().ObterPorId(1)),
                    StatusCode = (int)HttpStatusCode.OK,
                }
            };

            var mockRepo = new Mock<IClienteCasoDeUso>();
            mockRepo.Setup(repo => repo.ObterPorId(1, _presenter))
                .Returns(Task.FromResult(_presenter));

            var controller = new ClienteController(mockRepo.Object, _presenter);

            // Act
            var result = await controller.ObterPorId(1);

            // Assert
            var viewResult = Assert.IsType<JsonContentResult>(result);

            var conteudo = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteResponse>(viewResult.Content);

            var cliente = Assert.IsAssignableFrom<ClienteResponse>(conteudo);

            Assert.True(cliente != null);
        }

        [Fact(DisplayName = "Deve cadastrar um cliente")]
        public async void Inserir()
        {
            // Arrange
            var _presenter = new Presenter()
            {
                ContentResult = new JsonContentResult()
                {
                    ContentType = "application/json",
                    Content = JsonSerializer.SerializeObject(new ClienteMethods().Inserir(inserirCliente)),
                    StatusCode = (int)HttpStatusCode.OK,
                }
            };

            var mockRepo = new Mock<IClienteCasoDeUso>();
            mockRepo.Setup(repo => repo.Inserir(inserirCliente, _presenter))
                .Returns(Task.FromResult(_presenter));

            var controller = new ClienteController(mockRepo.Object, _presenter);

            // Act
            var result = await controller.Inserir(inserirCliente);

            // Assert
            var viewResult = Assert.IsType<JsonContentResult>(result);

            var conteudo = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteResponse>(viewResult.Content);

            var cliente = Assert.IsAssignableFrom<ClienteResponse>(conteudo);

            Assert.True(cliente != null);
        }

        [Fact(DisplayName = "Deve alterar um cliente")]
        public async void Alterar()
        {
            // Arrange
            var _presenter = new Presenter()
            {
                ContentResult = new JsonContentResult()
                {
                    ContentType = "application/json",
                    Content = JsonSerializer.SerializeObject(new ClienteMethods().Alterar(alterarCliente)),
                    StatusCode = (int)HttpStatusCode.OK,
                }
            };

            var mockRepo = new Mock<IClienteCasoDeUso>();
            mockRepo.Setup(repo => repo.Alterar(alterarCliente, _presenter))
                .Returns(Task.FromResult(_presenter));

            var controller = new ClienteController(mockRepo.Object, _presenter);

            // Act
            var result = await controller.Alterar(alterarCliente);

            // Assert
            var viewResult = Assert.IsType<JsonContentResult>(result);

            var conteudo = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteResponse>(viewResult.Content);

            var cliente = Assert.IsAssignableFrom<ClienteResponse>(conteudo);

            Assert.Equal(alterarCliente.Nome, cliente.Nome);
        }

        [Fact(DisplayName = "Deve excluir um cliente")]
        public async void Excluir()
        {
            // Arrange
            var _presenter = new Presenter()
            {
                ContentResult = new JsonContentResult()
                {
                    ContentType = "application/json",
                    Content = JsonSerializer.SerializeObject(new ClienteMethods().Excluir(1)),
                    StatusCode = (int)HttpStatusCode.OK,
                }
            };

            var mockRepo = new Mock<IClienteCasoDeUso>();
            mockRepo.Setup(repo => repo.Excluir(1, _presenter))
                .Returns(Task.FromResult(_presenter));

            var controller = new ClienteController(mockRepo.Object, _presenter);

            // Act
            var result = await controller.Excluir(1);

            // Assert
            var viewResult = Assert.IsType<JsonContentResult>(result);

            var conteudo = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteResponse>(viewResult.Content);

            var cliente = Assert.IsAssignableFrom<ClienteResponse>(conteudo);

            Assert.True(viewResult.StatusCode == (int)HttpStatusCode.OK);
        }
    }
}