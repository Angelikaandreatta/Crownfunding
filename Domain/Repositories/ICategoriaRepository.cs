using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetByIdAsync(int id);
        Task<ICollection<Categoria>> GetCategoriaAsync();
        Task<Categoria> CreateAsync(Categoria veiculo);
        Task EditAsync(Categoria veiculo);
        Task DeleteAsync(Categoria veiculo);
    }
}
