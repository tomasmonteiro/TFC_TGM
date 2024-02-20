using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class PagamentoService : ServiceBase, IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly ISaldoRepository _saldoRepository;
        public PagamentoService(IPagamentoRepository pagamentoRepository, ISaldoRepository saldoRepository, INotificador notificador) : base(notificador)
        {
            _pagamentoRepository = pagamentoRepository;
            _saldoRepository = saldoRepository;
        }

        public void Add(Pagamento pagamento)
        {
            pagamento.DataCriacao = DateTime.Now;
            _pagamentoRepository.Add(pagamento);

            //Adicionar automaticamente o Saldo

            var saldo = new Saldo
            {
                Recibo = pagamento.Recibo,
                Valor = pagamento.Valor,
                SocioId = pagamento.SocioId,
                PagamentoId = pagamento.Id,
                DataPagamento = pagamento.DataPagamento,
                DataCriacao = DateTime.Now,
                Status = true
            };

            _saldoRepository.Add(saldo);

        }

        public string GerarCodigoPagamento()
        {
            int anoAtual = DateTime.Now.Year % 100;

            var ultimoCodigo = _pagamentoRepository.ConsultarUltimoCodigo(anoAtual);

            int proximoNumero = 1;

            if (ultimoCodigo != null)
            {
                proximoNumero = int.Parse(ultimoCodigo.Substring(5)) + 1;
            }
            return $"{anoAtual:D2}{proximoNumero:D5}";
        }

        public Pagamento BuscarPorCod(string codigo)
        {
            return _pagamentoRepository.BuscarPorCod(codigo);
        }
        public IEnumerable<Pagamento> BuscarTodos()
        {
            return _pagamentoRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            var pagamento = _pagamentoRepository.GetById(id);
            if (pagamento == null)
            {
                Notificar("O Pagamento que pretende eliminar não existe");
                return;
            }
            pagamento.Status = false;
            Update(pagamento);
        }
        public IEnumerable<Pagamento> GetAll()
        {
            return _pagamentoRepository.GetAll();
        }
        public Pagamento GetById(Guid id)
        {
            return _pagamentoRepository.GetById(id);
        }
        public void Remove(Pagamento pagamento)
        {
            _pagamentoRepository.Remove(pagamento);
        }
        public void Update(Pagamento pagamento)
        {
            pagamento.DataAtualizacao = DateTime.Now;
            _pagamentoRepository.Update(pagamento);
        }
        public void Dispose()
        {
            _pagamentoRepository.Dispose();
        }

		public IEnumerable<Pagamento> BuscarDisponivel(Guid id)
		{
            return _pagamentoRepository.BuscarDisponiveis(id);
		}
	}
}
