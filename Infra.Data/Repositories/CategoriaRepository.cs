using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _db.Add(categoria);
            await _db.SaveChangesAsync();
            return categoria;
        }

        public async Task DeleteAsync(Categoria categoria)
        {
            _db.Remove(categoria);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Categoria categoria)
        {
            _db.Update(categoria);
            await _db.SaveChangesAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _db.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Categoria>> GetCategoriaAsync()
        {
            return await _db.Categorias.ToListAsync();
        }
    }
}
