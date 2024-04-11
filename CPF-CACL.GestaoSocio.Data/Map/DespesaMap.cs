using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("Despesa");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor).HasColumnType("money").IsRequired();
            builder.Property(x => x.EstadoDespesa).HasColumnType("varchar(8)").IsRequired();
            
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.ApoioId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.FornecedorId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.HasOne(x => x.Apoio)
                .WithMany(a => a.Despesas)
                .HasForeignKey(x => x.ApoioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Fornecedor)
                .WithMany(a => a.Despesas)
                .HasForeignKey(x => x.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
