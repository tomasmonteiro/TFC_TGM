using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class SocioRepository : RepositoryBase<Socio>, ISocioRepository
    {
        private readonly GSContext _gsContext;

        public SocioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public ICollection<Socio> BuscarPorGenero(string genero)
        {
            return (ICollection<Socio>)_gsContext.Socio.Where(p => p.Genero == genero);
        }

        public ICollection<Socio> BuscarPorNome(string nome)
        {
            return (ICollection<Socio>)_gsContext.Socio.Where(p => p.Nome == nome);
        }

        public IEnumerable<Socio> BuscarTodos()
        {
            return _gsContext.Socio.Where(p => p.Status == true);
        }
    }
}
