using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class CategoriasService
{
    private readonly ICategoriasRepository _repo;

    public CategoriasService(ICategoriasRepository repo)
    {
        _repo = repo;
    }

    public List<Categoria> Listar()
    {
        return _repo.Listar();
    }
}