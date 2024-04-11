using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Presidente", "Tesoureiro", "Secretario", "Vogal")]
    public class SolicitacoesApoioController : BaseController
    {
        private readonly IUsuarioSocioRepository _usuarioSocioRepository;

        private readonly ISocioRepository _socioRepository;
        private readonly ITipoApoioRepository _tipoApoioRepository;
        private readonly ISolicitacaoApoioAppService _solicitacaoApoioAppService;
        public SolicitacoesApoioController(ISolicitacaoApoioAppService solicitacaoApoioAppService, ITipoApoioRepository tipoApoioRepository, ISocioRepository socioRepository, IUsuarioSocioRepository usuarioSocioRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _solicitacaoApoioAppService = solicitacaoApoioAppService;
            _usuarioSocioRepository = usuarioSocioRepository;
            _socioRepository = socioRepository;
            _tipoApoioRepository = tipoApoioRepository;
        }

        public IActionResult Index()
        {
            var solicitacoes = _solicitacaoApoioAppService.BuscarTodos();

            return View(solicitacoes);
        }


    }
}
