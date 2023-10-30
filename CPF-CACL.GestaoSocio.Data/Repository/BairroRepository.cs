using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
