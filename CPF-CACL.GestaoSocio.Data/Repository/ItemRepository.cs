using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        private readonly GSContext _gsContext;
        public ItemRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<Item> BuscarItemNPago()
        {
            return _gsContext.Item.Where(p => p.Estado == EEstadoItem.NaoPago);
        }

        public IEnumerable<Item> BuscarItemPago()
        {
            return _gsContext.Item.Where(p => p.Estado == EEstadoItem.Pago);
        }

		public IEnumerable<Item> BuscarItemPorSocio(Guid socioId)
		{
			return _gsContext.Item
                .Include(s => s.Periodo)
                .Where(p => p.Estado == EEstadoItem.NaoPago && p.SocioId == socioId && p.Status == true);
		}

		public Item BuscarPorCod(string codigo)
        {
            return _gsContext.Item.Where(p => p.Cod == codigo).FirstOrDefault();
        }

        public IEnumerable<Item> BuscarPorTipoItem(Guid tipo)
        {
            return _gsContext.Item.Where(p => p.TipoItemId == tipo).ToList();
        }

        public IEnumerable<Item> BuscarTodos()
        {
            return _gsContext.Item.Include(s => s.Socio)
                                  .Include(s => s.Periodo)
                                  .Include(s => s.TipoItem)
                                  .Where(p => p.Status == true);
        }

        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual)
        {
            var ultimoCodigo = _gsContext.Item
                .Where(p => p.Cod.StartsWith($"{tipoEntidade}{anoAtual}"))
                .OrderByDescending(p => p.Cod)
                .Select(p => p.Cod)
                .FirstOrDefault();

            return ultimoCodigo;
        }
    }
}
