using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

namespace SistemaPontoCego.Infrastructure.Repositories
{
    public class TamanhosRepository : ITamanhosRepository
    {
        private readonly AppDbContext _context;

        public TamanhosRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Tamanho> Listar()
        {
            return _context.Tamanho.ToList();
        }

        public Tamanho? ObterPorId(int id)
        {
            return _context.Tamanho
                .FirstOrDefault(t => t.Id_Tamanho == id);
        }

        public void Adicionar(Tamanho tamanho)
        {
            _context.Tamanho.Add(tamanho);
            _context.SaveChanges();
        }

        public void Atualizar(Tamanho tamanho)
        {
            _context.Tamanho.Update(tamanho);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var tamanho = _context.Tamanho
                .FirstOrDefault(t => t.Id_Tamanho == id);

            if (tamanho != null)
            {
                _context.Tamanho.Remove(tamanho);
                _context.SaveChanges();
            }
        }
    }
}