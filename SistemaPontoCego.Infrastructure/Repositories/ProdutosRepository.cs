using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class ProdutosRepository : IProdutosRepository
{
    private readonly AppDbContext _context;

    public ProdutosRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Produto> Listar()
    {
        return _context.Produto.ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _context.Produto.FirstOrDefault(p => p.Id_Produto == id);
    }

    public void Adicionar(Produto produto)
    {
        _context.Produto.Add(produto);
        _context.SaveChanges();
    }

    public void Atualizar(Produto produto)
    {
        _context.Produto.Update(produto);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var produto = ObterPorId(id);
        if (produto != null)
        {
            _context.Produto.Remove(produto);
            _context.SaveChanges();
        }
    }
}