using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;


public interface IProdutosRepository
{
    void Adicionar(Produto produto);
    List<Produto> Listar();
    void Remover(int id);
}