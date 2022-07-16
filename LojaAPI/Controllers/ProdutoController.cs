using Loja.Application.Contratos;
using Loja.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _produtoService.GetAllAsync();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _produtoService.GetByIdAsync(id);
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDto produto)
        {
            var result = await _produtoService.CreateAsync(produto);
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProdutoDto produto)
        {
            var result = await _produtoService.UpdateAsync(produto);
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _produtoService.DeleteAsync(id);
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }
    }
}
