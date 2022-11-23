using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<ResultService<CategoriaDto>> Create(CategoriaDto categoriaDto);
        Task<ResultService<ICollection<CategoriaDto>>> GetAsync();
        Task<ResultService<CategoriaDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(CategoriaDto categoriaDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
