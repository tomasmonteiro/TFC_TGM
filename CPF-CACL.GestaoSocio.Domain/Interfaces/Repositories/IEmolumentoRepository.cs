using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IEmolumentoRepository : IRepositoryBase<Emolumento>
    {
        IEnumerable<Emolumento> BuscarTodos();
        IEnumerable<Emolumento> BuscarItemPago();
        IEnumerable<Emolumento> BuscarItemNPago();
		IEnumerable<Emolumento> BuscarItemPorSocio(Guid socioId);
		Emolumento BuscarPorCod(string codigo);
        IEnumerable<Emolumento> BuscarPorTipoItem(Guid tipo);
        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual);
    }
}
