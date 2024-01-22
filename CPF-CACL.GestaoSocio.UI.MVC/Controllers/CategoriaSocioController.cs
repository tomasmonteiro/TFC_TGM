using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class CategoriaSocioController : BaseController
    {
        private readonly ICategoriaSocioAppService _categoriaSocioAppService;
        public CategoriaSocioController(ICategoriaSocioAppService categoriaSocioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _categoriaSocioAppService = categoriaSocioAppService;
        }


        // GET: CategoriaSocioController
        public ActionResult Index()
        {
            var categorias = _categoriaSocioAppService.Buscar();
            return View(categorias);
        }

        // GET: CategoriaSocioController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: CategoriaSocioController/Create
        public ActionResult Create()
        {
            CategoriaSocioViewModel cs = new CategoriaSocioViewModel();
            return PartialView("Create", cs);
        }

        // POST: CategoriaSocioController/Create
        [HttpPost]
        public ActionResult Create(CategoriaSocioViewModel categoria)
        {
            _categoriaSocioAppService.Adicionar(categoria);
            return RedirectToAction("Index");
        }

        // GET: CategoriaSocioController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: CategoriaSocioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
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

        // GET: CategoriaSocioController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: CategoriaSocioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
