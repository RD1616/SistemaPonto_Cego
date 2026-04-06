using SistemaPontoCego.Domain.Entities;
using SistemaPontoCego.Domain.Interfaces;

public class LojaService
{
    private readonly ILojaRepository _repo;

    public LojaService(ILojaRepository repo)
    {
        _repo = repo;
    }

    public void Salvar(Loja loja)
    {
        var existente = _repo.Obter();

        if (existente == null)
            _repo.Adicionar(loja);
        else
            _repo.Atualizar(loja);
    }

    public Loja Obter()
    {
        return _repo.Obter();
    }
}