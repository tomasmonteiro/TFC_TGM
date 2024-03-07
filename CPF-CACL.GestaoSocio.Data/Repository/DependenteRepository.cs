using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class DependenteRepository : RepositoryBase<Dependente>, IDependenteRepository
    {
        private readonly GSContext _gsContext;
        public DependenteRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public Dependente BuscarConjuge(Guid idSocio)
        {

            var relacao = _gsContext.Relacao.Where(p => p.Nome == "Cônjuge" && p.Status == true).FirstOrDefault();

            return _gsContext.Dependente.Where(b => b.SocioId == idSocio && b.RelacaoId == relacao.Id && b.Status ==true).FirstOrDefault();
        }

		public IEnumerable<Dependente> BuscarAgregadoPorSocio(Guid socioId)
		{
			return _gsContext.Dependente
				.Include(s => s.Relacao)
				.Where(p => p.SocioId == socioId && p.Status == true);
		}

		public IEnumerable<Dependente> BuscarTodos()
        {
            return _gsContext.Dependente.Where(p => p.Status == true);
        }

        public bool VerificarExisteConjuge(Guid socioId)
        {
            return _gsContext.Dependente.Any(a =>a.Status == true && a.SocioId == socioId && a.Relacao.Nome == "Cônjuge"); 
        }
    }
}
