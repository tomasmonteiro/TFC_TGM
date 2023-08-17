using CPF_CACL.GestaoSocio.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class GSContext : DbContext
    {
        public GSContext(DbContextOptions<GSContext> options):base(options){}

        //Tabelas
        public DbSet<FormaPagamento> FormaPagamento { get; set; }

    }
}
