using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<ResultService<ProjetoDto>> Create(ProjetoDto projetoDto);
        Task<ResultService<ICollection<ProjetoDto>>> GetAsync();
        Task<ResultService<ProjetoDto>> GetByIdAsync(int id);
        Task<ResultService<ProjetoDto>> GetByIdUsuario(int idUsuario);
        Task<ResultService> UpdateAsync(ProjetoDto projetoDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
