using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IItemService : IServiceBase<Item>
    {
        public IEnumerable<Item> BuscarItemPago();
        public IEnumerable<Item> BuscarItemNPago();
		public IEnumerable<Item> BuscarItemPorSocio(Guid socioId);
		public IEnumerable<Item> BuscarPorItemTipo(Guid idTipoItem);
        public Item BuscarPorCod(string codigo);
        public string GerarCodigoItem(string tipoItem);
    }
}
