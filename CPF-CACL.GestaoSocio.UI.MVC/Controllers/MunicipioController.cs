using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class MunicipioController : BaseController
    {
        private readonly IMunicipioAppService _municipioAppService;
        public MunicipioController(IMunicipioAppService municipioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _municipioAppService = municipioAppService;
        }


        // GET: MunicipioController
        public ActionResult Index()
        {
            var municipio = _municipioAppService.Buscar();

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
        public ActionResult Create(MunicipioViewModel viewModel)
        {
            try
            {
                var municipio = new MunicipioViewModel()
                {
                    Nome = viewModel.Nome,
                    Status = "true"
                };
                _municipioAppService.Adicionar(municipio);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adiciondo com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }

        }

        // GET: MunicipioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MunicipioController/Edit/5
        [HttpPost]
        public ActionResult Edit(int municipioId, string Nome, DateTime dataCriacao, DateTime dataAtualizacao)
        {
            try
            {
                var municipio = new MunicipioViewModel()
                {
                    Id = municipioId,
                    Nome = Nome,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataAtualizacao
                };
                _municipioAppService.Atualizar(municipio);

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

        //Ação de exibir noticação
        public ActionResult Exibir()
        {
            var a = "a";
            if (a == "a")
            {
                ViewBag.MensagemSucesso = "Operação sucesso";
                return View();
            }
            else
            {
                ViewBag.MensagemSucesso = "Operação erro";
                return View();
            }
        }

        // GET: MunicipioController/Delete/5
        public ActionResult Delete()
        {
            return RedirectToAction();
        }

        // POST: MunicipioController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _municipioAppService.Eliminar(id);

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
