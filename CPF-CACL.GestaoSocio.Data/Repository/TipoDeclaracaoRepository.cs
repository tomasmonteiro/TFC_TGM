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
    public class TipoDeclaracaoRepository : RepositoryBase<TipoDeclaracao>, ITipoDeclaracaoRepository
    {
        private readonly GSContext _gsContext;
        public TipoDeclaracaoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public TipoDeclaracao BuscarPorTipo(string tipo)
        {
            return _gsContext.TipoDeclaracao.Where(p => p.Tipo == tipo).FirstOrDefault();
        }

        public IEnumerable<TipoDeclaracao> BuscarTodos()
        {
            return _gsContext.TipoDeclaracao.Where(p => p.Status == true);
        }
    }
}
