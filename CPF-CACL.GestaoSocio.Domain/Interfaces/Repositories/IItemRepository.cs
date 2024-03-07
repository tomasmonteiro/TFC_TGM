using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        IEnumerable<Item> BuscarTodos();
        IEnumerable<Item> BuscarItemPago();
        IEnumerable<Item> BuscarItemNPago();
		IEnumerable<Item> BuscarItemPorSocio(Guid socioId);
		Item BuscarPorCod(string codigo);
        IEnumerable<Item> BuscarPorTipoItem(Guid tipo);
        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual);
    }
}
