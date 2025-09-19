using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;

        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;
        public object? IsConfigured { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var stringDeConexao = _configuracaoAppSettings.GetConnectionString("mysql");
                if (!string.IsNullOrEmpty(stringDeConexao))
                {
                    optionsBuilder.UseMySql(
                        stringDeConexao,
                        ServerVersion.AutoDetect(stringDeConexao)
                    );
                }
            }

        }
    }
}
