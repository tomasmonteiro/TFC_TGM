using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class TipoEmolumentoRepository : RepositoryBase<TipoEmolumento>, ITipoEmolumentoRepository
    {
        private readonly GSContext _gsContext;
        public TipoEmolumentoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

		public TipoEmolumento BuscarJoia()
		{
            return _gsContext.TipoItem.Where(p => p.Descricao == "Jóia" && p.Status == true).FirstOrDefault();
		}

		public IEnumerable<TipoEmolumento> BuscarPorNome(string nome)
        {
            return _gsContext.TipoItem.Where(p => p.Descricao == nome);
        }

        public IEnumerable<TipoEmolumento> BuscarTodos()
        {
            return _gsContext.TipoItem.Where(p => p.Status == true);
        }
    }
}
