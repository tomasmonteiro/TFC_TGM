using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class ProjectoSocioMap : IEntityTypeConfiguration<ProjectoSocio>
    {
        public void Configure(EntityTypeBuilder<ProjectoSocio> builder)
        {
            builder.ToTable("ProjectoSocio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.DataAtribuicao).HasColumnType("Datetime").IsRequired();

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.HasOne(x => x.Projecto)
                .WithMany(a => a.ProjectoSocios)
                .HasForeignKey(x => x.ProjectoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Socio)
                .WithMany(a => a.ProjectoSocios)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
