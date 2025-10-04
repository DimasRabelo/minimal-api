using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOS;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);

    Administrador? Incluir(Administrador administrador);

    Administrador? BuscaPorId(int id);

     List<Administrador>Todos(int? pagina);
     

}