using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly ApplicationDbContext _db;

        public PessoaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            _db.Add(pessoa);
            await _db.SaveChangesAsync();
            return pessoa;
        }

        public async Task DeleteAsync(Pessoa pessoa)
        {
            _db.Remove(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Pessoa pessoa)
        {
            _db.Update(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Pessoa>> GetPessoasAsync()
        {
            return await _db.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _db.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetIdByDocumentAsync(string documento)
        {
            return (await _db.Pessoas.FirstOrDefaultAsync(x => x.Documento == documento))?.Id ?? 0;
        }
    }
}
