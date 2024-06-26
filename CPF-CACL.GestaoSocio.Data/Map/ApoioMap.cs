﻿using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class ApoioMap : IEntityTypeConfiguration<Apoio>
    {
        public void Configure(EntityTypeBuilder<Apoio> builder)
        {
            builder.ToTable("Apoio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasColumnType("varchar(50)");
            builder.Property(x => x.DataApoio).HasColumnType("date").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("money");
            builder.Property(x => x.EstadoApoio).HasColumnType("varchar(9)");

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.UsuarioId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            //Relacionamento: um Usuário realiza vários Apoios
            builder.HasOne(x => x.Usuario)
                .WithMany(a => a.Apoios)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Socio possui vários Apoios
            builder.HasOne(x => x.Socio)
                .WithMany(a => a.Apoios)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
