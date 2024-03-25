using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
	public class DespesaService : ServiceBase, IDespesaService
	{
		private readonly IDespesaRepository _despesaRepository;
		public DespesaService(IDespesaRepository despesaRepository, INotificador notificador) : base(notificador)
		{
			_despesaRepository = despesaRepository;
		}

		public void Add(Despesa obj)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Despesa> BuscarDespesaNaoPago()
		{
			return _despesaRepository.BuscarDespesaNaoPago();
		}

		public IEnumerable<Despesa> BuscarDespesaPago()
		{
			return _despesaRepository.BuscarDespesaPago();
		}

		public IEnumerable<Despesa> BuscarDespesaPendente()
		{
			return _despesaRepository.BuscarDespesaPendente();
		}

		public IEnumerable<Despesa> BuscarDespesaPorApoio(Guid apoioId)
		{
			return _despesaRepository.BuscarDespesaPorApoio(apoioId);
		}

		public IEnumerable<Despesa> BuscarNaoPagoPorFornecedor(Guid fornecedorId)
		{
			return _despesaRepository.BuscarNaoPagoPorFornecedor(fornecedorId);
		}

		public IEnumerable<Despesa> BuscarPagoPorFornecedor(Guid fornecedorId)
		{
			return _despesaRepository.BuscarPagoPorFornecedor(fornecedorId);
		}

		public IEnumerable<Despesa> BuscarPendentePorFornecedor(Guid fornecedorId)
		{
			return _despesaRepository.BuscarPendentePorFornecedor(fornecedorId);
		}

		public IEnumerable<Despesa> BuscarTodos()
		{
			return _despesaRepository.BuscarTodos();
		}

		public void Dispose()
		{
			_despesaRepository.Dispose();
		}

		public void Eliminar(Guid id)
		{

			var despesa = _despesaRepository.GetById(id);
			if (despesa == null)
			{
				Notificar("A Despesa que pretende inativar não existe.");
				return;
			}
			despesa.Status = false;
			despesa.DataAtualizacao = DateTime.Now;
			_despesaRepository.Update(despesa);
		}

		public IEnumerable<Despesa> GetAll()
		{
			return _despesaRepository.GetAll();
		}

		public Despesa GetById(Guid id)
		{
			return _despesaRepository.GetById(id);
		}

		public void Remove(Despesa despesa)
		{

			var novaDespesa = _despesaRepository.GetById(despesa.Id);
			if (novaDespesa == null)
			{
				Notificar("A Despesa que pretende eliminar não existe.");
				return;
			}
			_despesaRepository.Remove(novaDespesa);
		}

		public void Update(Despesa despesa)
		{
			despesa.DataAtualizacao = DateTime.Now;
			_despesaRepository.Update(despesa);
		}
	}
}
