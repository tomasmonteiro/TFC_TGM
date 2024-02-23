using CPF_CACL.GestaoSocio.Aplication.ViewModel;
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

        public FinanceiroController(IItemPagamentoRepository itemPagamentoRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _itemPagamentoRepository = itemPagamentoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Extrato/{id}")]
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

    }
}
