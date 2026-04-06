namespace SistemaPontoCego.Domain.Entities;

public class Produto
{
    public int Id_Produto { get; set; }
    public string? Nome_Produto { get; set; }
    public int Id_Categoria { get; set; }
    public decimal Preco { get; set; }
}