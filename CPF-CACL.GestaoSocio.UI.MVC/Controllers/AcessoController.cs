using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class AcessoController : BaseController
    {
        public AcessoController(INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (userName == "tg" && password == "123")
            {
                TempData["Erro"] = "Crendencias inválidas.";
                return View();
            }
            else
            {
                ////await _userAppService.FindByUserName(userName);
                //var user = "";
                //if (user == null)
                //{
                //    TempData["Erro"] = "O seu utilizador não possui acesso a plataforma.";
                //    return View();
                //}
                ////HttpContext.Session.SetString("userId", user.Id.ToString());
                //HttpContext.Session.SetString("userName", userName);
                ////HttpContext.Session.SetString("nome", user.Name);

                var url = string.Empty;
                if (Request.Query["returnUrl"].ToString() == string.Empty)
                {
                    url = "/Home/Index";
                }
                else
                {
                    url = Request.Query["returnUrl"].ToString();
                }

                return Redirect(url);
            }
        }
        [HttpPost]
        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("user");
            //HttpContext.Session.Remove("nome");
            //HttpContext.Session.Remove("userId");
            //HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
