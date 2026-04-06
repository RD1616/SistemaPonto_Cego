using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class ItensPedidoRepository : IItens_PedidoRepository
{
    private readonly AppDbContext _context;

    public ItensPedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Itens_Pedido> Listar()
    {
        return _context.ItensPedido.ToList();
    }

    public Itens_Pedido? ObterPorId(int id)
    {
        return _context.ItensPedido.FirstOrDefault(i => i.Id_ItemPedido == id);
    }

    public void Adicionar(Itens_Pedido item)
    {
        _context.ItensPedido.Add(item);
        _context.SaveChanges();
    }

    public void Atualizar(Itens_Pedido item)
    {
        _context.ItensPedido.Update(item);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var item = ObterPorId(id);
        if (item != null)
        {
            _context.ItensPedido.Remove(item);
            _context.SaveChanges();
        }
    }

    public List<Itens_Pedido> ListarPorPedido(int pedidoId)
    {
        throw new NotImplementedException();
    }
}