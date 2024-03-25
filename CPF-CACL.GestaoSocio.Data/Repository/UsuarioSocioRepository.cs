using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class UsuarioSocioRepository : RepositoryBase<UsuarioSocio>, IUsuarioSocioRepository
    {
        private readonly GSContext _gsContext;
        public UsuarioSocioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public UsuarioSocio BuscarPorSocioId(Guid socioId)
        {
            return _gsContext.UsuarioSocio.Where(p => p.SocioId == socioId && p.Status == true).FirstOrDefault();
        }

        public UsuarioSocio BuscarPorUsuarioId(Guid usuarioId)
        {
            return _gsContext.UsuarioSocio.Where(p => p.UsuarioId == usuarioId && p.Status == true).FirstOrDefault();
        }

        public IEnumerable<UsuarioSocio> BuscarTodos()
        {
            return _gsContext.UsuarioSocio.Where(p => p.Status == true).ToList();
        }
    }
}
