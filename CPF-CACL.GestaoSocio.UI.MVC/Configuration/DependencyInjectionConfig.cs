using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.UI.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        //Resolução  das injecções de dependência
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();
            services.AddScoped<ITipoPagamentoAppService, TipoPagamentoAppService>();
            services.AddScoped<ITipoPagamentoService, TipoPagamentoService>();

            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IMunicipioAppService, MunicipioAppService>();
            services.AddScoped<IMunicipioService, MunicipioService>();

            services.AddScoped<IBairroRepository, BairroRepository>();
            services.AddScoped<IBairroAppService, BairroAppService>();
            services.AddScoped<IBairroService, BairroService>();

            services.AddScoped<ISocioRepository, SocioRepository>();
            services.AddScoped<ISocioAppService, SocioAppService>();
            services.AddScoped<ISocioService, SocioService>();

            services.AddScoped<ICategoriaSocioRepository, CategoriaSocioRepository>();
            services.AddScoped<ICategoriaSocioAppService, CategoriaSocioAppService>();
            services.AddScoped<ICategoriaSocioService, CategoriaSocioService>();

            services.AddScoped<IOrganismoRepository, OrganismoRepository>();
            services.AddScoped<IOrganismoAppService, OrganismoAppService>();
            services.AddScoped<IOrganismoService, OrganismoService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IRelacaoRepository, RelacaoRepository>();
            services.AddScoped<IRelacaoAppService, RelacaoAppService>();
            services.AddScoped<IRelacaoService, RelacaoService>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemAppService, ItemAppService>();
            services.AddScoped<IItemService, ItemService>();

            services.AddScoped<ITipoItemRepository, TipoItemRepository>();
            services.AddScoped<ITipoItemAppService, TipoItemAppService>();
            services.AddScoped<ITipoItemService, TipoItemService>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoAppService, PagamentoAppService>();
            services.AddScoped<IPagamentoService, PagamentoService>();

			services.AddScoped<IItemPagamentoRepository, ItemPagamentoRepository>();
			services.AddScoped<IItemPagamentoAppService, ItemPagamentoAppService>();
			services.AddScoped<IItemPagamentoService, ItemPagamentoService>();

			services.AddScoped<IPeriodoRepository, PeriodoRepository>();
            services.AddScoped<IPeriodoAppService, PeriodoAppService>();
            services.AddScoped<IPeriodoService, PeriodoService>();

            services.AddScoped<IAgregadoRepository, AgregadoRepository>();
            services.AddScoped<IAgregadoAppService, AgregadoAppService>();
            services.AddScoped<IAgregadoService, AgregadoService>();

            services.AddScoped<ISaldoRepository, SaldoRepository>();
            services.AddScoped<ISaldoAppService, SaldoAppService>();
            services.AddScoped<ISaldoService, SaldoService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
