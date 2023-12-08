using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

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
