using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

public interface IPedidosRepository
{
    void CriarPedido(Pedido pedido);
    List<Pedido> Listar();
}