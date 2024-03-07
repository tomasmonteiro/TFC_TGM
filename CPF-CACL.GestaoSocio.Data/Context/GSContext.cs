using CPF_CACL.GestaoSocio.Data.Map;
using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CPF_CACL.GestaoSocio.Data.Context
{
    public class GSContext : DbContext
    {
        public GSContext(DbContextOptions<GSContext> options) : base(options){}

        //Tabelas
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Apoio> Apoio { get; set; }
        public DbSet<Beneficio> Beneficio { get; set; }
        public DbSet<Capital> Capital { get; set; }
        public DbSet<CategoriaSocio> CategoriaSocio { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<ItemApoio> ItemApoio { get; set; }
        public DbSet<Organismo> Organismo { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<TipoBeneficio> TipoBeneficio { get; set; }
        public DbSet<TipoPagamento> TipoPagamento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<TipoProjecto> TipoProjecto { get; set; }
        public DbSet<Projecto> Projecto { get; set; }
        public DbSet<ProjectoSocio> ProjectoSocio { get; set; }
        public DbSet<PedidoApoio> PedidoApoios { get; set; }
        public DbSet<Relacao> Relacao { get; set; }

        public DbSet<TipoItem> TipoItem { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemPagamento> ItemPagamento { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Periodo> Periodo { get; set; } 
        public DbSet<Saldo> Saldo { get; set; } 
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplicar os mapeamentos (Map)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GSContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
