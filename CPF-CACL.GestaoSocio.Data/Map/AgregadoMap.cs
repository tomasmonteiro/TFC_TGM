using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class AgregadoMap : IEntityTypeConfiguration<Agregado>
    {
        public void Configure(EntityTypeBuilder<Agregado> builder)
        {
            builder.ToTable("Agregado");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.BI).HasColumnType("varchar(14)");
            builder.Property(x => x.Genero).HasColumnType("varchar(9)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(12)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(300)");
            builder.Property(x => x.Nacionalidade).HasColumnType("varchar(20)").IsRequired();

            //Relacionamento: um Socio possui vários Agregados
            builder.HasOne(x => x.Socio)
                .WithMany(b => b.Agregados)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
