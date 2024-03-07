using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Autorizacao("Admin")]
    public class ConfiguracoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
