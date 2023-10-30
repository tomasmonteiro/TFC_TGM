using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class TipoPagamentoController : Controller
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        private readonly ITipoPagamentoAppService _tipoPagamentoAppService; 
        //
        public TipoPagamentoController(ITipoPagamentoRepository tipoPagamentoRepository, ITipoPagamentoAppService tipoPagamentoAppService)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
            _tipoPagamentoAppService = tipoPagamentoAppService;
        }

        // GET: TipoPagamentoController
        public ActionResult Index()
        {

            var tipoPagamento = _tipoPagamentoAppService.BuscarTodosTipo();

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
            return View();
        }

        // POST: TipoPagamentoController/Create
        [HttpPost]
        public ActionResult Create(TipoPagamentoViewModel  tipoPagamento)
        {
            _tipoPagamentoAppService.Add(tipoPagamento);
            return RedirectToAction("Index");
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
