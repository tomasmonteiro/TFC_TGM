using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Autorizacao("Admin")]
    public class HomeController : BaseController
	{
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISocioRepository _socioRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        public HomeController(IUsuarioRepository usuarioRepository, ISocioRepository socioRepository, IFornecedorRepository fornecedorRepository, IPagamentoRepository pagamentoRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _usuarioRepository = usuarioRepository;
            _socioRepository = socioRepository;
            _fornecedorRepository = fornecedorRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public IActionResult Index()
		{

            ViewBag.TotalSocios = _socioRepository.ContarSocios();
            ViewBag.TotalFornecedores = _fornecedorRepository.ContarFornecedores();
            ViewBag.TotalPagamentos = _pagamentoRepository.ContarPagamentos();
            ViewBag.TotalUsuarios = _usuarioRepository.ContarUsuarios();

            return View();
		}
	}
}
