using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IPagamentoRepository : IRepositoryBase<Pagamento>
    {
        IEnumerable<Pagamento> BuscarTodos();
		IEnumerable<Pagamento> BuscarDisponiveis(Guid id);
		Pagamento BuscarPorCod(string codigo);
        public string ConsultarUltimoCodigo(int anoAtual);
        List<Pagamento> BuscarPagamentosPorIds(List<Guid> pagamentosIds);
        int ContarPagamentos();
    }
}
