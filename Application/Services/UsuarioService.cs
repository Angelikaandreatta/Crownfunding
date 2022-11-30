using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository projetoRepository, IMapper mapper)
        {
            _usuarioRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<UsuarioDto>> Create(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return ResultService.Fail<UsuarioDto>("Objeto deve ser informado");

            var result = new UsuarioDtoValidator().Validate(usuarioDto);

            if (!result.IsValid)
                return ResultService.RequestError<UsuarioDto>("Problemas de validação", result);

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var data = await _usuarioRepository.CreateAsync(usuario);

            return ResultService.Ok<UsuarioDto>(_mapper.Map<UsuarioDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
                return ResultService.Fail("Usuário não encontrado.");

            await _usuarioRepository.DeleteAsync(usuario);
            return ResultService.Ok("Usuário deletado com sucesso.");
        }

        public async Task<ResultService<ICollection<UsuarioDto>>> GetAsync()
        {
            var usuario = await _usuarioRepository.GetUsuarioAsync();
            return ResultService.Ok<ICollection<UsuarioDto>>(_mapper.Map<ICollection<UsuarioDto>>(usuario));
        }

        public async Task<ResultService<UsuarioDto>> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
                return ResultService.Fail<UsuarioDto>("Usuário não encontrado");

            return ResultService.Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<ResultService> UpdateAsync(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return ResultService.Fail("Objeto deve ser informado.");

            var validation = new UsuarioDtoValidator().Validate(usuarioDto);

            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var usuario = await _usuarioRepository.GetByIdAsync(usuarioDto.Id);
            if (usuario == null)
                return ResultService.Fail("Usuário não encontrado.");

            usuario = _mapper.Map<UsuarioDto, Usuario>(usuarioDto, usuario);
            await _usuarioRepository.EditAsync(usuario);

            return ResultService.Ok("Usuário editado com sucesso.");
        }
    }
}
