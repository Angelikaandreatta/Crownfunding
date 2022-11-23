using Application.Mappings;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Authentication;
using Domain.Repositories;
using Infra.Data.Authentication;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddAutoMapper(typeof(DtoToDomainMapping));
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPessoaService, PessoaService>();
            return services;
        }
    }
}
