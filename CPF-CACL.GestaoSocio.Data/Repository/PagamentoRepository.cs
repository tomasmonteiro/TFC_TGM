using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        private readonly GSContext _gsContext;
        public PagamentoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

		public IEnumerable<Pagamento> BuscarDisponiveis(Guid id)
		{
            return _gsContext.Pagamento.Where(p => p.Estado == Enums.EEstadoPagamento.Disponivel && p.SocioId == id && p.Status == true);
		}

		public List<Pagamento> BuscarPagamentosPorIds(List<Guid> pagamentosIds)
        {
            return _gsContext.Pagamento.Where(p => pagamentosIds.Contains(p.Id)).ToList();
        }

        public Pagamento BuscarPorCod(string codigo)
        {
            return _gsContext.Pagamento.Where(p => p.Recibo == codigo).FirstOrDefault();
        }

        public IEnumerable<Pagamento> BuscarTodos()
        {
            return _gsContext.Pagamento
                .Include(s => s.Socio)
                .Where(p => p.Status == true);
        }
        public string ConsultarUltimoCodigo(int anoAtual)
        {
            var ultimoCodigo = _gsContext.Pagamento
                .Where(p => p.Recibo.StartsWith($"{anoAtual}"))
                .OrderByDescending(p => p.Recibo)
                .Select(p => p.Recibo)
                .FirstOrDefault();

            return ultimoCodigo;
        }

        public int ContarPagamentos()
        {
            return _gsContext.Pagamento.Count(p => p.Status == true);
        }
    }
}
