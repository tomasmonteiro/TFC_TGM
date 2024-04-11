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
    public class SolicitacaoDeclaracaoMap : IEntityTypeConfiguration<SolicitacaoDeclaracao>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoDeclaracao> builder)
        {
            builder.ToTable("SolicitacaoDeclaracao");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EstadoSolicitacao).HasColumnType("varchar(9)").IsRequired(true);
            builder.Property(x => x.TipoDeclaracaoId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.SocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.HasOne(x => x.TipoDeclaracao)
                .WithMany(a => a.SolicitacaoDeclaracoes)
                .HasForeignKey(x => x.TipoDeclaracaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Socio)
                .WithMany(a => a.SolicitacaoDeclaracoes)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
