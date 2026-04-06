using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class LojaRepository : ILojaRepository
{
    private readonly AppDbContext _context;

    public LojaRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Loja> Listar()
    {
        return _context.Lojas.ToList();
    }

    public Loja? ObterPorId(int id)
    {
        return _context.Lojas.FirstOrDefault(l => l.Id_Loja == id);
    }

    public void Adicionar(Loja loja)
    {
        _context.Lojas.Add(loja);
        _context.SaveChanges();
    }

    public void Atualizar(Loja loja)
    {
        _context.Lojas.Update(loja);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var loja = ObterPorId(id);
        if (loja != null)
        {
            _context.Lojas.Remove(loja);
            _context.SaveChanges();
        }
    }

    public Loja Obter()
    {
        throw new NotImplementedException();
    }
}