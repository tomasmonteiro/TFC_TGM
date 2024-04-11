using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class EmolumentoRepository : RepositoryBase<Emolumento>, IEmolumentoRepository
    {
        private readonly GSContext _gsContext;
        public EmolumentoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Emolumento> BuscarItemNPago()
        {
            return _gsContext.Item.Where(p => p.Estado == EEstadoItem.NaoPago);
        }

        public IEnumerable<Emolumento> BuscarItemPago()
        {
            return _gsContext.Item.Where(p => p.Estado == EEstadoItem.Pago);
        }

		public IEnumerable<Emolumento> BuscarItemPorSocio(Guid socioId)
		{
			return _gsContext.Item
                .Include(s => s.Periodo)
                .Where(p => p.Estado == EEstadoItem.NaoPago && p.SocioId == socioId && p.Status == true);
		}

		public Emolumento BuscarPorCod(string codigo)
        {
            return _gsContext.Item.Where(p => p.Codigo == codigo).FirstOrDefault();
        }

        public IEnumerable<Emolumento> BuscarPorTipoItem(Guid tipo)
        {
            return _gsContext.Item.Where(p => p.TipoItemId == tipo).ToList();
        }

        public IEnumerable<Emolumento> BuscarTodos()
        {
            return _gsContext.Item.Include(s => s.Socio)
                                  .Include(s => s.Periodo)
                                  .Include(s => s.TipoItem)
                                  .Where(p => p.Status == true);
        }

        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual)
        {
            var ultimoCodigo = _gsContext.Item
                .Where(p => p.Codigo.StartsWith($"{tipoEntidade}{anoAtual}"))
                .OrderByDescending(p => p.Codigo)
                .Select(p => p.Codigo)
                .FirstOrDefault();

            return ultimoCodigo;
        }
    }
}
