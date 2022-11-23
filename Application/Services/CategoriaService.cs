using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoriaDto>> Create(CategoriaDto categoriaDto)
        {
            if (categoriaDto == null)
                return ResultService.Fail<CategoriaDto>("Objeto deve ser informado");

            var result = new CategoriaDtoValidator().Validate(categoriaDto);

            if (!result.IsValid)
                return ResultService.RequestError<CategoriaDto>("Problemas de validação", result);

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var data = _categoriaRepository.CreateAsync(categoria);

            return ResultService.Ok<CategoriaDto>(_mapper.Map<CategoriaDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
                return ResultService.Fail("Veiculo não encontrado.");

            await _categoriaRepository.DeleteAsync(categoria);
            return ResultService.Ok("Veiculo deletado.");
        }

        public async Task<ResultService<ICollection<CategoriaDto>>> GetAsync()
        {
            var categoria = await _categoriaRepository.GetCategoriaAsync();
            return ResultService.Ok<ICollection<CategoriaDto>>(_mapper.Map<ICollection<CategoriaDto>>(categoria));
        }

        public async Task<ResultService<CategoriaDto>> GetByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
                return ResultService.Fail<CategoriaDto>("Categoria não encontrada");

            return ResultService.Ok(_mapper.Map<CategoriaDto>(categoria));
        }

        public async Task<ResultService> UpdateAsync(CategoriaDto categoriaDto)
        {
            if (categoriaDto == null)
                return ResultService.Fail("Objeto deve ser informado.");

            var validation = new CategoriaDtoValidator().Validate(categoriaDto);

            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var categoria = await _categoriaRepository.GetByIdAsync(categoriaDto.Id);
            if (categoria == null)
                return ResultService.Fail("Categoria não encontrada.");

            categoria = _mapper.Map<CategoriaDto, Categoria>(categoriaDto, categoria);
            await _categoriaRepository.EditAsync(categoria);

            return ResultService.Ok("Categoria editada com sucesso.");
        }
    }
}
