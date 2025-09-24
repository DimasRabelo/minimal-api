using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOS;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
}