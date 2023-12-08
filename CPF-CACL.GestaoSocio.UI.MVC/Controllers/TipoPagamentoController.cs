using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class TipoPagamentoController : BaseController
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        private readonly ITipoPagamentoAppService _tipoPagamentoAppService; 
        //
        public TipoPagamentoController(ITipoPagamentoRepository tipoPagamentoRepository, ITipoPagamentoAppService tipoPagamentoAppService, INotificador notificador) : base(notificador)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
            _tipoPagamentoAppService = tipoPagamentoAppService;
        }

        // GET: TipoPagamentoController
        public ActionResult Index()
        {

            var tipoPagamento = _tipoPagamentoAppService.Buscar();

            return View(tipoPagamento);
        }

        // GET: TipoPagamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoPagamentoController/Create
        public ActionResult Create()
        {
            TipoPagamentoViewModel tPagam = new TipoPagamentoViewModel();
            return PartialView("Create", tPagam);
        }

        // POST: TipoPagamentoController/Create
        [HttpPost]
        public ActionResult Create(TipoPagamentoViewModel  tipoPagamento)
        {
            try
            {
                var tipoPagamentoViewModel = new TipoPagamentoViewModel()
                {
                    Nome = tipoPagamento.Nome,
                    DataCriacao = tipoPagamento.DataCriacao,
                    Status = tipoPagamento.Status
                };
                _tipoPagamentoAppService.Adicionar(tipoPagamentoViewModel);

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

            //_tipoPagamentoAppService.Add(tipoPagamento);
            //return RedirectToAction("Index");
        }

        // GET: TipoPagamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoPagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TipoPagamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoPagamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
