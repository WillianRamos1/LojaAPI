using Loja.Application.Contratos;
using Loja.Application.Dtos;
using Loja.Domain.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAllAsync();
            if (result == null) return NoContent();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personService.GetByIdAsync(id);
            if (result == null) return NoContent();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto person)
        {
            var result = await _personService.CreateAsync(person);
            if (result == null) return NoContent();
            if (result.IsSuccess) return Ok("Pessoa Adicionada com Sucesso");
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonDto person)
        {
            var result = await _personService.UpdateAsync(person);
            if (result == null) return NoContent();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _personService.DeleteAsync(id);
            if (result == null) return NoContent();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }

        [HttpGet("{paged}")]
        public async Task<IActionResult> GetPaged([FromBody] PersonFilter personFilter)
        {
            var result = await _personService.GetPage(personFilter);
            if (result == null) return NoContent();
            if (result.IsSuccess) return Ok(result); return BadRequest(result);
        }
    }
}
