using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
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
    public class FinanceiroController : BaseController
    {
        private readonly IItemPagamentoRepository _itemPagamentoRepository;
        private readonly IUsuarioSocioRepository _usuarioSocioRepository;
        private readonly ISocioRepository _socioRepository;
        private readonly IBairroRepository _bairroRepository;
        private readonly ICategoriaSocioRepository _categoriaRepository;
        private readonly ISaldoAppService _saldoAppService;
        private readonly IItemAppService _itemAppService;

        public FinanceiroController(ISaldoAppService saldoAppService, IItemAppService itemAppService, IItemPagamentoRepository itemPagamentoRepository, IUsuarioSocioRepository usuarioSocioRepository, ISocioRepository socioRepository, IBairroRepository bairroRepository,ICategoriaSocioRepository categoriaSocioRepository,  INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _itemPagamentoRepository = itemPagamentoRepository;
            _usuarioSocioRepository = usuarioSocioRepository;
            _socioRepository = socioRepository;
            _bairroRepository = bairroRepository;
            _categoriaRepository = categoriaSocioRepository;
            _saldoAppService = saldoAppService;
            _itemAppService = itemAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Extrato/{id}")]
        public ActionResult Extrato(Guid id)
        {
            var usuarioSocio = _usuarioSocioRepository.BuscarPorUsuarioId(id);

            IEnumerable<SaldoViewModel> saldos = _saldoAppService.BuscarDisponivel(usuarioSocio.SocioId);
            ViewBag.Saldo = saldos;

            IEnumerable<ItemViewModel> itens = _itemAppService.BuscarItemPorSocio(usuarioSocio.SocioId);
            ViewBag.Itens = itens;

            var itemPagamentos = _itemPagamentoRepository.BuscarItemPagamentoPorSocio(usuarioSocio.SocioId);

            var viewModelList = new List<ExtratoViewModel>();
            foreach (var item in itemPagamentos)
            {
                var viewModel = new ExtratoViewModel
                {
                    ItemPagamentoId = item.Id,
                    DataRegisto = item.DataCriacao,

                    PagamentoId = item.PagamentoId,
                    ReciboPagamento = item.Pagamento.Recibo,
                    DataPagamento = item.Pagamento.DataPagamento,

                    ItemId = item.ItemId,
                    DescricaoItem = item.Item.Descricao,
                    ValorItem = item.Item.Valor

                };
                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }

        [Route("/ExtratoImprimir/{id}")]
        public ActionResult ExtratoImprimir(Guid id)
        {
            var usuarioSocio = _usuarioSocioRepository.BuscarPorUsuarioId(id);

            IEnumerable<SaldoViewModel> saldos = _saldoAppService.BuscarDisponivel(usuarioSocio.SocioId);
            ViewBag.Saldo = saldos;

            IEnumerable<ItemViewModel> itens = _itemAppService.BuscarItemPorSocio(usuarioSocio.SocioId);
            ViewBag.Itens = itens;


            var itemPagamentos = _itemPagamentoRepository.BuscarItemPagamentoPorSocio(usuarioSocio.SocioId);

            var viewModelList = new List<ExtratoViewModel>();
            foreach (var item in itemPagamentos)
            {
                var viewModel = new ExtratoViewModel
                {
                    ItemPagamentoId = item.Id,
                    DataRegisto = item.DataCriacao,

                    PagamentoId = item.PagamentoId,
                    ReciboPagamento = item.Pagamento.Recibo,
                    DataPagamento = item.Pagamento.DataPagamento,

                    ItemId = item.ItemId,
                    DescricaoItem = item.Item.Descricao,
                    ValorItem = item.Item.Valor

                };
                viewModelList.Add(viewModel);
            }
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

            return View(viewModelList);
        }

    }
}
