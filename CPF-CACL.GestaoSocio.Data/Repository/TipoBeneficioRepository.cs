using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class TipoBeneficioRepository : RepositoryBase<TipoBeneficio>, ITipoBeneficioRepository
    {
        private readonly GSContext _gsContext;
        public TipoBeneficioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public TipoBeneficio BuscarPorNome(string nome)
        {
            return _gsContext.TipoBeneficio.Where(p => p.Nome == nome).FirstOrDefault();
        }

        public IEnumerable<TipoBeneficio> BuscarTodos()
        {
            return _gsContext.TipoBeneficio.Where(p => p.Status == true);
        }
    }
}
