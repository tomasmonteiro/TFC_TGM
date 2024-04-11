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
    public class TipoApoioRepository : RepositoryBase<TipoApoio>, ITipoApoioRepository
    {
        private readonly GSContext _gsContext;
        public TipoApoioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public TipoBeneficio BuscarPorNome(string nome)
        {
            return _gsContext.TipoBeneficio.Where(p => p.Nome == nome).FirstOrDefault();
        }

        public TipoApoio BuscarPorTipo(string tipo)
        {
            return _gsContext.TipoApoio.Where(p => p.Tipo == tipo && p.Status == true).FirstOrDefault() ;
        }

        IEnumerable<TipoApoio> ITipoApoioRepository.BuscarTodos()
        {
            return _gsContext.TipoApoio.Where(p => p.Status == true);
        }
    }
}
