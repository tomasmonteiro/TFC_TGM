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
    public class PedidoApoioMap : IEntityTypeConfiguration<PedidoApoio>
    {
        public void Configure(EntityTypeBuilder<PedidoApoio> builder)
        {
            builder.ToTable("PedidoApoio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasColumnType("varchar(100)");
            builder.Property(x => x.EstadoPedido).HasColumnType("varchar(10)").IsRequired();
            
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.HasOne(x => x.Socio)
                .WithMany(a => a.PedidoApoios)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
