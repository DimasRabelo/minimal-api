using System.Data.Common;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOS;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{

    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto _contexto)
    {
        _contexto = contexto;
    }
    public Administrador? Login(LoginDTO loginDTO)
    {
        var qtd = _contexto.Administradores.Where(a = > a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm; 
    
        
    }
    
}