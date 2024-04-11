using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Socio.Controllers
{
    [Area("Socio")]
    [Autorizacao("Socio")]
    public class DeclaracaoController : BaseController
    {
        private readonly ITipoDeclaracaoRepository _tipoDeclaracaoRepository;
        private readonly ISolicitacaoDeclaracaoAppService _solicitacaoDeclaracaoAppService;
        private readonly IUsuarioSocioRepository _usuarioSocioRepository;
        public DeclaracaoController(ITipoDeclaracaoRepository tipoDeclaracaoRepository, ISolicitacaoDeclaracaoAppService solicitacaoDeclaracaoAppService, IUsuarioSocioRepository usuarioSocioRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoDeclaracaoRepository = tipoDeclaracaoRepository;
            _solicitacaoDeclaracaoAppService = solicitacaoDeclaracaoAppService;
            _usuarioSocioRepository = usuarioSocioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Solicitar()
        {
            //Buscar os Tipo de Declaracao
            var viewModel = new SolicitacaoDeclaracaoViewModel();

            //Buscar Tipo de Decaracao para preencher o Select
            var tipos = _tipoDeclaracaoRepository.BuscarTodos();
            tipos = tipos.OrderBy(m => m.Tipo).ToList();
            ViewBag.TipoDeclaracao = viewModel.TipoDeclaracao
                = tipos
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Tipo
                })
                .ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Solicitar(SolicitacaoDeclaracaoViewModel solicitacaoDeclaracao)
        {
            try
            {
                var usuarioSocio = _usuarioSocioRepository.BuscarPorUsuarioId(solicitacaoDeclaracao.SocioId);
                solicitacaoDeclaracao.SocioId = usuarioSocio.SocioId;

                _solicitacaoDeclaracaoAppService.Adicionar(solicitacaoDeclaracao);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Solicitação efectuada com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }



    }
}
