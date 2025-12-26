using ApiCadastroPessoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCadastroPessoa.Infrastructure.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.OwnsOne(p => p.Endereco, endereco =>
            {
                endereco.Property(e => e.Cep)
                    .HasColumnName("Cep")
                    .HasMaxLength(10)
                    .IsRequired();

                endereco.Property(e => e.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasMaxLength(150)
                    .IsRequired();

                endereco.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(100);

                endereco.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Estado)
                    .HasColumnName("Estado")
                    .HasMaxLength(30)
                    .IsRequired();

                endereco.Property(e => e.Numero)
                    .HasColumnName("Numero")
                    .HasMaxLength(10)
                    .IsRequired();

                endereco.Property(e => e.Complemento)
                    .HasColumnName("Complemento")
                    .HasMaxLength(50);
            });
        }
    }
}
