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
    public class TipoEmolumentoMap : IEntityTypeConfiguration<TipoEmolumento>
    {
        public void Configure(EntityTypeBuilder<TipoEmolumento> builder)
        {
            builder.ToTable("TipoEmolumento");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasColumnType("varchar(5)").IsRequired(true);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired(true);
        }
    }
}
