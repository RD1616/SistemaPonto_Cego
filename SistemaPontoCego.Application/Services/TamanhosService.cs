using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class TamanhosService
{
    private readonly ITamanhosRepository _repo;

    public TamanhosService(ITamanhosRepository repo)
    {
        _repo = repo;
    }

    public List<Tamanho> Listar()
    {
        return _repo.Listar();
    }
}