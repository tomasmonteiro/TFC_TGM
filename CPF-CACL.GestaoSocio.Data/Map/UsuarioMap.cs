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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.Email).HasColumnType("varchar(60)");
            builder.Property(x => x.Login).HasColumnType("varchar(10)").IsRequired(true);
            builder.Property(x => x.Senha).HasColumnType("text").IsRequired(true);
			builder.Property(x => x.Perfil).HasColumnType("varchar(13)").IsRequired(true);
			builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();


        }
    }
}
