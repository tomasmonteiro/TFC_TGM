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
    public class EmolumentoMap : IEntityTypeConfiguration<Emolumento>
    {
        public void Configure(EntityTypeBuilder<Emolumento> builder)
        {
            builder.ToTable("Emolumento");
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(x => x.Codigo).IsUnique(true);

            builder.Property(x => x.Descricao).HasColumnType("varchar(5)").IsRequired(true);
            builder.Property(x => x.Valor).HasColumnType("money").IsRequired(true);
            builder.Property(x => x.Estado).HasColumnType("varchar(9)").IsRequired(true);
            builder.Property(x => x.DataVencimento).HasColumnType("date").IsRequired(false);
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.PeriodoId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.TipoItemId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            //Relacionamento: um Período para muitos Itens
            builder.HasOne(x => x.Periodo)
                .WithMany(a => a.Items)
                .HasForeignKey(x => x.PeriodoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Tipo de Item para muitos Itens
            builder.HasOne(x => x.TipoItem)
                .WithMany(a => a.Items)
                .HasForeignKey(x => x.TipoItemId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Socio para muitos Itens
            builder.HasOne(x => x.Socio)
                .WithMany(a => a.Items)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
