using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class SaldoService : ServiceBase, ISaldoService
    {
        private readonly INotificador _notificador;
        private readonly ISaldoRepository _saldoRepository;
        public SaldoService(ISaldoRepository saldoRepository, INotificador notificador) : base(notificador)
        {
            _notificador = notificador;
            _saldoRepository = saldoRepository;
        }

        public void Add(Saldo saldo)
        {
            try
            {
                //if (_saldoRepository.Find(p => p.PagamentoId == saldo.PagamentoId &&  p.Status == true).Count() > 0)
                //{
                //    Notificar("O registo que pretente adicionar já existe.");
                //    return;
                //}
                _saldoRepository.Add(saldo);

            }
            catch (Exception erro)
            {
                Notificar("Ocorreu um erro: " + erro.Message.ToString());
                return;
            }
        }

        public IEnumerable<Saldo> BuscarDisponivel(Guid id)
        {
            return _saldoRepository.BuscarDisponiveis(id);
        }

        public IEnumerable<Saldo> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Saldo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Saldo GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Saldo obj)
        {
            throw new NotImplementedException();
        }

        public void TornarUsado(Guid id)
        {
            var saldo = _saldoRepository.GetById(id);
            if (saldo != null)
            {
                saldo.Estado = Enums.EEstadoPagamento.Usado;
                Update(saldo);
            }
        }

        public void UnirRecibos(List<Guid> saldoIds)
        {//Pagamento novoPagamento;
            var saldos = _saldoRepository.BuscarPagamentosPorIds(saldoIds);

            if (saldos == null || saldos.Count == 0)
            {
                Notificar("Os Saldos seleciondos não existem");
                return;
            }
            //Calcular os valores
            double valorTotal = saldos.Sum(p => p.Valor);

            var novoSaldo = new Saldo
            {
                //Cod = GerarCodigoPagamento(),
                Recibo = saldos[0].Recibo,
                Valor = valorTotal,
                DataPagamento = saldos[0].DataPagamento,
                Estado = Enums.EEstadoPagamento.Disponivel,
                SocioId = saldos[0].SocioId,
                PagamentoId = saldos[0].PagamentoId,
                DataCriacao = DateTime.Now,
                Status = true
            };
            _saldoRepository.Add(novoSaldo);
            foreach (var item in saldos)
            {
                item.Estado = Enums.EEstadoPagamento.Usado;
                item.DataAtualizacao = DateTime.Now;
                _saldoRepository.Update(item);
            }
        }

        public void Update(Saldo saldo)
        {
            saldo.DataAtualizacao = DateTime.Now;
            _saldoRepository.Update(saldo);
        }
    }
}
