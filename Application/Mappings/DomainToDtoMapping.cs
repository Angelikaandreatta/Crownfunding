using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Projeto, ProjetoDto>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
