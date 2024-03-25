using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Autorizacao("Admin")]
    public class TipoBeneficioController : BaseController
    {
        private readonly ITipoBeneficioAppService _tipoBeneficioAppService;
        public TipoBeneficioController(ITipoBeneficioAppService tipoBeneficioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoBeneficioAppService = tipoBeneficioAppService;
        }

        // GET: TipoBeneficioController
        public ActionResult Index()
        {
            var tipoBeneficio = _tipoBeneficioAppService.BuscarTodos();
            return View(tipoBeneficio);
        }

        // GET: TipoBeneficioController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var tipoBeneficio = _tipoBeneficioAppService.BuscarPorId(id);
            return View(tipoBeneficio);
        }

        // GET: TipoBeneficioController/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: TipoBeneficioController/Criar
        [HttpPost]
        public ActionResult Criar(TipoBeneficioViewModel tipoBeneficio)
        {
            try
            {
                _tipoBeneficioAppService.Adicionar(tipoBeneficio);

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

        // GET: TipoBeneficioController/Editar/5
        public ActionResult Editar(Guid id)
        {
            var tipoBeneficio = _tipoBeneficioAppService.BuscarPorId(id);
            return View(tipoBeneficio);
        }

        // POST: TipoBeneficioController/Editar/5
        [HttpPost]
        public ActionResult Editar(TipoBeneficioViewModel tipoBeneficio)
        {
            try
            {
                _tipoBeneficioAppService.Atualizar(tipoBeneficio);

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

        // GET: TipoBeneficioController/Eliminar/5
        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                var tipoBeneficio = _tipoBeneficioAppService.BuscarPorId(id);
                if (tipoBeneficio == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _tipoBeneficioAppService.Eliminar(tipoBeneficio);

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

        // POST: TipoBeneficioController/Inativar/5
        [HttpPost]
        public ActionResult Inativar(Guid id)
        {
            try
            {
                _tipoBeneficioAppService.Inativar(id);

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
