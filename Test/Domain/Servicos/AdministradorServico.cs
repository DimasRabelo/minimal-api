using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            // Cria IConfiguration a partir do appsettings.json que está no bin
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            // Usa o construtor interno do DbContexto (MySQL real)
            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            var contexto = CriarContextoDeTeste();

            // Limpa a tabela para teste limpo
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var service = new AdministradorServico(contexto);
            service.Incluir(adm);

            var todos = service.Todos(1);
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual("teste@teste.com", todos[0].Email);
        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var service = new AdministradorServico(contexto);
            service.Incluir(adm);

            var admDoBanco = service.BuscaPorId(adm.Id);
            Assert.IsNotNull(admDoBanco);
            Assert.AreEqual("teste@teste.com", admDoBanco.Email);
        }
    }
}
