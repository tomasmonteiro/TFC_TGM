using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class ItemApoioRepository : RepositoryBase<ItemApoio>, IItemApoioRepository
    {
        private readonly GSContext _gsContext;
        public ItemApoioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }


		public IEnumerable<ItemApoio> BuscarItemPorApoio(Guid apoioId)
		{
			return _gsContext.ItemApoio
				.Include(s => s.Apoio)
				.Where(p => p.ApoioId == apoioId && p.Status == true);
		}
		public IEnumerable<ItemApoio> BuscarItemPorSocio(Guid socioId)
		{
			return _gsContext.ItemApoio
				.Include(s => s.Beneficio)
				.Include(s => s.Fornecedor)
				.Include(s => s.Apoio)
				.Where(item => item.Apoio.SocioId == socioId && item.Status == true);
		}

		public IEnumerable<ItemApoio> BuscarTodos()
        {
            return _gsContext.ItemApoio.Where(p => p.Status == true);
        }
    }
}
