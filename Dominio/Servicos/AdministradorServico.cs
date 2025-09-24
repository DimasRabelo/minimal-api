using System.Linq;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOS;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    // Recebe "contexto" e armazena em _contexto
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        // Usa FirstOrDefault com predicate (lambda correto)
        var adm = _contexto.Administradores
            .FirstOrDefault(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);

        return adm;
    }
}
