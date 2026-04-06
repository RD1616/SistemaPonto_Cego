namespace SistemaPontoCego.Domain.Interfaces;


public interface IEstoqueRepository
{
    void AtualizarEstoque(int produtoId, int quantidade);
}