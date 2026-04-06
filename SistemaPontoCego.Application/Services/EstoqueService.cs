using SistemaPontoCego.Domain.Interfaces;

public class EstoqueService
{
    private readonly IEstoqueRepository _repo;

    public EstoqueService(IEstoqueRepository repo)
    {
        _repo = repo;
    }

    public void Atualizar(int produtoId, int quantidade)
    {
        _repo.AtualizarEstoque(produtoId, quantidade);
    }
}