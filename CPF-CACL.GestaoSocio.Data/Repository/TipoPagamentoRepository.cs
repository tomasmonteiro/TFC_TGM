using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class TipoPagamentoRepository : RepositoryBase<TipoPagamento>, ITipoPagamentoRepository
    {
        private readonly GSContext _gsContext;

        //Injeção do context(GSContext)
        public TipoPagamentoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<TipoPagamento> BuscarTodos()
        {
            return _gsContext.TipoPagamento.Where(p => p.Status == true);
        }
 
    }
}
