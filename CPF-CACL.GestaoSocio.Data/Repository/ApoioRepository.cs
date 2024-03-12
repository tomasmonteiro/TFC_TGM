using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class ApoioRepository : RepositoryBase<Apoio>, IApoioRepository
    {
        private readonly GSContext _gsContext;
        public ApoioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Apoio> BuscarApoioConcluido()
        {
            return _gsContext.Apoio.Where(p => p.EstadoApoio == Enums.EEstadoApoio.Concluido && p.Status == true).ToList();
        }

        public IEnumerable<Apoio> BuscarApoioPendente()
        {
            return _gsContext.Apoio.Where(p => p.EstadoApoio == Enums.EEstadoApoio.Pendente && p.Status == true).ToList();
        }

        public IEnumerable<Apoio> BuscarTodos()
        {
            return _gsContext.Apoio.Where(p => p.Status == true);
        }
    }
}
