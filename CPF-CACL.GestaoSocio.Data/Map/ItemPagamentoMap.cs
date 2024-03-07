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
    public class ItemPagamentoMap : IEntityTypeConfiguration<ItemPagamento>
    {
        public void Configure(EntityTypeBuilder<ItemPagamento> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataInsercao).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.PagamentoId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.ItemId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.HasOne(x => x.Pagamento)
                .WithMany(a => a.ItemPagamnetos)
                .HasForeignKey(x => x.PagamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Item)
                .WithMany(a => a.ItemPagamnetos)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
