using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _gsContext.Apoio.Include(b => b.Socio).Where(p => p.EstadoApoio == Enums.EEstadoApoio.Concluido && p.Status == true).ToList();
        }

        public IEnumerable<Apoio> BuscarApoioPendente()
        {
            return _gsContext.Apoio.Include(b => b.Socio).Where(p => p.EstadoApoio == Enums.EEstadoApoio.Pendente && p.Status == true).ToList();
        }

        public IEnumerable<Apoio> BuscarTodos()
        {
            return _gsContext.Apoio.Include(b => b.Socio).Where(p => p.Status == true);
        }

		public IEnumerable<Apoio> BuscarApoioPorSocio(Guid socioId)
		{
			return _gsContext.Apoio
                .Include(b => b.ItemApoios)
				.Where(p => p.SocioId == socioId && p.Status == true);
		}
	}
}
