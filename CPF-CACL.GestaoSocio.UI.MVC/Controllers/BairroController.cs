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
        public BairroController(IMunicipioAppService municipioAppService, IBairroAppService bairroAppService, IMunicipioRepository municipioRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
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
        public ActionResult Details(Guid id)
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

            return PartialView("Create", viewModel);
        }

        // POST: BairroController/Create
        [HttpPost]
        public ActionResult Create(BairroViewModel viewModel)
        {
            try
            {
                var bairro = new BairroViewModel()
                {

                    Nome = viewModel.Nome,
                    MunicipioId = viewModel.MunicipioId
                };
                _bairroAppService.Adicionar(bairro);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adicionado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: BairroController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: BairroController/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid bairroId, Guid municipioId, string Nome, DateTime dataCriacao, DateTime dataAtualizacao)
        {
            try
            {
                var bairro = new BairroViewModel()
                {
                    Id = bairroId,
                    MunicipioId = municipioId,
                    Nome = Nome,
                    DataCriacao = dataCriacao,
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
                return Json("Registo actualizado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: BairroController/Delete/5
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: BairroController/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _bairroAppService.Eliminar(id);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo eliminado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
