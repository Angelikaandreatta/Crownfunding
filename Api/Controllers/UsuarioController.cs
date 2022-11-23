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
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UsuarioDto usuarioDto)
        {
            var result = await _usuarioService.GenerateTokenAsync(usuarioDto);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }
    }
}
