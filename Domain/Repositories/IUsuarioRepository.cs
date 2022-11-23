using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByEmailandSenhaAsync(string email, string senha);
    }
}
