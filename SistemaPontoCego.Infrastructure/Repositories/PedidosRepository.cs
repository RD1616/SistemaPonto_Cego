using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class PedidosRepository : IPedidosRepository
{
    private readonly AppDbContext _context;

    public PedidosRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Pedido> Listar()
    {
        return _context.Pedido.ToList();
    }

    public Pedido? ObterPorId(int id)
    {
        return _context.Pedido.FirstOrDefault(p => p.Id_Pedido == id);
    }

    public void Adicionar(Pedido pedido)
    {
        _context.Pedido.Add(pedido);
        _context.SaveChanges();
    }

    public void Atualizar(Pedido pedido)
    {
        _context.Pedido.Update(pedido);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var pedido = ObterPorId(id);
        if (pedido != null)
        {
            _context.Pedido.Remove(pedido);
            _context.SaveChanges();
        }
    }

    public void CriarPedido(Pedido pedido)
    {
        throw new NotImplementedException();
    }
}