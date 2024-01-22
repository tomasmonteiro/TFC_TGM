using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Models.Validation;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoPagamentoService : ServiceBase, ITipoPagamentoService
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        public TipoPagamentoService(ITipoPagamentoRepository tipoPagamentoRepository, INotificador notificador) 
            : base(notificador)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
        }


        public void Add(TipoPagamento tipoPagamento)
        {
            if (!ExecutarValidacao(new TipoPagamentoValidation(), tipoPagamento)) return;
            if (_tipoPagamentoRepository.Find(a => a.Nome == tipoPagamento.Nome && a.Status == true).Count() > 0)
            {
                Notificar("Já existe um Tipo de Pagamento definido com este nome.");
                return;
            }
            _tipoPagamentoRepository.Add(tipoPagamento);
        }
        public IEnumerable<TipoPagamento> GetAll()
        {
            return _tipoPagamentoRepository.GetAll();
        }
        public TipoPagamento GetById(Guid id)
        {
            return _tipoPagamentoRepository.GetById(id);
        }
        public void Update(TipoPagamento tipoPagamento)
        {
            //if (!ExecutarValidacao(new TipoPagamentoValidation(), socio)) return;
            tipoPagamento.DataAtualizacao = DateTime.Now;
            _tipoPagamentoRepository.Update(tipoPagamento);
        }
        public void Remove(TipoPagamento tipoPagamento)
        {
            _tipoPagamentoRepository.Remove(tipoPagamento);
        }
        public void Eliminar(Guid id)
        {
            TipoPagamento tipoPagamento = GetById(id);
            if (tipoPagamento == null)
            {
                Notificar("O Tipo de Pagamento que pretende eliminar não existe.");
                return;
            }
            tipoPagamento.Status = false;
            _tipoPagamentoRepository.Update(tipoPagamento);
        }
        public void Dispose()
        {
            _tipoPagamentoRepository.Dispose();

        }

        public IEnumerable<TipoPagamento> BuscarTodos()
        {
            return _tipoPagamentoRepository.BuscarTodos();
        }
    }
}
