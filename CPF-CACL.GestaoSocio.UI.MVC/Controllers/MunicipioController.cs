using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly IMunicipioAppService _municipioAppService;
        public MunicipioController(IMunicipioAppService municipioAppService)
        {
            _municipioAppService = municipioAppService;
        }


        // GET: MunicipioController
        public ActionResult Index()
        {
            var municipio = _municipioAppService.BuscarMunicipios();

            return View(municipio);
        }

        // GET: MunicipioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MunicipioController/Create
        public ActionResult Create()
        {
            MunicipioViewModel mn = new MunicipioViewModel();
            return PartialView("Create",mn);
        }

         // POST: TipoPagamentoController/Create
        [HttpPost]
        public ActionResult Create(MunicipioViewModel municipio)
        {
            _municipioAppService.Add(municipio);
            return RedirectToAction("Index");
        
        }

        // GET: MunicipioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MunicipioController/Edit/5
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

        // GET: MunicipioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MunicipioController/Delete/5
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
