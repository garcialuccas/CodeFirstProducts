using ProdutosCodeFirst.Interfaces;
using ProdutosCodeFirst.Models;

namespace ProdutosCodeFirst.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Produto>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<Produto?> BuscarPorId(Guid id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task<Produto> Cadastrar(Produto produto)
        {
            if (produto.Preco < 0)
                throw new ArgumentException("O preço do produto não pode ser negativo.");

            if (produto.QtdeEstoque < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("O nome do produto não pode ser vazio.");

            return await _repository.Cadastrar(produto);
        }

        public async Task<Produto> Atualizar(Guid id, Produto produto)
        {
            if (produto.Id != id)
                throw new ArgumentException("O ID do produto não corresponde ao ID informado.");

            if (produto.Preco < 0)
                throw new ArgumentException("O preço do produto não pode ser negativo.");

            if (produto.QtdeEstoque < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("O nome do produto não pode ser vazio.");

            return await _repository.Atualizar(id, produto);
        }

        public async Task<Produto> Deletar(Guid id)
        {
            return await _repository.Deletar(id);
        }
    }
}
