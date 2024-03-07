using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class CategoriaSocioRepository : RepositoryBase<CategoriaSocio>, ICategoriaSocioRepository
    {
        private readonly GSContext _gsContext;
        public CategoriaSocioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<CategoriaSocio> BuscarTodos()
        {
            return _gsContext.CategoriaSocio.Where(p => p.Status == true);
        }
    }
}
