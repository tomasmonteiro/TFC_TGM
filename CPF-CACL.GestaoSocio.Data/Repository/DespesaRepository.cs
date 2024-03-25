using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class DespesaRepository : RepositoryBase<Despesa>, IDespesaRepository
    {
        private readonly GSContext _gsContext;
        public DespesaRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

		public IEnumerable<Despesa> BuscarDespesaNaoPago()
		{
			return _gsContext.Despesa
				.Include(s => s.Apoio)
				.Include(s => s.Fornecedor)
				.Where(p =>
				p.EstadoDespesa == Enums.EEstadoDespesa.NaoPago
				&&
				p.Status == true);
		}

		public IEnumerable<Despesa> BuscarDespesaPago()
		{
			return _gsContext.Despesa
				.Include(s => s.Apoio)
				.Include(s => s.Fornecedor)
				.Where(p =>
				p.EstadoDespesa == Enums.EEstadoDespesa.Pago
				&&
				p.Status == true);
		}

		public IEnumerable<Despesa> BuscarDespesaPendente()
		{
			return _gsContext.Despesa
				.Include(s => s.Apoio)
				.Include(s => s.Fornecedor)
				.Where(p => 
				p.EstadoDespesa == Enums.EEstadoDespesa.Pendente
				&& 
				p.Status == true);
		}

		public IEnumerable<Despesa> BuscarDespesaPorApoio(Guid apoioId)
		{
            return _gsContext.Despesa.Include(s => s.Apoio).Include(s => s.Fornecedor).Where(p => p.EstadoDespesa == Enums.EEstadoDespesa.Pago && p.ApoioId == apoioId && p.Status == true);
        }

		public IEnumerable<Despesa> BuscarPagoPorFornecedor(Guid fornecedorId)
		{
			return _gsContext.Despesa.Include(s => s.Apoio).Include(s => s.Fornecedor).Where(p => p.EstadoDespesa == Enums.EEstadoDespesa.Pago && p.FornecedorId == fornecedorId && p.Status == true);
		}
		public IEnumerable<Despesa> BuscarNaoPagoPorFornecedor(Guid fornecedorId)
		{
			return _gsContext.Despesa.Include(s => s.Apoio).Include(s => s.Fornecedor).Where(p => p.EstadoDespesa == Enums.EEstadoDespesa.NaoPago && p.FornecedorId == fornecedorId && p.Status == true);
		}
		public IEnumerable<Despesa> BuscarPendentePorFornecedor(Guid fornecedorId)
		{
			return _gsContext.Despesa
                .Include(s => s.Apoio)
                .Include(s => s.Fornecedor)
				.Where(p => p.EstadoDespesa == Enums.EEstadoDespesa.Pendente && p.FornecedorId == fornecedorId && p.Status == true);
		}

		public IEnumerable<Despesa> BuscarTodos()
		{
			return _gsContext.Despesa
				.Include(s => s.Apoio)
                .Include(s => s.Fornecedor)
                .Where(p => p.Status == true);
		}
	}
}
