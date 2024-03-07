using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class TipoProjectoRepository : RepositoryBase<TipoProjecto>, ITipoProjectoRepository
    {
        private readonly GSContext _gsContext;
        public TipoProjectoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }
    }
}
