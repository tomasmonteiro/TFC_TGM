using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Presidente", "Tesoureiro", "Secretario", "Vogal")]
    public class PagamentoController : BaseController
    {
        private readonly ISaldoAppService _saldoAppService;
        private readonly ISaldoService _saldoService;
        private readonly IPagamentoAppService _pagamentoAppService;
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        private readonly IEmolumentoAppService _itemAppService;
        private readonly IPagamentoEmolumentoAppService _itemPagamentoAppService;
		private readonly IPagamentoEmolumentoRepository _itemPagamentoRepository;
		private readonly ISocioAppService _socioAppService;
        public PagamentoController(ITipoPagamentoRepository tipoPagamentoRepository, IPagamentoEmolumentoRepository itemPagamentoRepository, IPagamentoAppService pagamentoAppService, ISaldoService saldoService, IPagamentoEmolumentoAppService itemPagamentoAppService, IEmolumentoAppService itemAppService, ISaldoAppService saldoAppService, ISocioAppService socioAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
            _saldoAppService = saldoAppService;
            _saldoService = saldoService;
            _pagamentoAppService = pagamentoAppService;
            _itemPagamentoAppService = itemPagamentoAppService;
            _itemPagamentoRepository = itemPagamentoRepository;
            _itemAppService = itemAppService;
            _socioAppService = socioAppService;
        }

        // GET: PagamentoController
        public ActionResult Index()
        {
            var pagamentos = _pagamentoAppService.BuscarTodosDisponiveis();
            return View(pagamentos);
        }

        // GET: PagamentoController/Detalhes/5
        public ActionResult Detalhes(Guid id)
        {
            var pagamento = _pagamentoAppService.BuscarPorId(id);
            return View(pagamento);
        }

        // GET: PagamentoController/Criar
        public ActionResult Criar()
        {
            var viewModel = new PagamentoViewModel();
            var relacoes = _tipoPagamentoRepository.BuscarTodos();
            relacoes = relacoes.OrderBy(m => m.Nome).ToList();
            viewModel.TipoPagamento = relacoes
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();
            return PartialView("Criar", viewModel);
        }

        // POST: PagamentoController/Criar
        [HttpPost]
        public ActionResult Criar(PagamentoViewModel pagamento)
        {
            try
            {
                _pagamentoAppService.Adicionar(pagamento);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }

                return Json("Registo adicionado com sucesso!");
            }
            catch(Exception erro)
            {
                return Json($" x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: PagamentoController/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: PagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PagamentoController/Deletar/5
        [Autorizacao("Admin")]
        public ActionResult Deletar(Guid id)
        {
            return View();
        }

        // POST: PagamentoController/Deletar/5
        [HttpPost]
        [Autorizacao("Admin")]
        public ActionResult Deletar(PagamentoViewModel pagamentoViewModel)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //Registar Pagamento

        [Route("/Pagamento/Efectuar-Pagamento/{id}")]
		public ActionResult RegistarPagamento(Guid id)
		{


            IEnumerable<SaldoViewModel> saldos = _saldoAppService.BuscarDisponivel(id);
            ViewBag.Saldo = saldos;

            IEnumerable<EmolumentoViewModel> itens = _itemAppService.BuscarItemPorSocio(id);
            ViewBag.Itens = itens;

            var socio = _socioAppService.BuscarPorId(id);

			return View(socio);
		}

		// POST: PagamentoController/Criar
		[HttpPost]
		[Route("/Pagamento/Efectuar-Pagamento")]
		public ActionResult RegistarPagamento(
            DateTime DataInsercao, 
            Guid PagamentoId, 
            Guid ItemId, 
            DateTime DataCriacao,
            string Status,
            Guid idSaldo,
            double saldoValor,
            double itemValor,
            Guid socioId,
            string recibo
            )
		{
			try
			{
                var itemPagamento = new PagamentoEmolumentoViewModel
                {
                    DataInsercao = DataInsercao,
                    PagamentoId = PagamentoId,
                    ItemId = ItemId,
                    DataCriacao = DataCriacao,
                    Status = Status
                };
				_itemPagamentoAppService.Adicionar(itemPagamento);

                //Transformar o Saldo em usado
                _saldoService.TornarUsado(idSaldo);

                //Criar um novo saldo em caso de o valor do saldo for superior o valor do item
                if (saldoValor > itemValor)
                {
                    var valor = saldoValor - itemValor;
                    var novoSaldo = new SaldoViewModel
                    {
                        Recibo = recibo,
                        Valor = valor,
                        SocioId = socioId,
                        PagamentoId = PagamentoId,
                        DataPagamento = DataInsercao,
                        DataCriacao = DateTime.Now,
                        Status = "true"
                    };
                    _saldoAppService.Adicionar(novoSaldo);
                }

				if (!ValidOperation())
				{
					var sb = new StringBuilder();
					foreach (var item in BuscarMensagemErro())
					{
						sb.AppendLine($"x {item}\n");
					}
					return Json(sb.ToString());
				}

				return Json("Registo adicionado com sucesso!");
			}
			catch (Exception erro)
			{
				return Json($" x Ocorreu um erro: {erro.Message}");
			}
		}

        [Route("/Pagamento/Extrato/{id}")]
        public ActionResult Extrato(Guid id)
        {

            var itemPagamentos = _itemPagamentoRepository.BuscarItemPagamentoPorSocio(id);

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

        //Unir Recibos

        [Route("/Pagamento/Unir-Recibo/{id}")]
        public ActionResult UnirRecibo(Guid id)
        {


            IEnumerable<SaldoViewModel> saldos = _saldoAppService.BuscarDisponivel(id);
            ViewBag.Saldo = saldos;

            var socio = _socioAppService.BuscarPorId(id);

            return View(socio);
        }
        [Route("/Pagamento/Unir-Recibo")]
        [HttpPost]
        public ActionResult UnirRecibo([FromBody]List<Guid> ids)
        {
            try
            {
                _saldoService.UnirRecibos(ids);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("União de Recíbos feita com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($" x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
