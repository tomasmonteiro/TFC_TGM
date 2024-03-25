using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Presidente", "Tesoureiro", "Secretario", "Vogal")]
    public class ApoioController : BaseController
    {
        private readonly IApoioAppService _apoioAppService;
        private readonly ITipoBeneficioRepository _tipoBeneficioRepository;
        private readonly ISocioAppService _socioAppService;
        private readonly ISocioService _socioService;
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly IBeneficioRepository _beneficioRepository;
        public ApoioController(IFornecedorAppService fornecedorAppService, IBeneficioRepository beneficioRepository, IApoioAppService apoioAppService, ITipoBeneficioRepository tipoBeneficioRepository, ISocioAppService socioAppService, ISocioService socioService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _apoioAppService = apoioAppService;
            _tipoBeneficioRepository = tipoBeneficioRepository;
            _socioAppService = socioAppService;
            _beneficioRepository = beneficioRepository;
            _fornecedorAppService = fornecedorAppService;
            _socioService = socioService;
        }

        public IActionResult Index()
        {
            var apoio = _apoioAppService.BuscarTodosAtivos();
            return View(apoio);
        }

        // GET: ApoioController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var apoio = _apoioAppService.BuscarPorId(id);
            return View(apoio);
        }

        // GET: ApoioController/Criar
        public ActionResult Criar(Guid id)
        {
            var socio = _socioAppService.BuscarPorId(id);
            ViewBag.Socio = socio;


            var viewModel = new BeneficioViewModel();

            var tiposBeneficio = _tipoBeneficioRepository.BuscarTodos();
            tiposBeneficio = tiposBeneficio.OrderBy(m => m.Nome).ToList();
            ViewBag.TiposBeneficio = viewModel.TipoBeneficio
                = tiposBeneficio
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            var viewModel2 = new ItemApoioViewModel();

            var fornecedor = _fornecedorAppService.BuscarTodos();
            fornecedor = fornecedor.OrderBy(m => m.Nome).ToList();
            ViewBag.Fornecedor = viewModel2.Fornecedor
                = fornecedor
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();




            var apoio = new ApoioViewModel();


            return View("Criar", apoio);
        }

        // POST: ApoioController/Criar
        [HttpPost]
        public ActionResult Criar([FromBody]List<DadosApoioViewModel> dataToSend)
        {
            try
            {

                _apoioAppService.AdicionarApoio(dataToSend);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adicionado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: ApoioController/Editar/5
        public ActionResult Editar(Guid id)
        {
            var apoio = _apoioAppService.BuscarPorId(id);
            return View(apoio);
        }

        // POST: ApoioController/Editar/5
        [HttpPost]
        public ActionResult Editar(ApoioViewModel apoio)
        {
            try
            {
                _apoioAppService.Atualizar(apoio);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: ApoioController/Eliminar/5
        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                var apoio = _apoioAppService.BuscarPorId(id);
                if (apoio == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _apoioAppService.Eliminar(apoio);

                    if (!ValidOperation())
                    {
                        var sb = new StringBuilder();
                        foreach (var item in BuscarMensagemErro())
                        {
                            sb.AppendLine($"x {item}\n");
                        }
                        return Json(sb.ToString());
                    }
                    return Json("Registo eliminado com sucesso!");
                }
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // POST: ApoioController/Inativar/5
        [HttpPost]
        public ActionResult Inativar(Guid id)
        {
            try
            {
                _apoioAppService.Inativar(id);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo inativado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
        //Buscar Beneficio por Tipo
        [HttpGet]
        public IActionResult GetBeneficioPorTipo(Guid tipoId)
        {
            var beneficios = _beneficioRepository.BuscarPorTipo(tipoId);
            beneficios = beneficios.OrderBy(m => m.Nome).ToList();
            return Json(beneficios);

        }
        //Buscar Valor do Capital
        [HttpGet]
        public IActionResult GetValorCapital(Guid benefiioId, Guid socioId)
        {
            var valor = _socioService.BuscarValorCapital(socioId, benefiioId);
            return Json(valor);

        }
    }
}
