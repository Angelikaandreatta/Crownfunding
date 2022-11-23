using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {

        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id").
                UseIdentityColumn();

            builder.Property(c => c.Documento)
                .HasColumnName("Documento");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome");

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone");
        }
    }
}
