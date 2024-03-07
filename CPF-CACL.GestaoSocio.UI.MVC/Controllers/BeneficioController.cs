using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Vogal", "Secretario", "Tesoureiro")]
    public class BeneficioController : BaseController
    {
        private readonly IBeneficioAppService _beneficioAppService;
        private readonly ITipoBeneficioRepository _tipoBeneficioRepository;
        public BeneficioController(IBeneficioAppService beneficioAppService,ITipoBeneficioRepository tipoBeneficioRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _beneficioAppService = beneficioAppService;
            _tipoBeneficioRepository = tipoBeneficioRepository;
        }

        public IActionResult Index()
        {
            var beneficio = _beneficioAppService.BuscarTodosAtivos();
            return View(beneficio);
        }

        // GET: BeneficioController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var beneficio = _beneficioAppService.BuscarPorId(id);
            return View(beneficio);
        }

        // GET: BeneficioController/Criar
        public ActionResult Criar()
        {
            var viewModel = new BeneficioViewModel();
            var tipos = _tipoBeneficioRepository.BuscarTodos();
            tipos = tipos.OrderBy(m => m.Nome).ToList();
            viewModel.TipoBeneficio = tipos
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            return PartialView("Criar", viewModel);
        }

        // POST: BeneficioController/Criar
        [HttpPost]
        public ActionResult Criar(BeneficioViewModel beneficio)
        {
            try
            {
                _beneficioAppService.Adicionar(beneficio);

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

        // GET: BeneficioController/Editar/5
        public ActionResult Editar(Guid id)
        {
            var beneficio = _beneficioAppService.BuscarPorId(id);
            return View(beneficio);
        }

        // POST: BeneficioController/Editar/5
        [HttpPost]
        public ActionResult Editar(BeneficioViewModel beneficio)
        {
            try
            {
                _beneficioAppService.Atualizar(beneficio);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: BeneficioController/Eliminar/5
        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                var beneficio = _beneficioAppService.BuscarPorId(id);
                if (beneficio == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _beneficioAppService.Eliminar(beneficio);

                    if (!ValidOperation())
                    {
                        var sb = new StringBuilder();
                        foreach (var item in BuscarMensagemErro())
                        {
                            sb.AppendLine($"x {item}\n");
                        }
                        return Json(sb.ToString());
                    }
                    return Json("Registo eliminado com sucesso!");
                }
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // POST: BeneficioController/Inativar/5
        [HttpPost]
        public ActionResult Inativar(Guid id)
        {
            try
            {
                _beneficioAppService.Inativar(id);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo inativado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
