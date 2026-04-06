using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class CoresService
{
    private readonly ICoresRepository _repo;

    public CoresService(ICoresRepository repo)
    {
        _repo = repo;
    }

    public List<Cor> Listar()
    {
        return _repo.Listar();
    }
}