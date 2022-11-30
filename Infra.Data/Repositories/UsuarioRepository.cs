using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            await _db.AddAsync(usuario);
            await _db.SaveChangesAsync();

            return usuario;
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            _db.Remove(usuario);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Usuario usuario)
        {
            _db.Update(usuario);
            await _db.SaveChangesAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> GetByLogin(string email, string senha)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);
        }

        public async Task<ICollection<Usuario>> GetUsuarioAsync()
        {
            return await _db.Usuarios.ToListAsync();
        }
    }
}
