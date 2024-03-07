using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class BeneficioRepository : RepositoryBase<Beneficio>, IBeneficioRepository
    {
        private readonly GSContext _gsContext;
        public BeneficioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }
        public IEnumerable<Beneficio> BuscarTodos()
        {
            return _gsContext.Beneficio.Include(b => b.TipoBeneficio).Where(p => p.Status == true);
        }
        public IEnumerable<Beneficio> BuscarPorTipo(Guid tipoBeneficioId)
        {
            return _gsContext.Beneficio.Where(p => p.TipoBeneficioId == tipoBeneficioId);
        }
    }
}
