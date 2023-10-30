using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class SocioMap : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.ToTable("Socio");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.BI).HasColumnType("varchar(14)");
            builder.Property(x => x.Genero).HasColumnType("varchar(9)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            builder.Property(x => x.EstadoCivil).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(12)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(300)");
            builder.Property(x => x.Profissao).HasColumnType("varchar(100)");
            builder.Property(x => x.Habilitacoes).HasColumnType("varchar(20)");
            builder.Property(x => x.Nacionalidade).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.NomeDoPai).HasColumnType("varchar(150)");
            builder.Property(x => x.NomeDaMae).HasColumnType("varchar(150)");
            builder.Property(x => x.OrganismoId).HasColumnType("int").IsRequired(); 
            builder.Property(x => x.LocalDeTrabalho).HasColumnType("varchar(100)");
            builder.Property(x => x.EstadoSocio).HasColumnName("EstadoSocio").HasColumnType("varchar(10)");
            builder.Property(x => x.Funcao).HasColumnType("varchar(100)");
            builder.Property(x => x.Departamento).HasColumnType("varchar(100)");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            //Relacionamento: um Organismo possui varios Socios
            builder.HasOne(x => x.Organismo)
                .WithMany(a => a.Socios)
                .HasForeignKey(x => x.OrganismoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: uma Categoria de Socios pertence a varios Socios
            builder.HasOne(x => x.CategoriaSocio)
                .WithMany(a => a.Socios)
                .HasForeignKey(x => x.CategoriaSocioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
