namespace SistemaPontoCego.Domain.Entities;

public class Itens_Pedido
{
    public int Id_Item { get; set; }
    public int Id_Pedido { get; set; }
    public int Id_Produto { get; set; }

    public int Quantidade { get; set; }
    public decimal Preco_Unitario { get; set; }
    public int Id_ItemPedido { get; set; }
}
  