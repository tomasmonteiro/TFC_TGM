using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class AgregadoRepository : RepositoryBase<Agregado>, IAgregadoRepository
    {
        private readonly GSContext _gsContext;
        public AgregadoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Agregado> BuscarTodos()
        {
            return _gsContext.Agregado.Where(p => p.Status == true);
        }

        public bool VerificarExisteConjuge(Guid socioId)
        {
            return _gsContext.Agregado.Any(a =>a.Status == true && a.SocioId == socioId && a.Relacao.Nome == "Cônjuge"); 
        }
    }
}
