namespace SistemaPontoCego.Domain.Entities;

public class Pedido
{
    public int Id_Pedido { get; set; }
    public int Id_Cliente { get; set; }
    public DateTime Data_Pedido { get; set; }
    public decimal Valor_Total { get; set; }
}