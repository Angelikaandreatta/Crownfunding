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
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PessoaDto>> CreateAsync(PessoaDto pessoaDto)
        {
            if (pessoaDto == null)
                return ResultService.Fail<PessoaDto>("Objeto deve ser informado");

            var result = new PessoaDtoValidator().Validate(pessoaDto);
            if (!result.IsValid)
                return ResultService.RequestError<PessoaDto>("Problema de validacao!", result);

            var person = _mapper.Map<Pessoa>(pessoaDto);
            var data = await _pessoaRepository.CreateAsync(person);
            return ResultService.Ok<PessoaDto>(_mapper.Map<PessoaDto>(data));
        }

        public async Task<ResultService<ICollection<PessoaDto>>> GetAsync()
        {
            var people = await _pessoaRepository.GetPessoasAsync();
            return ResultService.Ok<ICollection<PessoaDto>>(_mapper.Map<ICollection<PessoaDto>>(people));
        }

        public async Task<ResultService<PessoaDto>> GetByIdAsync(int id)
        {
            var person = await _pessoaRepository.GetByIdAsync(id);
            return ResultService.Ok(_mapper.Map<PessoaDto>(person));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var person = await _pessoaRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail("Pessoa não encontrada!");

            await _pessoaRepository.DeleteAsync(person);
            return ResultService.Ok($"Pessoa do id:{id} deletada");
        }

        public async Task<ResultService> UpdateAsync(PessoaDto pessoaDto)
        {
            if (pessoaDto == null)
                return ResultService.Fail<PessoaDto>("Objeto deve ser informado");

            var validation = new PessoaDtoValidator().Validate(pessoaDto);
            if (!validation.IsValid)
                return ResultService.RequestError<PessoaDto>("Problema de validacao!", validation);

            var person = await _pessoaRepository.GetByIdAsync(pessoaDto.Id);
            if (person == null)
                return ResultService.Fail("Pessoa não encontrada!");

            person = _mapper.Map<PessoaDto, Pessoa>(pessoaDto, person);
            await _pessoaRepository.EditAsync(person);
            return ResultService.Ok("Pessoa editada");
        }
    }
}
