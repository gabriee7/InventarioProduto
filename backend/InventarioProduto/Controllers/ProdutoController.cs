using Microsoft.AspNetCore.Mvc;
using InventarioProduto.Services.Produto;
using InventarioProduto.Services.Produto.Dtos;
using InventarioProduto.Services.Pagination;

namespace InventarioProduto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ProdutoDto>> Create([FromBody] CreateProdutoDto input)
        {
            var produto = await _produtoService.Create(input);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PagedResultDto<ProdutoDto>>> GetAll([FromQuery] PagedRequestDto input)
        {
            var result = await _produtoService.GetAll(input);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ProdutoDto>> GetById(string id)
        {
            var produto = await _produtoService.GetById(id);
            return Ok(produto);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ProdutoDto>> Update([FromBody] UpdateProdutoDto input)
        {
            var produto = await _produtoService.Update(input);
            return Ok(produto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _produtoService.Delete(id);
            return NoContent();
        }
    }
}
