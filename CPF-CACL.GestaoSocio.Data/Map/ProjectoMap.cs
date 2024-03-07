using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class ProjectoMap : IEntityTypeConfiguration<Projecto>
    {
        public void Configure(EntityTypeBuilder<Projecto> builder)
        {
            builder.ToTable("Projecto");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int");
            
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.TipoProjectoId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.HasOne(x => x.TipoProjecto)
                .WithMany(a => a.Projectos)
                .HasForeignKey(x => x.TipoProjectoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
