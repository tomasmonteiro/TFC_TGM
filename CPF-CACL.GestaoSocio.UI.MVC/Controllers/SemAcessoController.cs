using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class SemAcessoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
