using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Recibo).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(x => x.Recibo).IsUnique(true);

            builder.Property(x => x.Valor).HasColumnType("money").IsRequired(true);
            builder.Property(x => x.Estado).HasColumnType("varchar(10)").IsRequired(true);
            builder.Property(x => x.DataPagamento).HasColumnType("date").IsRequired(true);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.TipoPagamentoId).HasColumnType("uniqueidentifier").IsRequired(true);



            //Relacionamento: um Socio recebe vários Pagamentos
            builder.HasOne(x => x.Socio)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TipoPagamento)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(x => x.TipoPagamentoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
