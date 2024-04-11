using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Presidente", "Tesoureiro", "Secretario", "Vogal")]
    public class SolicitacoesDeclaracaoController : BaseController
    {
        private readonly IUsuarioSocioRepository _usuarioSocioRepository;

        private readonly ISocioAppService _socioAppService;
        private readonly ITipoDeclaracaoRepository _tipoDeclaracaoRepository;
        private readonly ISolicitacaoDeclaracaoAppService _solicitacaoDeclaracaoAppService;
        private readonly IBairroRepository _bairroRepository;
        private readonly ICategoriaSocioRepository _categoriaRepository;
        public SolicitacoesDeclaracaoController(IBairroRepository bairroRepository, ICategoriaSocioRepository categoriaRepository,  ISolicitacaoDeclaracaoAppService solicitacaoDeclaracaoAppService, ITipoDeclaracaoRepository tipoDeclaracaoRepository, ISocioAppService socioAppService, IUsuarioSocioRepository usuarioSocioRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _solicitacaoDeclaracaoAppService = solicitacaoDeclaracaoAppService;
            _usuarioSocioRepository = usuarioSocioRepository;
            _socioAppService = socioAppService;
            _tipoDeclaracaoRepository = tipoDeclaracaoRepository;
            _bairroRepository = bairroRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index()
        {
            var solicitacoes = _solicitacaoDeclaracaoAppService.BuscarTodos();
            return View(solicitacoes);
        }
        public ActionResult Imprimir(Guid id)
        {
            var solicitacao = _solicitacaoDeclaracaoAppService.BuscarPorId(id);

            var socio = _socioAppService.BuscarPorId(solicitacao.SocioId);
            var data = DateTime.Now;
            ViewBag.Dia = data.Day.ToString();
            ViewBag.Mes = data.ToString("MMMM", CultureInfo.CurrentCulture);
            ViewBag.Ano = data.Year.ToString();

            var bairro = _bairroRepository.GetById(socio.BairroId);
            var categoria = _categoriaRepository.GetById(socio.CategoriaSocioId);
            ViewBag.SocioNome = socio.Nome;
            ViewBag.SocioBI = socio.BI;
            ViewBag.Categoria = categoria.Nome;
            ViewBag.CodSocio = socio.Codigo;
            ViewBag.Bairro = bairro.Nome;
            ViewBag.Endereco = socio.Endereco;
            ViewBag.DataAtual = DateTime.Now;

            return View(solicitacao);
        }

    }
}
