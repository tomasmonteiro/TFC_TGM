using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
	public interface IDespesaAppService
	{
		IEnumerable<DespesaViewModel> BuscarPagoPorFornecedor(Guid fornecedorId);
		IEnumerable<DespesaViewModel> BuscarNaoPagoPorFornecedor(Guid fornecedorId);
		IEnumerable<DespesaViewModel> BuscarPendentePorFornecedor(Guid fornecedorId);
		IEnumerable<DespesaViewModel> BuscarDespesaPorApoio(Guid apoioId);
		IEnumerable<DespesaViewModel> BuscarDespesaPendente();
		IEnumerable<DespesaViewModel> BuscarDespesaPago();
		IEnumerable<DespesaViewModel> BuscarTodos();
		IEnumerable<DespesaViewModel> BuscarDespesaNaoPago();
		public void Atualizar(DespesaViewModel despesa);
		public void Eliminar(Guid id);
	}
}
