using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IDespesaService : IServiceBase<Despesa>
    {
		IEnumerable<Despesa> BuscarPagoPorFornecedor(Guid fornecedorId);
		IEnumerable<Despesa> BuscarNaoPagoPorFornecedor(Guid fornecedorId);
		IEnumerable<Despesa> BuscarPendentePorFornecedor(Guid fornecedorId);
		IEnumerable<Despesa> BuscarDespesaPorApoio(Guid apoioId);
		IEnumerable<Despesa> BuscarDespesaPendente();
		IEnumerable<Despesa> BuscarDespesaPago();
		IEnumerable<Despesa> BuscarDespesaNaoPago();

	}
}
