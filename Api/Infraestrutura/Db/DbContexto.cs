using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using Microsoft.Extensions.Configuration;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration? _configuracaoAppSettings;

    // Construtor de produção
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }

    // Construtor para testes
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured && _configuracaoAppSettings != null)
        {
            var stringDeConexao = _configuracaoAppSettings.GetConnectionString("mysql");
            if (!string.IsNullOrEmpty(stringDeConexao))
            {
                optionsBuilder.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao));
            }
        }
    }
}
