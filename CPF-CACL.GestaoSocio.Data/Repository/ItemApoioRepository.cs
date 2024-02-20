using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class ItemApoioRepository : RepositoryBase<ItemApoio>, IItemApoioRepository
    {
        private readonly GSContext _gsContext;
        public ItemApoioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<ItemApoio> BuscarTodos()
        {
            return _gsContext.ItemApoio.Where(p => p.Status == true);
        }
    }
}
