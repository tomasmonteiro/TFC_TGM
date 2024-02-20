using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class AgregadoRepository : RepositoryBase<Agregado>, IAgregadoRepository
    {
        private readonly GSContext _gsContext;
        public AgregadoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public Agregado BuscarConjuge(Guid idSocio)
        {

            var relacao = _gsContext.Relacao.Where(p => p.Nome == "Cônjuge" && p.Status == true).FirstOrDefault();

            return _gsContext.Agregado.Where(b => b.SocioId == idSocio && b.RelacaoId == relacao.Id && b.Status ==true).FirstOrDefault();
        }

		public IEnumerable<Agregado> BuscarAgregadoPorSocio(Guid socioId)
		{
			return _gsContext.Agregado
				.Include(s => s.Relacao)
				.Where(p => p.SocioId == socioId && p.Status == true);
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
