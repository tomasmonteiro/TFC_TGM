using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IDespesaRepository : IRepositoryBase<Despesa>
	{
		IEnumerable<Despesa> BuscarTodos();
		IEnumerable<Despesa> BuscarPagoPorFornecedor(Guid fornecedorId);
		IEnumerable<Despesa> BuscarNaoPagoPorFornecedor(Guid fornecedorId);
		IEnumerable<Despesa> BuscarPendentePorFornecedor(Guid fornecedorId);
		IEnumerable<Despesa> BuscarDespesaPorApoio(Guid apoioId);
		IEnumerable<Despesa> BuscarDespesaPendente();
		IEnumerable<Despesa> BuscarDespesaPago();
		IEnumerable<Despesa> BuscarDespesaNaoPago();
	}
}
