using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProjetoRepository
    {
        Task<Projeto> GetByIdAsync(int id);
        Task<ICollection<Projeto>> GetProjetoAsync();
        Task<Projeto> CreateAsync(Projeto projeto);
        Task EditAsync(Projeto projeto);
        Task DeleteAsync(Projeto projeto);
    }
}
