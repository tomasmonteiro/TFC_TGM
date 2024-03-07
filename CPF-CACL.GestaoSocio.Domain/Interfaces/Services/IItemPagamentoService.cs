using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IItemPagamentoService : IServiceBase<ItemPagamento>
    {

        public IEnumerable<ItemPagamento> BuscarItemPorSocio(Guid socioId);
    }
}
