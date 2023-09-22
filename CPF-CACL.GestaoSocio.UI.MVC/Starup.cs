
using CPF_CACL.GestaoSocio.Aplication.AutoMapper;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.UI.MVC
{
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adição dos serviços
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<GSContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Resoluçaõ de injecção de dependências
            services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();

            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}