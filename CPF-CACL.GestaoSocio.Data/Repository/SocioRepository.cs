using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class SocioRepository : RepositoryBase<Socio>, ISocioRepository
    {
        private readonly GSContext _gsContext;

        public SocioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public Socio BuscarPorCodigo(string cod)
        {
            return _gsContext.Socio.Where(p => p.Cod == cod && p.Status == true).FirstOrDefault();
        }

        public ICollection<Socio> BuscarPorGenero(string genero)
        {
            return (ICollection<Socio>)_gsContext.Socio.Where(p => p.Genero == genero);
        }

        public ICollection<Socio> BuscarPorNome(string nome)
        {
            return (ICollection<Socio>)_gsContext.Socio.Where(p => p.Nome == nome);
        }

		public Socio BuscarPorSemTrack(Guid socioId)
		{
            return _gsContext.Socio.AsNoTracking().FirstOrDefault(p => p.Id == socioId && p.Status == true);
		}

		public IEnumerable<Socio> BuscarTodos()
        {
            return _gsContext.Socio.Where(p => p.Status == true);
        }

        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual)
        {
            var ultimoCodigo = _gsContext.Socio
                .Where(p => p.Cod.StartsWith($"{tipoEntidade}{anoAtual}"))
                .OrderByDescending(p => p.Cod)
                .Select(p => p.Cod)
                .FirstOrDefault();

            return ultimoCodigo;
        }

        public int ContarSocios()
        {
            return _gsContext.Socio.Count(p => p.Status == true);
        }
    }
}
