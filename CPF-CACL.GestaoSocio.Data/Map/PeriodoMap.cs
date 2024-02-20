using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class PeriodoMap : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cod).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(x => x.Cod).IsUnique(true);

            builder.Property(x => x.Ano).HasColumnType("int").IsRequired(true);
            builder.Property(x => x.Estado).HasColumnType("varchar(20)").IsRequired(true);
            builder.Property(x => x.DataInicio).HasColumnType("date").IsRequired(true);
            builder.Property(x => x.DataFim).HasColumnType("date").IsRequired(true);
            builder.Property(x => x.UltimoDiaUtil).HasColumnType("date").IsRequired(true);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired(true);
        }
    }
}
