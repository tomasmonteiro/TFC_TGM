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

            builder.Property(x => x.Codigo).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(i => i.Codigo).IsUnique(true); //Setar a propriedade como única

            builder.Property(x => x.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.NIF).HasColumnType("varchar(15)");
            builder.Property(x => x.Telefone).HasColumnType("varchar(12)");
            builder.Property(x => x.Email).HasColumnType("varchar(50)");
            builder.Property(x => x.Endereco).HasColumnType("varchar(50)");

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            //Relacionamento: um Bairro para vários Fornecedores
            builder.HasOne(x => x.Bairros)
                .WithMany(a => a.Fornecedores)
                .HasForeignKey(x => x.BairroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
