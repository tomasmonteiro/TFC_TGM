using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IItemPagamentoAppService
    {
        public void Adicionar(ItemPagamentoViewModel itemPagamento);
        public IEnumerable<ItemPagamentoViewModel> BuscarTodos();
        public ItemPagamentoViewModel BuscarPorId(Guid id);
        public IEnumerable<ItemPagamentoViewModel> BuscarItemPagamentoPorSocio(Guid socioId);
        public void Atualizar(ItemPagamentoViewModel itemPagamento);
        public void Eliminar(Guid id);
    }
}
