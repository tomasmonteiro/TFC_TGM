using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class SaldoMap : IEntityTypeConfiguration<Saldo>
    {
        public void Configure(EntityTypeBuilder<Saldo> builder)
        {
            builder.ToTable("Saldo");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Recibo).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.Valor).HasColumnType("smallmoney").IsRequired(true);
            builder.Property(x => x.Estado).HasColumnType("varchar(20)").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.PagamentoId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.DataPagamento).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.HasOne(x => x.Pagamentos)
                .WithMany(a => a.Saldo)
                .HasForeignKey(x => x.PagamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Socios)
                .WithMany(a => a.Saldo)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
