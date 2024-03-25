using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IItemApoioRepository : IRepositoryBase<ItemApoio>
    {
        IEnumerable<ItemApoio> BuscarTodos();
		public IEnumerable<ItemApoio> BuscarItemPorApoio(Guid apoioId);
		public IEnumerable<ItemApoio> BuscarItemPorSocio(Guid socioId);
	}
}
