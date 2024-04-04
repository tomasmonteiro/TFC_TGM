using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Controllers;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Areas.Socio.Controllers
{
    [Area("Socio")]
    [Autorizacao("Socio")]
    public class ApoioController : BaseController
    {
        private readonly IUsuarioSocioRepository _usuarioSocioRepository;
        private readonly ISaldoAppService _saldoAppService;
        private readonly IItemApoioAppService _itemApoioAppService;

        private readonly ISocioRepository _socioRepository;
        private readonly IBairroRepository _bairroRepository;
        private readonly ICategoriaSocioRepository _categoriaRepository;
        public ApoioController(ISocioRepository socioRepository, IBairroRepository bairroRepository, ICategoriaSocioRepository categoriaRepository, IUsuarioSocioRepository usuarioSocioRepository, ISaldoAppService saldoAppService, IItemApoioAppService itemApoioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _saldoAppService = saldoAppService;
            _usuarioSocioRepository = usuarioSocioRepository;
            _itemApoioAppService = itemApoioAppService;
            _socioRepository = socioRepository;
            _categoriaRepository = categoriaRepository;
            _bairroRepository = bairroRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("/ExtratoApoio/{id}")]
        public ActionResult ExtratoApoio(Guid id)
        {
            var usuarioSocio = _usuarioSocioRepository.BuscarPorUsuarioId(id);

            IEnumerable<ItemApoioViewModel> itemApoio = _itemApoioAppService.BuscarItemApoioPorSocio(usuarioSocio.SocioId);
            ViewBag.ItemApoio = itemApoio;


            return View();
        }

        [Route("/ExtratoApoioImprimir/{id}")]
        public ActionResult ExtratoApoioImprimir(Guid id)
        {
            var usuarioSocio = _usuarioSocioRepository.BuscarPorUsuarioId(id);


            IEnumerable<ItemApoioViewModel> itemApoio = _itemApoioAppService.BuscarItemApoioPorSocio(usuarioSocio.SocioId);
            ViewBag.ItemApoio = itemApoio;

            var socio = _socioRepository.GetById(usuarioSocio.SocioId);
            var bairro = _bairroRepository.GetById(socio.BairroId);
            var categoria = _categoriaRepository.GetById(socio.CategoriaSocioId);

            ViewBag.Categoria = categoria.Nome;
            ViewBag.CodSocio = socio.Cod;
            ViewBag.Bairro = bairro.Nome;
            ViewBag.Endereco = socio.Endereco;
            ViewBag.Email = socio.Email;
            ViewBag.Telefone = socio.Telefone;
            ViewBag.DataAtual = DateTime.Now;

            return View();
        }

        public IActionResult Solicitar()
        {
            return View();
        }
    }
}
