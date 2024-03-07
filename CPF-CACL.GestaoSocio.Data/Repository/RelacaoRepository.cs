using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class RelacaoRepository : RepositoryBase<Relacao>, IRelacaoRepository
    {
        private readonly GSContext _gsContext;
        public RelacaoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Relacao> BuscarTodos()
        {
            return _gsContext.Relacao.Where(p => p.Status == true);
        }
    }
}
