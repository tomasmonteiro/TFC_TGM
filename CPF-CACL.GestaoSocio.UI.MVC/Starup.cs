
using CPF_CACL.GestaoSocio.Aplication.AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;
using CPF_CACL.GestaoSocio.UI.MVC.Configuration;
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
            // Adição dos Middlewares
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<GSContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
            services.AddMvcCore().AddRazorViewEngine();
            //Resoluçaõ de injecção de dependências
            services.AddDependencyInjection();

           
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

            app.MapControllerRoute(
                name: "buscarDados",
                pattern: "{controller=Socio}/{action=BuscarDados}/{opcaoSelecionada?}",
                defaults: new { controller = "Socio", action="BuscarDados"});
        }
    }
}