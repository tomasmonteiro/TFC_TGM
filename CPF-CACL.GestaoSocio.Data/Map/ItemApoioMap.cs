using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class ItemApoioMap : IEntityTypeConfiguration<ItemApoio>
    {
        public void Configure(EntityTypeBuilder<ItemApoio> builder)
        {
            builder.ToTable("ItemApoio");

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor).HasColumnType("smallmoney");
            builder.Property(x => x.Quantidade).HasColumnType("int");

            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            //Relacionamento: um Fornecedor fornece varios Itens
            builder.HasOne(x => x.Fornecedor)
                .WithMany(a => a.ItemApoios)
                .HasForeignKey(x => x.ForneceorId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Apoio possui varios Itens
            builder.HasOne(x => x.Apoio)
                .WithMany(a => a.ItemApoios)
                .HasForeignKey(x => x.ApoioId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Benefício pertence a varios ItemApoio
            builder.HasOne(x => x.Beneficio)
                .WithMany(a => a.ItemApoios)
                .HasForeignKey(x => x.BeneficioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
