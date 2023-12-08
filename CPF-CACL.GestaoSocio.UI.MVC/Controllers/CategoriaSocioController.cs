using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class CategoriaSocioController : Controller
    {
        private readonly ICategoriaSocioAppService _categoriaSocioAppService;
        public CategoriaSocioController(ICategoriaSocioAppService categoriaSocioAppService)
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriaSocioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaSocioController/Create
        [HttpPost]
        public ActionResult Create(CategoriaSocioViewModel categoria)
        {
            _categoriaSocioAppService.Adicionar(categoria);
            return RedirectToAction("Index");
        }

        // GET: CategoriaSocioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriaSocioController/Edit/5
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

        // GET: CategoriaSocioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaSocioController/Delete/5
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
