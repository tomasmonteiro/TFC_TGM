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
    public class TipoProjectoMap : IEntityTypeConfiguration<TipoProjecto>
    {
        public void Configure(EntityTypeBuilder<TipoProjecto> builder)
        {
            builder.ToTable("TipoProjecto");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

        }
    }
}
