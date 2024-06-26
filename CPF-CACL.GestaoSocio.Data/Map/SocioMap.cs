﻿using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPF_CACL.GestaoSocio.Data.Map
{
    public class SocioMap : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.ToTable("Socio");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo).HasColumnType("varchar(10)").IsRequired(true);
            builder.HasIndex(i => i.Codigo).IsUnique(true); // Setar a propriedade como única

            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.BI).HasColumnType("varchar(14)");

            builder.Property(x => x.Genero).HasColumnType("char(1)").IsRequired();

            builder.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            builder.Property(x => x.CaminhoFoto).HasColumnType("varchar(80)");

            builder.Property(x => x.EstadoCivil).HasColumnType("varchar(10)").IsRequired();

            builder.Property(x => x.Telefone).HasColumnType("varchar(12)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(50)");
            builder.Property(x => x.Endereco).HasColumnType("varchar(50)");

            builder.Property(x => x.Habilitacoes).HasColumnType("varchar(13)");


            builder.Property(x => x.NomeDoPai).HasColumnType("varchar(50)");
            builder.Property(x => x.NomeDaMae).HasColumnType("varchar(50)");
            builder.Property(x => x.LocalDeTrabalho).HasColumnType("varchar(20)");
            builder.Property(x => x.EstadoSocio).HasColumnType("varchar(8)");
            builder.Property(x => x.Funcao).HasColumnType("varchar(30)");
            builder.Property(x => x.Departamento).HasColumnType("varchar(30)");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.Property(x => x.BairroId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.OrganismoId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(x => x.CategoriaSocioId).HasColumnType("uniqueidentifier").IsRequired(true);

            //Relacionamento: um Bairro para vários Sócios
            builder.HasOne(x => x.Bairros)
                .WithMany(a => a.Socios)
                .HasForeignKey(x => x.BairroId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: um Organismo possui varios Socios
            builder.HasOne(x => x.Organismo)
                .WithMany(a => a.Socios)
                .HasForeignKey(x => x.OrganismoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento: uma Categoria de Socios pertence a varios Socios
            builder.HasOne(x => x.CategoriaSocio)
                .WithMany(a => a.Socios)
                .HasForeignKey(x => x.CategoriaSocioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
