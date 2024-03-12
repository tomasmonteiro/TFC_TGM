using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class CapitalRepository : RepositoryBase<Capital>, ICapitalRepository
    {
        private readonly GSContext _gsContext;
        public CapitalRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Capital> BuscarTodos()
        {
            return _gsContext.Capital.Include(b => b.Beneficio).Include(c => c.CategoriaSocio).Where(p => p.Status == true);
        }
    }
}
