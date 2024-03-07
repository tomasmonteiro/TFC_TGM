using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.ViewComponents
{
    public class NotificacoesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            var notificacao = new Notificacao
            {
                Mensagem = "4"
            };
            return View(notificacao); 
        }
    }
}
