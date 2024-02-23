using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class AcessoController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IHttpContextAccessor _contextAccessor;
        public AcessoController(IUsuarioAppService usuarioAppService, IHttpContextAccessor contextAccessor, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _usuarioAppService = usuarioAppService;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Login()
        {
            if (_contextAccessor.HttpContext.Session.GetString("nome") != null)
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioAppService.BuscarPorLogin(loginViewModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginViewModel.Senha))
                        {
                            HttpContext.Session.SetString("userId", usuario.Id.ToString());
                            HttpContext.Session.SetString("userName", usuario.Login);
                            HttpContext.Session.SetString("perfil", usuario.Perfil.ToString());
                            HttpContext.Session.SetString("nome", usuario.Nome);

                            var url = string.Empty;
                            if (Request.Query["returnUrl"].ToString() == string.Empty)
                            {
                                if (usuario.Perfil == EPerfilUsuario.Admin)
                                {
                                    url = Url.Action("Index", "Home", new {area = "Admin"});
                                }
                                else if (usuario.Perfil == EPerfilUsuario.Socio)
                                {
                                    url = Url.Action("Index", "Home", new { area = "Socio" });
                                }
                                else
                                {
                                    url = "/Home/Index";
                                }
                            }
                            else
                            {
                                url = Request.Query["returnUrl"].ToString();
                            }

                            return Redirect(url);
                        }
                        TempData["Erro"] = "Senha inválida.";
                        return View();
                    }
                    else
                    {
                        TempData["Erro"] = "Usuário e/ou senha invalido(s).";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
            
        }
        
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("nome");
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("perfil");
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
