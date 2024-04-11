using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IPagamentoEmolumentoAppService
    {
        public void Adicionar(PagamentoEmolumentoViewModel itemPagamento);
        public IEnumerable<PagamentoEmolumentoViewModel> BuscarTodos();
        public PagamentoEmolumentoViewModel BuscarPorId(Guid id);
        public IEnumerable<PagamentoEmolumentoViewModel> BuscarPagamentoEmolumentoPorSocio(Guid socioId);
        public void Atualizar(PagamentoEmolumentoViewModel itemPagamento);
        public void Eliminar(Guid id);
    }
}
