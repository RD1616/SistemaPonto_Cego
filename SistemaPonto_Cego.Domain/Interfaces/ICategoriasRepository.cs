using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

public interface ICategoriasRepository
{
    List<Categoria> Listar();
}