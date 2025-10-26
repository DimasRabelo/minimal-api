using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using System.IO;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            // Carrega o appsettings.json do próprio projeto de teste
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            // Cria o DbContext passando a configuração
            return new DbContexto(configuration);
        }

        [TestInitialize]
        public void LimparTabela()
        {
            var contexto = CriarContextoDeTeste();
            // Limpa a tabela para testes limpos
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            var contexto = CriarContextoDeTeste();

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var service = new AdministradorServico(contexto);

            // Act
            service.Incluir(adm);

            // Assert
            var todos = service.Todos(1);
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual("teste@teste.com", todos[0].Email);
        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            var contexto = CriarContextoDeTeste();

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var service = new AdministradorServico(contexto);
            service.Incluir(adm);

            // Act
            var admDoBanco = service.BuscaPorId(adm.Id);

            // Assert
            Assert.IsNotNull(admDoBanco);
            Assert.AreEqual("teste@teste.com", admDoBanco.Email);
        }
    }
}
