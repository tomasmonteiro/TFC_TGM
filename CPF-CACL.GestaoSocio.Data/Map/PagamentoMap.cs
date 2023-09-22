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
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            //Relacionamento: um Tipo de Pagamento pertence a varios Pagamentos
            builder.HasOne(x => x.TipoPagamento)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(x => x.TipoPagamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Usuario realiza vários Pagamentos
            builder.HasOne(x => x.Usuario)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Socio recebe vários Pagamentos
            builder.HasOne(x => x.Socio)
                .WithMany(a => a.Pagamentos)
                .HasForeignKey(x => x.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
