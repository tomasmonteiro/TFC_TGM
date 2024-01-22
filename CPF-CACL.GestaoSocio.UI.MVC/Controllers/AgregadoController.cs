using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class AgregadoController : BaseController
    {
        private readonly IRelacaoAppService _relacaoAppService;
        private readonly IRelacaoRepository _relacaoRepository;
        private readonly IAgregadoAppService _agregadoAppService;
        public AgregadoController(IRelacaoAppService relacaoAppService, IAgregadoAppService agregadoAppService, IRelacaoRepository relacaoRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _relacaoAppService = relacaoAppService;
            _relacaoRepository = relacaoRepository;
            _agregadoAppService = agregadoAppService;
        }

        // GET: AgregadoController
        public ActionResult Index()
        {
            var agregado = _agregadoAppService.Buscar();
            return View(agregado);
        }

        // GET: AgregadoController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: AgregadoController/Create
        public ActionResult Create()
        {
            var viewModel = new AgregadoViewModel();
            var relacoes = _relacaoRepository.BuscarTodos();
            relacoes = relacoes.OrderBy(m => m.Nome).ToList();
            viewModel.Relacao = relacoes
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            return PartialView("Create", viewModel);
        }

        // POST: AgregadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AgregadoController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: AgregadoController/Edit/5
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

        // GET: AgregadoController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: AgregadoController/Delete/5
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

        public IActionResult ObterRelacao()
        {
            var relacao = _relacaoRepository.BuscarTodos();
            return Json(relacao);

        }
    }
}
