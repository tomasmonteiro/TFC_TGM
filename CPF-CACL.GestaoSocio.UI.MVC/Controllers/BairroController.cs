using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class BairroController : Controller
    {
        private readonly IMunicipioAppService _municipioAppService;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IBairroAppService _bairroAppService;
        public BairroController(IMunicipioAppService municipioAppService,IBairroAppService bairroAppService, IMunicipioRepository municipioRepository)
        {
            _municipioAppService = municipioAppService;
            _municipioRepository = municipioRepository;
            _bairroAppService = bairroAppService;

        }


        // GET: BairroController
        public ActionResult Index()
        {
            var bairro = _bairroAppService.BuscarBairros();
            return View(bairro);
        }

        // GET: BairroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BairroController/Create
        public ActionResult Create()
        {
            var viewModel = new BairroViewModel();
            var dadosDaTabela = _municipioRepository.BuscarTodos();
            viewModel.Municipio = dadosDaTabela
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            return PartialView("Create",viewModel);
        }

        // POST: BairroController/Create
        [HttpPost]
        public ActionResult Create(BairroViewModel bairro)
        {
            _bairroAppService.Add(bairro);
            return RedirectToAction("Index");
        }

        // GET: BairroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BairroController/Edit/5
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

        // GET: BairroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BairroController/Delete/5
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
