using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosCodeFirst.Models;
using ProdutosCodeFirst.Services;

namespace ProdutosCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Listar()
        {
            try
            {
                var produtos = await _service.Listar();
                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto?>> BuscarPorId(Guid id)
        {
            try
            {
                var produto = await _service.BuscarPorId(id);

                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Cadastrar(Produto produto)
        {
            try
            {
                var produtoCadastrado = await _service.Cadastrar(produto);

                return StatusCode(201, produtoCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar(Guid id, Produto produto)
        {
            try
            {
                var produtoAtualizado = await _service.Atualizar(id, produto);
                return Ok(produtoAtualizado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Deletar(Guid id)
        {
            try
            {
                var produtoDeletado = await _service.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
