using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IPagamentoAppService
    {
        public void Adicionar(PagamentoViewModel pagamento);
        public IEnumerable<PagamentoViewModel> BuscarTodosDisponiveis();
        public IEnumerable<PagamentoViewModel> BuscarTodos();
        public IEnumerable<PagamentoViewModel> BuscarDisponivel(Guid id);
        public PagamentoViewModel BuscarPorCod(string codigo);
        public PagamentoViewModel BuscarPorId(Guid id);
        public void Atualizar(PagamentoViewModel pagamento);
        public void Eliminar(Guid id);
    }
}
