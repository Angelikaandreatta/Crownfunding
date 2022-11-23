using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ProjetoDto projetoDto)
        {
            var result = _projetoService.Create(projetoDto);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _projetoService.GetAsync();

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _projetoService.GetByIdAsync(id);

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProjetoDto projetoDto)
        {
            var result = _projetoService.UpdateAsync(projetoDto);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = _projetoService.DeleteAsync(id);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
