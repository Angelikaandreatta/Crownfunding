using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjetoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Projeto> CreateAsync(Projeto projeto)
        {
            _db.Add(projeto);
            await _db.SaveChangesAsync();
            return projeto;
        }

        public async Task DeleteAsync(Projeto projeto)
        {
            _db.Remove(projeto);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Projeto projeto)
        {
            _db.Update(projeto);
            await _db.SaveChangesAsync();
        }

        public async Task<Projeto> GetByIdAsync(int id)
        {
            return await _db.Projetos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Projeto>> GetProjetoAsync()
        {
            return await _db.Projetos.ToListAsync();
        }
    }
}
