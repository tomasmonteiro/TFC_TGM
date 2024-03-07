using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class PerfilUsuarioRepository : RepositoryBase<PerfilUsuario>, IPerfilUsuarioRepository
    {
        private readonly GSContext _gsContext;
        public PerfilUsuarioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }
    }
}
