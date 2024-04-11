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
    public class TipoApoioController : BaseController
    {
        private readonly ITipoApoioAppService _tipoApoioAppService;
        public TipoApoioController(ITipoApoioAppService tipoApoioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoApoioAppService = tipoApoioAppService;
        }

        // GET: TipoApoioController
        public ActionResult Index()
        {
            var tipoApoio = _tipoApoioAppService.BuscarTodos();
            return View(tipoApoio);
        }

        // GET: TipoBeneficioController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var tipoApoio = _tipoApoioAppService.BuscarPorId(id);
            return View(tipoApoio);
        }

        // GET: TipoApoioController/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: TipoApoioController/Criar
        [HttpPost]
        public ActionResult Criar(TipoApoioViewModel tipoApoio)
        {
            try
            {
                _tipoApoioAppService.Adicionar(tipoApoio);

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
            var tipoApoio = _tipoApoioAppService.BuscarPorId(id);
            return View(tipoApoio);
        }

        // POST: TipoBeneficioController/Editar/5
        [HttpPost]
        public ActionResult Editar(TipoApoioViewModel tipoApoio)
        {
            try
            {
                _tipoApoioAppService.Atualizar(tipoApoio);

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
                var tipoApoio = _tipoApoioAppService.BuscarPorId(id);
                if (tipoApoio == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _tipoApoioAppService.Eliminar(tipoApoio);

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
                _tipoApoioAppService.Inativar(id);

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
