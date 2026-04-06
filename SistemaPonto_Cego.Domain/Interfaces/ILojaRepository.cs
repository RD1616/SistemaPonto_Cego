using SistemaPontoCego.Domain.Entities;

namespace SistemaPontoCego.Domain.Interfaces;


public interface ILojaRepository
{
    void Adicionar(Loja loja);
    void Atualizar(Loja loja);
    Loja Obter();
}