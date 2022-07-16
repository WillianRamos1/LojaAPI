using Loja.Application.Contratos;
using Loja.Application.Dtos;
using Loja.Application.Service;
using Loja.Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _compraService.GetAllAsync();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _compraService.GetByIdAsync(id);
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompraDto compra)
        {
            try
            {
                var result = await _compraService.CreateAsync(compra);
                if (result.IsSuccess) return Ok(result); return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CompraDto compra)
        {
            try
            {
                var result = await _compraService.UpdateAsync(compra);
                if (result.IsSuccess) return Ok(result); return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _compraService.DeleteAsync(id);
                if (result.IsSuccess) return Ok(result); return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }
    }
}
