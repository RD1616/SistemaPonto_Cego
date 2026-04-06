using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class PedidosService
{
    private readonly IPedidosRepository _repo;

    public PedidosService(IPedidosRepository repo)
    {
        _repo = repo;
    }

    public void Criar(Pedido pedido)
    {
        pedido.Data_Pedido = DateTime.Now;
        _repo.CriarPedido(pedido);
    }

    public List<Pedido> Listar()
    {
        return _repo.Listar();
    }
}