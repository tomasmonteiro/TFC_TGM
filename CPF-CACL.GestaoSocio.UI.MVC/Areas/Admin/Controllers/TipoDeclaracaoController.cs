using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Autorizacao("Admin")]
    public class TipoDeclaracaoController : BaseController
    {
        private readonly ITipoDeclaracaoAppService _tipoDeclaracaoAppService;
        public TipoDeclaracaoController(ITipoDeclaracaoAppService tipoDeclaracaoAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoDeclaracaoAppService = tipoDeclaracaoAppService;
        }

        // GET: TipoBeneficioController
        public ActionResult Index()
        {
            var tipoDeclaracao = _tipoDeclaracaoAppService.BuscarTodos();
            return View(tipoDeclaracao);
        }

        // GET: TipoBeneficioController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var tipoDeclaracao = _tipoDeclaracaoAppService.BuscarPorId(id);
            return View(tipoDeclaracao);
        }

        // GET: TipoBeneficioController/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: TipoBeneficioController/Criar
        [HttpPost]
        public ActionResult Criar(TipoDeclaracaoViewModel tipoDeclaracao)
        {
            try
            {
                _tipoDeclaracaoAppService.Adicionar(tipoDeclaracao);

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
            var tipoDeclaracao = _tipoDeclaracaoAppService.BuscarPorId(id);
            return View(tipoDeclaracao);
        }

        // POST: TipoBeneficioController/Editar/5
        [HttpPost]
        public ActionResult Editar(TipoDeclaracaoViewModel tipoDeclaracao)
        {
            try
            {
                _tipoDeclaracaoAppService.Atualizar(tipoDeclaracao);

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
                var tipoDeclaracao = _tipoDeclaracaoAppService.BuscarPorId(id);
                if (tipoDeclaracao == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _tipoDeclaracaoAppService.Eliminar(tipoDeclaracao);

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
                _tipoDeclaracaoAppService.Inativar(id);

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
