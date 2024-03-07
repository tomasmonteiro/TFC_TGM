using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class BairroRepository : RepositoryBase<Bairro>, IBairroRepository
    {
        private readonly GSContext _gsContext;
        public BairroRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Bairro> BuscarTodos()
        {
            return _gsContext.Bairro.Include(b => b.Municipio).Where(p => p.Status == true);
            //_gsContext.Bairro.Include(b => b.Municipio).ToList();
        }
        public IEnumerable<Bairro> BuscarPorMunicipio(Guid municipioId)
        {
            return _gsContext.Bairro.Where(p => p.MunicipioId == municipioId);
        }
    }
}
