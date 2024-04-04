﻿using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Socio.Controllers
{
    [Area("Socio")]
    [Autorizacao("Socio")]
    public class DeclaracaoController : BaseController
    {
        public DeclaracaoController(INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Solicitar()
        {
            return View();
        }
    }
}
