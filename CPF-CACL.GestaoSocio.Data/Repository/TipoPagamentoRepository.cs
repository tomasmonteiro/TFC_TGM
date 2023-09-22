using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class TipoPagamentoRepository : RepositoryBase<TipoPagamento>, ITipoPagamentoRepository
    {
        private readonly GSContext _gsContext;

        //Injeção do context (GSContext)
        public TipoPagamentoRepository(GSContext gsContext)
        {
            _gsContext = gsContext;
        }

        //Implementação dos contratos (Interfaces) de repositório
        public TipoPagamento Adicionar(TipoPagamento tipoPagamento)
        {
            _gsContext.TipoPagamento.Add(tipoPagamento);
            _gsContext.SaveChanges();
            return tipoPagamento;
        }
    }
}
