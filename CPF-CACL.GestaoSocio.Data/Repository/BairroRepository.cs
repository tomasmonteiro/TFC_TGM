using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
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
            return _gsContext.Bairro.Where(p => p.Status == true);
            //_gsContext.Bairro.Include(b => b.Municipio).ToList();
        }
        public IEnumerable<Bairro> BuscarPorMunicipio(int municipioId)
        {
            return _gsContext.Bairro.Where(p => p.MunicipioId == municipioId);
        }
    }
}
