using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UsuarioDto usuarioDto);
    }
}
