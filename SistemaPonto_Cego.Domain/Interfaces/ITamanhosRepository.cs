using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;


public interface ITamanhosRepository
{
    List<Tamanho> Listar();
}