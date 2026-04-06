using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;

public interface IClientesRepository
{
    void Adicionar(Cliente cliente);
    List<Cliente> Listar();
}