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
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(c => c.IdUsuario)
                .HasColumnName("idUsuario");

            builder.Property(c => c.Nome)
                .HasColumnName("nome");

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao");

            builder.Property(c => c.ImagemPerfil)
               .HasColumnName("imagemPerfil");

            builder.Property(c => c.Categoria)
               .HasColumnName("categoria");

            builder.Property(c => c.ImagemCapa)
               .HasColumnName("imagemCapa");

            builder.Property(c => c.Meta)
               .HasColumnName("meta");

            builder.Property(c => c.Links)
               .HasColumnName("links");

            builder.HasOne(c => c.Usuario)
                .WithMany(a => a.Projeto);
        }
    }
}
