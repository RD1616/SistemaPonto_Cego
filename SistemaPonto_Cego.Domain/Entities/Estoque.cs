namespace SistemaPontoCego.Domain.Entities;

public class Estoque
{
    public int Id_Estoque { get; set; }
    public int Id_Produto { get; set; }
    public int Id_Tamanho { get; set; }
    public int Id_Cor { get; set; }
    public int Quantidade { get; set; }
}