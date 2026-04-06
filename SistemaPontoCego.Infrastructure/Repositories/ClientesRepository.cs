using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;
using SistemaPontoCego.Infrastructure.Data;

namespace SistemaPontoCego.Infrastructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly AppDbContext _context;

        public ClientesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Cliente> Listar()
        {
            return _context.Cliente.ToList();
        }

        public Cliente? ObterPorId(int id)
        {
            return _context.Cliente.FirstOrDefault(c => c.Id_Cliente == id);
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}