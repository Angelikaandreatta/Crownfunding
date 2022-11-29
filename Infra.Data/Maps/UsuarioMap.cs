using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(c => c.Nome)
                .HasColumnName("nome");

            builder.Property(c => c.Telefone)
                .HasColumnName("telefone");

            builder.Property(c => c.Email)
               .HasColumnName("email");

            builder.Property(c => c.Senha)
               .HasColumnName("senha");
        }
    }
}
