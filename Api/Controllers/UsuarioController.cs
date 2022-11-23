using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UsuarioDto usuarioDto)
        {
            var result = _usuarioService.Create(usuarioDto);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _usuarioService.GetAsync();

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _usuarioService.GetByIdAsync(id);

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UsuarioDto usuarioDto)
        {
            var result = _usuarioService.UpdateAsync(usuarioDto);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = _usuarioService.DeleteAsync(id);
            if (result.IsCompletedSuccessfully)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
