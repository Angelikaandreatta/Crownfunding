using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CategoriaDto categoriaDto)
        {
            var result = _categoriaService.Create(categoriaDto);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _categoriaService.GetAsync();

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _categoriaService.GetByIdAsync(id);

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CategoriaDto categoriaDto)
        {
            var result = _categoriaService.UpdateAsync(categoriaDto);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = _categoriaService.DeleteAsync(id);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
