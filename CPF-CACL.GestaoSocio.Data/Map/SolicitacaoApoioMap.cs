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
    internal class SolicitacaoApoioMap : IEntityTypeConfiguration<SolicitacaoApoio>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoApoio> builder)
        {
            builder.ToTable("SolicitacaoApoio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Mensagem).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.UrlAnexo).HasColumnType("varchar(70)").IsRequired(false);
            builder.Property(x => x.EstadoSolicitacao).HasColumnType("varchar(9)").IsRequired(true);
            builder.Property(x => x.TipoApoioId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.HasOne(x => x.TipoApoio)
                .WithMany(a => a.SolicitacaoApoios)
                .HasForeignKey(x => x.TipoApoioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Socio)
                .WithMany(a => a.SolicitacaoApoios)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
