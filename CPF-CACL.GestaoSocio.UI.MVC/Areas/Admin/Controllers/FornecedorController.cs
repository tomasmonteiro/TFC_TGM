using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Autorizacao("Admin")]
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorController(IFornecedorAppService fornecedorAppService, IFornecedorRepository fornecedorRepository,  INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _fornecedorAppService = fornecedorAppService;
            _fornecedorRepository = fornecedorRepository;
        }

        public ActionResult Index()
        {
            var fornecedor = _fornecedorAppService.GetAll();
            return View(fornecedor);
        }

        public ActionResult Detalhes(Guid id)
        {
            var fornecedor = _fornecedorAppService.GetById(id);
            return View(fornecedor);
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(FornecedorViewModel fornecedor)
        {
            try
            {
                _fornecedorAppService.Add(fornecedor);

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

        public ActionResult Editar(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(FornecedorViewModel fornecedor)
        {
            try
            {
                _fornecedorAppService.Atualizar(fornecedor);

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


        [HttpPost]
        public ActionResult Inativar(Guid id)
        {
            try
            {
                _fornecedorAppService.Inativar(id);

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

        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                var fornecedor = _fornecedorAppService.GetById(id);
                if (fornecedor == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _fornecedorAppService.Eliminar(fornecedor);

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
    }
}
