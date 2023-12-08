using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class BairroController : BaseController
    {
        private readonly IMunicipioAppService _municipioAppService;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IBairroAppService _bairroAppService;
        public BairroController(IMunicipioAppService municipioAppService,IBairroAppService bairroAppService, IMunicipioRepository municipioRepository, INotificador notificador) : base(notificador)
        {
            _municipioAppService = municipioAppService;
            _municipioRepository = municipioRepository;
            _bairroAppService = bairroAppService;

        }


        // GET: BairroController
        public ActionResult Index()
        {
            var bairro = _bairroAppService.Buscar();
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
            var municipios = _municipioRepository.BuscarTodos();
            municipios = municipios.OrderBy(m => m.Nome).ToList();
            viewModel.Municipio = municipios
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
        public ActionResult Create(BairroViewModel viewModel )
        {
            var bairro = new BairroViewModel()
            {

                Nome = viewModel.Nome,
                MunicipioId = viewModel.MunicipioId
            };

            _bairroAppService.Adicionar(bairro);
            return Json("Registo adicionado com sucesso!");
        }

        // GET: BairroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BairroController/Edit/5
        [HttpPost]
        public ActionResult Edit(int bairroId, string Nome, DateTime dataAtualizacao)
        {
            try
            {
                var bairro = new BairroViewModel()
                {
                    Id = bairroId,
                    Nome = Nome,
                    DataAtualizacao = dataAtualizacao
                };
                _bairroAppService.Atualizar(bairro);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adicionado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
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
