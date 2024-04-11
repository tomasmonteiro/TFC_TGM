using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class BairroMap : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder.ToTable("Bairro");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.MunicipioId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.HasOne(x => x.Municipio)
                .WithMany(a => a.Bairros)
                .HasForeignKey(x => x.MunicipioId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
