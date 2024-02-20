using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cod).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(x => x.Cod).IsUnique(true);

            builder.Property(x => x.Descricao).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.Valor).HasColumnType("smallmoney").IsRequired(true);
            builder.Property(x => x.Estado).HasColumnType("varchar(30)").IsRequired(true);
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
