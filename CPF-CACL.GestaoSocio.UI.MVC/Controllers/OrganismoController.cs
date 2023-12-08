using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class OrganismoController : Controller
    {
        private readonly IOrganismoAppService _organismoAppService;

        public OrganismoController(IOrganismoAppService organismoAppService)
        {
            _organismoAppService = organismoAppService;
        }

        // GET: OrganismoController
        public ActionResult Index()
        {
            var organismo = _organismoAppService.Buscar();

            return View(organismo);
        }

        // GET: OrganismoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismoController/Create
        public ActionResult Create()
        {
            OrganismoViewModel org = new OrganismoViewModel();
            return PartialView("Create", org);
        }

        // POST: OrganismoController/Create
        [HttpPost]
        public ActionResult Create(OrganismoViewModel organismoViewModel)
        {

            var organismo = new OrganismoViewModel()
            {
                Nome = organismoViewModel.Nome,
                DataCriacao = DateTime.Now,
                Status = "true"
            };
            _organismoAppService.Adicionar(organismo);
            return RedirectToAction("Index");

        }

        // GET: OrganismoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismoController/Edit/5
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

        // GET: OrganismoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismoController/Delete/5
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
