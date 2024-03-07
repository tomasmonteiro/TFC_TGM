using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("Dependente");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.BI).HasColumnType("varchar(14)");
            builder.Property(x => x.Genero).HasColumnType("varchar(9)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            builder.Property(x => x.Nacionalidade).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.RelacaoId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            //Relacionamento: uma Relação pertence a vários Agregados
            builder.HasOne(x => x.Relacao)
                .WithMany(b => b.Dependentes)
                .HasForeignKey(x => x.RelacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Socio possui vários Agregados
            builder.HasOne(x => x.Socio)
                .WithMany(b => b.Dependentes)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
