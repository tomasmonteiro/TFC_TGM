using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Vogal", "Secretario", "Tesoureiro", "Presidente")]
    public class ContactoController : BaseController
    {
        public ContactoController(INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
