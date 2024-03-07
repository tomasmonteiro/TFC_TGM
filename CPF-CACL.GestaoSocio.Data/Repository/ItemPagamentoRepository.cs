using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class ItemPagamentoRepository : RepositoryBase<ItemPagamento>, IItemPagamentoRepository
    {
        private readonly GSContext _gsContext;

        public ItemPagamentoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<ItemPagamento> BuscarItemPagamentoPorSocio(Guid socioId)
        {
            var itens = _gsContext.ItemPagamento
				.Include(p => p.Pagamento)
				.Include(p => p.Item)
				.Where(s => s.Status == true && s.Pagamento.SocioId == socioId).ToList();


            return itens;


        }

        public IEnumerable<ItemPagamento> BuscarTodos()
        {
            return _gsContext.ItemPagamento.Where(p => p.Status == true);

        }
    }
}
