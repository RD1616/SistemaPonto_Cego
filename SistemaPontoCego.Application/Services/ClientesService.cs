using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class ClientesService
{
    private readonly IClientesRepository _repo;

    public ClientesService(IClientesRepository repo)
    {
        _repo = repo;
    }

    public void Adicionar(Cliente cliente)
    {
        _repo.Adicionar(cliente);
    }

    public List<Cliente> Listar()
    {
        return _repo.Listar();
    }
}