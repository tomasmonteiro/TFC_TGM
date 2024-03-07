using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class MunicipioRepository : RepositoryBase<Municipio>, IMunicipioRepository
    {
        private readonly GSContext _gsContext;
        public MunicipioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Municipio> BuscarTodos()
        {
            return _gsContext.Municipio.Where(p => p.Status == true);
        }
    }
}
