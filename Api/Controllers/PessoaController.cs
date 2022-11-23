using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PessoaDto pessoaDto)
        {
            var result = await _pessoaService.CreateAsync(pessoaDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]

        public async Task<ActionResult> GetAsync()
        {
            var result = await _pessoaService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetIdAsync(int id)
        {
            var result = await _pessoaService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PessoaDto pessoaDto)
        {
            var result = await _pessoaService.UpdateAsync(pessoaDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _pessoaService.RemoveAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

