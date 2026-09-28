using Microsoft.EntityFrameworkCore;
using ProdutoCodeFirstAPI.Contexts;
using ProdutosCodeFirst.Interfaces;
using ProdutosCodeFirst.Models;

namespace ProdutosCodeFirst.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _ctx;

        public ProdutoRepository(ProdutoContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Produto> Atualizar(Guid id, Produto produto)
        {
            var produtoBuscado = await _ctx.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produtoBuscado != null)
            {
                produtoBuscado.Nome = produto.Nome;
                produtoBuscado.Marca = produto.Marca;
                produtoBuscado.Preco = produto.Preco;
                produtoBuscado.QtdeEstoque = produto.QtdeEstoque;
                produtoBuscado.Ativo = produto.Ativo;

                 _ctx.Produtos.Update(produtoBuscado);
                await _ctx.SaveChangesAsync();
                return produtoBuscado;
            }

            throw new ArgumentException("Produto não encontrado.");
        }

        public async Task<Produto?> BuscarPorId(Guid id)
        {
            return await _ctx.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produto> Cadastrar(Produto produto)
        {
            await _ctx.Produtos.AddAsync(produto);
            await _ctx.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Deletar(Guid id)
        {
            var produtoBuscado = await _ctx.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produtoBuscado != null)
            {
                _ctx.Produtos.Remove(produtoBuscado);
                await _ctx.SaveChangesAsync();
                return produtoBuscado;
            }

            throw new ArgumentException("Produto não encontrado.");
        }


        public async Task<List<Produto>> Listar()
        {
            return await _ctx.Produtos.AsNoTracking().ToListAsync();
        }
    }
}
