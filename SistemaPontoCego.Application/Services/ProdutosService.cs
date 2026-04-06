using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class ProdutosService
{
    private readonly IProdutosRepository _repo;

    public ProdutosService(IProdutosRepository repo)
    {
        _repo = repo;
    }

    public void Adicionar(Produto produto)
    {
        if (string.IsNullOrEmpty(produto.Nome_Produto))
            throw new Exception("Nome do produto é obrigatório");

        _repo.Adicionar(produto);
    }

    public List<Produto> Listar()
    {
        return _repo.Listar();
    }

    public void Remover(int id)
    {
        _repo.Remover(id);
    }
}