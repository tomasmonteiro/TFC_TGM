using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class ItemPagamentoService : ServiceBase, IItemPagamentoService
    {
        private readonly IItemPagamentoRepository _itemPagamentoRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ISocioRepository _socioRepository;
        private readonly ITipoItemRepository _tipoItemRepository;
        private readonly ICategoriaSocioRepository _categoriaSocioRepository;
        private readonly IItemService _itemService;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPeriodoService _periodoService;

        public ItemPagamentoService(
            IItemRepository itemRepository, 
            ISocioRepository socioRepository, 
            ITipoItemRepository tipoItemRepository, 
            IItemPagamentoRepository itemPagamentoRepository,
            ICategoriaSocioRepository categoriaSocioRepository,
            IItemService itemService,
            IPagamentoRepository pagamentoRepository,
            IPeriodoService periodoService,
            INotificador notificador) : base(notificador)
        {
            _itemPagamentoRepository = itemPagamentoRepository;
            _itemRepository = itemRepository;
            _socioRepository = socioRepository;
            _tipoItemRepository = tipoItemRepository;
            _categoriaSocioRepository = categoriaSocioRepository;
            _itemService = itemService;
            _pagamentoRepository = pagamentoRepository;
            _periodoService = periodoService;
        }

        public void Add(ItemPagamento itemPagamento)
        {
            try
            {
                if (_itemPagamentoRepository.Find(
                    a => a.ItemId == itemPagamento.ItemId 
                    && 
                    a.PagamentoId == itemPagamento.PagamentoId 
                    && 
                    a.Status == true
                    ).Count() > 0)
                {
                    Notificar("O Item que pretende adicionar já existe.");
                    return;
                }
                else 
                {
                    _itemPagamentoRepository.Add(itemPagamento);

                    //Atualizar o Pagamento
                    var pagamento = _pagamentoRepository.GetById(itemPagamento.PagamentoId);
                    pagamento.Estado = Enums.EEstadoPagamento.Usado;
                    pagamento.DataAtualizacao = DateTime.Now;
                    _pagamentoRepository.Update(pagamento);

                    //Atualizar o item
                    var novoItem = _itemRepository.GetById(itemPagamento.ItemId);
                    novoItem.Estado = Enums.EEstadoItem.Pago;
                    novoItem.DataAtualizacao = DateTime.Now;
                    _itemRepository.Update(novoItem);


                    //Busca o Tipo de Item do Item
                    var tipoItem = _tipoItemRepository.GetById(novoItem.TipoItemId);

                    //Buscar Sócio 
                    var socio = _socioRepository.GetById(novoItem.SocioId);

                    //Verifica se o Tipo de Item é referente a Inscrição
                    if (tipoItem.Descricao == "Jóia")
                    {
                        //Atualiza o sócio para o Estado Ativo
                        socio.EstadoSocio = Enums.EEstadoSocio.Ativo;
                        socio.DataAtualizacao = DateTime.Now;
                        _socioRepository.Update(socio);

                        //Verifica se existe um periodo do mês atual

                        //1º Gerar o codigo do priodo com a data atual
                        var dataAtual = DateTime.Now;
                        var codigoPeriodo = _periodoService.GerarCodigoPeriodo(dataAtual.Date);
                        var periodoExistente = _periodoService.BuscarPorCod(codigoPeriodo);

                        _itemPagamentoRepository.CriarQuota(socio, periodoExistente);

                    }

                    //Gerar multa em caso de a data limite de pagamento da Quota ter excedido
                    else if (tipoItem.Descricao == "Quota" && novoItem.DataVencimento < DateTime.Now)
                    {
                        var categoriaSocio = _categoriaSocioRepository.GetById(socio.CategoriaSocioId);
                        var novoTipoItem = _tipoItemRepository.Find(p => p.Descricao == "Multa" && p.Status == true).FirstOrDefault();
                        var novoItem2 = new Item
                        {
                            Cod = _itemService.GerarCodigoItem("MUL"),
                            Descricao = "Multa",
                            SocioId = novoItem.SocioId,
                            PeriodoId = novoItem.PeriodoId,
                            Valor = (10 * categoriaSocio.Quota / 100),//Calcular os 10% de multa
                            Estado = Enums.EEstadoItem.NaoPago,
                            DataVencimento = null,
                            DataCriacao = DateTime.Now,
                            Status = true,
                            TipoItemId = novoTipoItem.Id

                        };
                        _itemRepository.Add(novoItem2);
                    }
                }
            }
            catch (Exception erro)
            {
                Notificar("Ocorreu um erro: " + erro.Message.ToString());
                return;
            }
        }

        public IEnumerable<ItemPagamento> BuscarItemPorSocio(Guid socioId)
        {
            var itensPagamento = _itemPagamentoRepository.BuscarItemPagamentoPorSocio(socioId);
            return itensPagamento;
        }

        public IEnumerable<ItemPagamento> BuscarTodos()
        {
            return _itemPagamentoRepository.BuscarTodos();
        }

        public void Dispose()
        {
            _itemPagamentoRepository.Dispose();
        }

        public void Eliminar(Guid id)
        {
            var itemPagamento = _itemPagamentoRepository.GetById(id);
            if (itemPagamento == null)
            {
                Notificar("O registo que pretende eliminar não existe.");
                return;
            }
            itemPagamento.Status = false;
            Update(itemPagamento);
        }

        public IEnumerable<ItemPagamento> GetAll()
        {
            return _itemPagamentoRepository.GetAll();
        }

        public ItemPagamento GetById(Guid id)
        {
            return _itemPagamentoRepository.GetById(id);
        }

        public void Remove(ItemPagamento itemPagamento)
        {
            var novoItemPagamento = _itemPagamentoRepository.GetById(itemPagamento.Id);
            if (novoItemPagamento == null)
            {
                Notificar("O Item Pagamento que pretende eliminar não existe.");
                return;
            }
            _itemPagamentoRepository.Remove(novoItemPagamento);
        }

        public void Update(ItemPagamento itemPagamento)
        {
            itemPagamento.DataAtualizacao = DateTime.Now;
            _itemPagamentoRepository.Update(itemPagamento);
        }
    }
}
