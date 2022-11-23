using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<ProjetoDto, Projeto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<PessoaDto, Pessoa>();
        }
    }
}
