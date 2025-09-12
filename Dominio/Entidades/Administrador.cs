namespace MinimalApi.Dominio.Entidades;

public class Administrador
{
    public int Id { get; set; }

    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;

     public string Perfil { get; set; } = default!;
}