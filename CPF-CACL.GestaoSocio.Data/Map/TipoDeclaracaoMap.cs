using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class TipoDeclaracaoMap : IEntityTypeConfiguration<TipoDeclaracao>
    {
        public void Configure(EntityTypeBuilder<TipoDeclaracao> builder)
        {
            builder.ToTable("TipoDeclaracao");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo).HasColumnType("varchar(25)").IsRequired();

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();
        }
    }
}
