using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        } 
    }
}
