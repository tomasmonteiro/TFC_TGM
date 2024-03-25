using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IItemApoioService : IServiceBase<ItemApoio> 
    {
		public IEnumerable<ItemApoio> BuscarItemApoioPorSocio(Guid socioId);
		public IEnumerable<ItemApoio> BuscarItemPorApoio(Guid apoioId);
	}
}
