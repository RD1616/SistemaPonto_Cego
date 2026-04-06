using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly AppDbContext _context;

    public EstoqueRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Estoque> Listar()
    {
        return _context.Estoque.ToList();
    }

    public Estoque? ObterPorId(int id)
    {
        return _context.Estoque.FirstOrDefault(e => e.Id_Estoque == id);
    }

    public void Adicionar(Estoque estoque)
    {
        _context.Estoque.Add(estoque);
        _context.SaveChanges();
    }

    public void Atualizar(Estoque estoque)
    {
        _context.Estoque.Update(estoque);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var estoque = ObterPorId(id);
        if (estoque != null)
        {
            _context.Estoque.Remove(estoque);
            _context.SaveChanges();
        }
    }

    public void AtualizarEstoque(int produtoId, int quantidade)
    {
        throw new NotImplementedException();
    }
}