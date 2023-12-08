using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

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
