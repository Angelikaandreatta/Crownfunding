using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPessoaService
    {

        Task<ResultService<PessoaDto>> CreateAsync(PessoaDto passoaDto);
        Task<ResultService<ICollection<PessoaDto>>> GetAsync();
        Task<ResultService<PessoaDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PessoaDto passoaDto);
        Task<ResultService> RemoveAsync(int id);
    }
}
