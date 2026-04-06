using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

public class CoresRepository : ICoresRepository
{
    private readonly AppDbContext _context;

    public CoresRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Cor> Listar()
    {
        return _context.Cor.ToList();
    }

    public Cor? ObterPorId(int id)
    {
        return _context.Cor.FirstOrDefault(c => c.Id_Cor == id);
    }

    public void Adicionar(Cor cor)
    {
        _context.Cor.Add(cor);
        _context.SaveChanges();
    }

    public void Atualizar(Cor cor)
    {
        _context.Cor.Update(cor);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var cor = ObterPorId(id);
        if (cor != null)
        {
            _context.Cor.Remove(cor);
            _context.SaveChanges();
        }
    }
}