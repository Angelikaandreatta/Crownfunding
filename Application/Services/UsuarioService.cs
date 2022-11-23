using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using Domain.Authentication;
using Domain.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenGenerator tokenGenerator)
        {
            _usuarioRepository = usuarioRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado");

            var validator = new UsuarioDtoValidator().Validate(usuarioDto);

            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas de validação", validator);

            var usuario = await _usuarioRepository.GetUsuarioByEmailandSenhaAsync(usuarioDto.Email, usuarioDto.Senha);

            if (usuario == null)
                return ResultService.Fail<dynamic>("Usuario ou senha não encontrados");

            return ResultService.Ok(_tokenGenerator.Generator(usuario));
        }
    }
}
