using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class CategoriasRepository : ICategoriasRepository
{
    private readonly AppDbContext _context;

    public CategoriasRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Categoria> Listar()
    {
        return _context.Categoria.ToList();
    }

    public Categoria? ObterPorId(int id)
    {
        return _context.Categoria.FirstOrDefault(c => c.Id_Categoria == id);
    }

    public void Adicionar(Categoria categoria)
    {
        _context.Categoria.Add(categoria);
        _context.SaveChanges();
    }

    public void Atualizar(Categoria categoria)
    {
        _context.Categoria.Update(categoria);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var categoria = ObterPorId(id);
        if (categoria != null)
        {
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
        }
    }
}