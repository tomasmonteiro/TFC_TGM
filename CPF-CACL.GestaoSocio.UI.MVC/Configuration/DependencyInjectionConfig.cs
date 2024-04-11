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

            services.AddScoped<IEmolumentoRepository, EmolumentoRepository>();
            services.AddScoped<IEmolumentoAppService, EmolumentoAppService>();
            services.AddScoped<IEmolumentoService, EmolumentoService>();

            services.AddScoped<ITipoEmolumentoRepository, TipoEmolumentoRepository>();
            services.AddScoped<ITipoEmolumentoAppService, TipoEmolumentoAppService>();
            services.AddScoped<ITipoEmolumentoService, TipoEmolumentoService>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoAppService, PagamentoAppService>();
            services.AddScoped<IPagamentoService, PagamentoService>();

			services.AddScoped<IPagamentoEmolumentoRepository, PagamentoEmolumentoRepository>();
			services.AddScoped<IPagamentoEmolumentoAppService, PagamentoEmolumentoAppService>();
			services.AddScoped<IPagamentoEmolumentoService, PagamentoEmolumentoService>();

			services.AddScoped<IPeriodoRepository, PeriodoRepository>();
            services.AddScoped<IPeriodoAppService, PeriodoAppService>();
            services.AddScoped<IPeriodoService, PeriodoService>();

            services.AddScoped<IDependenteRepository, DependenteRepository>();
            services.AddScoped<IDependenteAppService, DependenteAppService>();
            services.AddScoped<IDependenteService, DependenteService>();

            services.AddScoped<ISaldoRepository, SaldoRepository>();
            services.AddScoped<ISaldoAppService, SaldoAppService>();
            services.AddScoped<ISaldoService, SaldoService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();
            services.AddScoped<IFornecedorService, FornecedorService>();

            services.AddScoped<ITipoBeneficioRepository, TipoBeneficioRepository>();
            services.AddScoped<ITipoBeneficioAppService, TipoBeneficioAppService>();
            services.AddScoped<ITipoBeneficioService, TipoBeneficioService>();

            services.AddScoped<IBeneficioRepository, BeneficioRepository>();
            services.AddScoped<IBeneficioAppService, BeneficioAppService>();
            services.AddScoped<IBeneficioService, BeneficioService>();

            services.AddScoped<ICapitalRepository, CapitalRepository>();
            services.AddScoped<ICapitalAppService, CapitalAppService>();
            services.AddScoped<ICapitalService, CapitalService>();

            services.AddScoped<IApoioRepository, ApoioRepository>();
            services.AddScoped<IApoioAppService, ApoioAppService>();
            services.AddScoped<IApoioService, ApoioService>();

            services.AddScoped<IItemApoioRepository, ItemApoioRepository>();
            services.AddScoped<IItemApoioAppService, ItemApoioAppService>();
            services.AddScoped<IItemApoioService, ItemApoioService>();

            services.AddScoped<IDespesaRepository, DespesaRepository>();
            services.AddScoped<IDespesaAppService, DespesaAppService>(); 
            services.AddScoped<IDespesaService, DespesaService>();

            services.AddScoped<IUsuarioSocioRepository, UsuarioSocioRepository>();
            //services.AddScoped<IUsuarioSocioAppService, UsuarioSocioAppService>();
            //services.AddScoped<IUsuarioSocioService, UsuarioSocioService>();


            services.AddScoped<ITipoApoioRepository, TipoApoioRepository>();
            services.AddScoped<ITipoApoioAppService, TipoApoioAppService>();
            services.AddScoped<ITipoApoioService, TipoApoioService>();

            services.AddScoped<ITipoDeclaracaoRepository, TipoDeclaracaoRepository>();
            services.AddScoped<ITipoDeclaracaoAppService, TipoDeclaracaoAppService>();
            services.AddScoped<ITipoDeclaracaoService, TipoDeclaracaoService>();

            services.AddScoped<ISolicitacaoDeclaracaoRepository, SolicitacaoDeclaracaoRepository>();
            services.AddScoped<ISolicitacaoDeclaracaoAppService, SolicitacaoDeclaracaoAppService>();
            services.AddScoped<ISolicitacaoDeclaracaoService, SolicitacaoDeclaracaoService>();

            services.AddScoped<ISolicitacaoApoioRepository, SolicitacaoApoioRepository>();
            services.AddScoped<ISolicitacaoApoioAppService, SolicitacaoApoioAppService>();
            services.AddScoped<ISolicitacaoApoioService, SolicitacaoApoioService>();


            return services;
        }
    }
}
