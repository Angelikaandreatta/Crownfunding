using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Usuario> GetUsuarioByEmailandSenhaAsync(string email, string senha)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);
        }
    }
}
