using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResultService<UsuarioDto>> Create(UsuarioDto usuarioDto);
        Task<ResultService<ICollection<UsuarioDto>>> GetAsync();
        Task<ResultService<UsuarioDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UsuarioDto usuarioDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
