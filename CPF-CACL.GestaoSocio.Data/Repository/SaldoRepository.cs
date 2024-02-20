using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class SaldoRepository : RepositoryBase<Saldo>, ISaldoRepository
    {
        private readonly GSContext _gsContext;
        public SaldoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Saldo> BuscarDisponiveis(Guid id)
        {
            return _gsContext.Saldo.Where(p => p.Estado == Domain.Enums.EEstadoPagamento.Disponivel && p.SocioId == id && p.Status == true);
        }

        public List<Saldo> BuscarPagamentosPorIds(List<Guid> saldosIds)
        {
            return _gsContext.Saldo.Where(p => saldosIds.Contains(p.Id)).ToList();
        }

        public IEnumerable<Saldo> BuscarTodos()
        {
            return _gsContext.Saldo.Where(p => p.Status == true);
        }
    }
}
