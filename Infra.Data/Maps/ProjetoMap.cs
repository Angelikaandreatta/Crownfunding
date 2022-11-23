using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(c => c.Nome)
                .HasColumnName("Nome");

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");

            builder.Property(c => c.Links)
               .HasColumnName("Links");

            builder.Property(c => c.ImagemPerfil)
               .HasColumnName("Imagemperfil");

            builder.Property(c => c.ImagemCapa)
               .HasColumnName("Imagemcapa");

            builder.Property(c => c.Meta)
               .HasColumnName("Meta");

            builder.Property(c => c.Categoria)
               .HasColumnName("Categoria");
        }
    }
}
