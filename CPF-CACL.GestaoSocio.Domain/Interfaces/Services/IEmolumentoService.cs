using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IEmolumentoService : IServiceBase<Emolumento>
    {
        public IEnumerable<Emolumento> BuscarItemPago();
        public IEnumerable<Emolumento> BuscarItemNPago();
		public IEnumerable<Emolumento> BuscarItemPorSocio(Guid socioId);
		public IEnumerable<Emolumento> BuscarPorItemTipo(Guid idTipoItem);
        public Emolumento BuscarPorCod(string codigo);
        public string GerarCodigoItem(string tipoItem);
    }
}
