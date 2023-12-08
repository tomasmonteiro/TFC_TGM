﻿using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class CapitalMap : IEntityTypeConfiguration<Capital>
    {
        public void Configure(EntityTypeBuilder<Capital> builder)
        {

            builder.ToTable("Capital");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor).HasColumnType("smallmoney").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            //Relacionamento: uma Categoria pertence a varios Capitais
            builder.HasOne(x => x.CategoriaSocio)
                .WithMany(a => a.Capitais)
                .HasForeignKey(x => x.CategoriaSocioId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Benefício pertence a varios Capitais
            builder.HasOne(x => x.Beneficio)
                .WithMany(a => a.Capitais)
                .HasForeignKey(x => x.BeneficioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
