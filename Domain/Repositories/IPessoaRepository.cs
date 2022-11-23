using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetByIdAsync(int id);
        Task<ICollection<Pessoa>> GetPessoasAsync();
        Task<Pessoa> CreateAsync(Pessoa pessoa);
        Task EditAsync(Pessoa pessoa);
        Task DeleteAsync(Pessoa pessoa);
        Task<int> GetIdByDocumentAsync(string documento);
    }
}
