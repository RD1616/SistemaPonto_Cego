namespace SistemaPontoCego.Domain.Entities;

public class Cliente
{
    public int Id_Cliente { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}