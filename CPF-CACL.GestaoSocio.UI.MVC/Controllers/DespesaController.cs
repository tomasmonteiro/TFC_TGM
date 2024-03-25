using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
	[Autorizacao("Admin", "Presidente", "Tesoureiro", "Secretario", "Vogal")]
	public class DespesaController : BaseController
	{
		private readonly IDespesaAppService _despesaAppService;
		public DespesaController(IDespesaAppService despesaAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
		{
			_despesaAppService = despesaAppService;
		}

		public IActionResult Index()
		{
			var despesa = _despesaAppService.BuscarTodos();
			return View(despesa);
		}
	}
}
