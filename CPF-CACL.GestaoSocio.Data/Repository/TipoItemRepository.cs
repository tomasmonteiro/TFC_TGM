using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class TipoItemRepository : RepositoryBase<TipoItem>, ITipoItemRepository
    {
        private readonly GSContext _gsContext;
        public TipoItemRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

		public TipoItem BuscarJoia()
		{
            return _gsContext.TipoItem.Where(p => p.Descricao == "Jóia" && p.Status == true).FirstOrDefault();
		}

		public IEnumerable<TipoItem> BuscarPorNome(string nome)
        {
            return _gsContext.TipoItem.Where(p => p.Descricao == nome);
        }

        public IEnumerable<TipoItem> BuscarTodos()
        {
            return _gsContext.TipoItem.Where(p => p.Status == true);
        }
    }
}
