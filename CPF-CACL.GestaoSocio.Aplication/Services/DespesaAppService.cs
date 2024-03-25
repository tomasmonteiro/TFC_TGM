using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
	public class DespesaAppService : IDespesaAppService
	{
		private readonly IMapper mapper;
		private readonly IDespesaService despesaService;

		public DespesaAppService(IMapper mapper, IDespesaService despesaService)
		{
			this.mapper = mapper;
			this.despesaService = despesaService;
		}

		public void Atualizar(DespesaViewModel despesa)
		{
			despesaService.Update(mapper.Map<Despesa>(despesa));
		}

		public IEnumerable<DespesaViewModel> BuscarDespesaNaoPago()
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarDespesaNaoPago());
		}

		public IEnumerable<DespesaViewModel> BuscarDespesaPago()
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarDespesaPago());
		}

		public IEnumerable<DespesaViewModel> BuscarDespesaPendente()
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarDespesaPendente());
		}

		public IEnumerable<DespesaViewModel> BuscarDespesaPorApoio(Guid apoioId)
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarDespesaPorApoio(apoioId));
		}

		public IEnumerable<DespesaViewModel> BuscarNaoPagoPorFornecedor(Guid fornecedorId)
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarNaoPagoPorFornecedor(fornecedorId));
		}

		public IEnumerable<DespesaViewModel> BuscarPagoPorFornecedor(Guid fornecedorId)
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarPagoPorFornecedor(fornecedorId));
		}

		public IEnumerable<DespesaViewModel> BuscarPendentePorFornecedor(Guid fornecedorId)
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarPendentePorFornecedor(fornecedorId));
		}

		public IEnumerable<DespesaViewModel> BuscarTodos()
		{
			return mapper.Map<IEnumerable<DespesaViewModel>>(despesaService.BuscarTodos());
		}

		public void Eliminar(Guid id)
		{
			despesaService.Eliminar(id);
		}
	}
}
