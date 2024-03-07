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

    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _usuarioAppService = usuarioAppService;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var socio = _usuarioAppService.BuscarTodos();
            return View(socio);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var usuario = _usuarioAppService.BuscarPorId(id);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        public ActionResult Criar(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioAppService.Adicionar(usuario);

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

        // GET: UsuarioController/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        public ActionResult Editar(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                _usuarioAppService.Atualizar(usuarioViewModel);

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
                _usuarioAppService.Inativar(id);

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
                var usuario = _usuarioAppService.BuscarPorId(id);
                if (usuario == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _usuarioAppService.Eliminar(usuario);

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

