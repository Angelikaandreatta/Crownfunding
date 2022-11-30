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
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProjetoDto>> Create(ProjetoDto projetoDto)
        {
            if (projetoDto == null)
                return ResultService.Fail<ProjetoDto>("Objeto deve ser informado");

            var result = new ProjetoDtoValidator().Validate(projetoDto);

            if (!result.IsValid)
                return ResultService.RequestError<ProjetoDto>("Problemas de validação", result);

            var projeto = _mapper.Map<Projeto>(projetoDto);
            var data = await _projetoRepository.CreateAsync(projeto);

            return ResultService.Ok<ProjetoDto>(_mapper.Map<ProjetoDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);

            if (projeto == null)
                return ResultService.Fail("Projeto não encontrado.");

            await _projetoRepository.DeleteAsync(projeto);
            return ResultService.Ok("Projeto deletado com sucesso.");
        }

        public async Task<ResultService<ICollection<ProjetoDto>>> GetAsync()
        {
            var projeto = await _projetoRepository.GetProjetoAsync();
            return ResultService.Ok<ICollection<ProjetoDto>>(_mapper.Map<ICollection<ProjetoDto>>(projeto));
        }

        public async Task<ResultService<ProjetoDto>> GetByIdAsync(int id)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);

            if (projeto == null)
                return ResultService.Fail<ProjetoDto>("Projeto não encontrado");

            return ResultService.Ok(_mapper.Map<ProjetoDto>(projeto));
        }

        public async Task<ResultService<ProjetoDto>> GetByIdUsuario(int idUsuario)
        {
            var projeto = await _projetoRepository.GetByIdUsuarioAsync(idUsuario);

            if (projeto == null)
                return ResultService.Fail<ProjetoDto>("Não existe nenhum projeto com este usuário.");

            return ResultService.Ok(_mapper.Map<ProjetoDto>(projeto));
        }

        public async Task<ResultService> UpdateAsync(ProjetoDto projetoDto)
        {
            if (projetoDto == null)
                return ResultService.Fail("Objeto deve ser informado.");

            var validation = new ProjetoDtoValidator().Validate(projetoDto);

            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var projeto = await _projetoRepository.GetByIdAsync(projetoDto.Id);
            if (projeto == null)
                return ResultService.Fail("Projeto não encontrado.");

            projeto = _mapper.Map<ProjetoDto, Projeto>(projetoDto, projeto);
            await _projetoRepository.EditAsync(projeto);

            return ResultService.Ok("Projeto editado com sucesso.");
        }
    }
}
