using ProdutosCodeFirst.Models;

namespace ProdutosCodeFirst.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> Listar();
        Task<Produto?> BuscarPorId(Guid id);
        Task<Produto> Cadastrar(Produto produto);
        Task<Produto> Atualizar(Guid id, Produto produto);
        Task<Produto> Deletar(Guid id);
    }
}
