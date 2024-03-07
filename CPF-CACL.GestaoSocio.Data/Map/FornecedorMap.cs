using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cod).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(i => i.Cod).IsUnique(true); //Seter a propriedade como única

            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.NIF).HasColumnType("varchar(15)");
            builder.Property(x => x.Telefone).HasColumnType("varchar(12)");
            builder.Property(x => x.Email).HasColumnType("varchar(300)");
            builder.Property(x => x.Endereco).HasColumnType("varchar(300)");

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();
        }
    }
}
