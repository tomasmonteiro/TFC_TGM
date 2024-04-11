using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin")]
    public class TipoApoioController : BaseController
    {
        private readonly ITipoApoioRepository _tipoApoioRepository;
        private readonly ITipoApoioAppService _tipoApoioAppService; 
        //
        public TipoApoioController(ITipoApoioRepository tipoApoioRepository, ITipoApoioAppService tipoApoioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoApoioRepository = tipoApoioRepository;
            _tipoApoioAppService = tipoApoioAppService;
        }

        // GET: TipoApoioController
        public ActionResult Index()
        {

            var tipoPagamento = _tipoApoioAppService.BuscarTodos();

            return View(tipoPagamento);
        }

        // GET: TipoApoioController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: TipoApoioController/Create
        public ActionResult Create()
        {
            TipoApoioViewModel tApoio = new TipoApoioViewModel();
            return PartialView("Create", tApoio);
        }

        // POST: TipoApoioController/Create
        [HttpPost]
        public ActionResult Create(TipoApoioViewModel tipoApoio)
        {
            try
            {
                var tipoApoioViewModel = new TipoApoioViewModel()
                {
                    Tipo = tipoApoio.Tipo,
                    DataCriacao = DateTime.Now,
                    Status = tipoApoio.Status
                };
                _tipoApoioAppService.Adicionar(tipoApoioViewModel);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adicionado com sucesso");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: TipoApoioController/Editar/5
        public ActionResult Editar(Guid id)
        {
            return View();
        }

        // POST: TipoApoioController/Editar/5
        [HttpPost]
        public ActionResult Editar(TipoApoioViewModel tipoApoio)
        {
            try
            {
                var tipoApoioViewModel = new TipoApoioViewModel()
                {
                    Id = tipoApoio.Id,
                    Tipo = tipoApoio.Tipo,
                    DataCriacao = tipoApoio.DataCriacao,
                    Status = tipoApoio.Status
                };
                _tipoApoioAppService.Atualizar(tipoApoioViewModel);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo atualizado com sucesso");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: TipoApoioController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: TipoApoioController/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
