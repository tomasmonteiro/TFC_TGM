using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

        }
    }
}
