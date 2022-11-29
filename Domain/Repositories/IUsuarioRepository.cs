﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<ICollection<Usuario>> GetProjetoAsync();
        Task<Usuario> CreateAsync(Usuario usuario);
        Task EditAsync(Usuario usuario);
        Task DeleteAsync(Usuario usuario);
    }
}
