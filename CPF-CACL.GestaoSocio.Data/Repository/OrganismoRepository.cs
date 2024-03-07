using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class OrganismoRepository : RepositoryBase<Organismo>, IOrganismoRepository
    {
        private readonly GSContext _gsContext;

        public OrganismoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Organismo> BuscarTodos()
        {
            return _gsContext.Organismo.Where(p => p.Status == true);
        }
    }
}
