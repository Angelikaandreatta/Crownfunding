using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<ResultService<ProjetoDto>> Create(ProjetoDto projetoDto);
        Task<ResultService<ICollection<ProjetoDto>>> GetAsync();
        Task<ResultService<ProjetoDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ProjetoDto projetoDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
