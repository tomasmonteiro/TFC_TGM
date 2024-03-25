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
    public class UsuarioSocioMap : IEntityTypeConfiguration<UsuarioSocio>
    {
        public void Configure(EntityTypeBuilder<UsuarioSocio> builder)
        {
            builder.ToTable("UsuarioSocio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

			builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.HasOne(x => x.Usuario)
                .WithMany(a => a.UsuarioSocios)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Socio)
                .WithMany(a => a.UsuarioSocios)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
