using Microsoft.AspNetCore.Mvc.Filters;

namespace CPF_CACL.GestaoSocio.UI.MVC.Extensions
{
    public class AutorizacaoAttribute : ActionFilterAttribute
    {
        private readonly string[] _perfil;
        public AutorizacaoAttribute(params string[] perfil)
        {
            _perfil = perfil;
        }
        public string Perfil { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Buscar o perfil do usuario logado
            var userPerfil = context.HttpContext.Session.GetString("perfil");
            //Verificar se perfil na Sessão está vazio
            if (string.IsNullOrEmpty( userPerfil ))
            {
                context.HttpContext.Response.Redirect("/Acesso/Login");
            }
            else
            {
                //Verificar se o perfil do usuário tem autorizado
                var autorizado = _perfil.Any(perfil => userPerfil.Contains(perfil));
                if (!(_perfil == null || _perfil.All(string.IsNullOrEmpty)))
                {
                    if (!autorizado)
                    {
                        context.HttpContext.Response.Redirect("/Home/SemAcesso");
                    }
                }
            }            
            base.OnActionExecuting(context);
        }
    }
}




//private string BuscarPerfilDoUsuario(ActionExecutingContext context)
//{
//    return context.HttpContext.Session.GetString("perfil");
//}






//public override void OnActionExecuting(ActionExecutingContext context)
//{
//    if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("userId")))
//    {
//        context.HttpContext.Response.Redirect("/Acesso/Login");
//    }
//    else
//    {
//        if (!string.IsNullOrEmpty(Perfil))
//        {
//            if (Perfil != context.HttpContext.Session.GetString("perfil"))
//            {
//                context.HttpContext.Response.Redirect("/Home/SemAcesso");
//            }
//        }
//    }
//    base.OnActionExecuting(context);
//}

