using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IItemAppService
    {
        public void Adicionar(ItemViewModel item);
        public IEnumerable<ItemViewModel> BuscarTodos();
        public IEnumerable<ItemViewModel> BuscarItemNPago();
        public IEnumerable<ItemViewModel> BuscarItemPago();
		public IEnumerable<ItemViewModel> BuscarItemPorSocio(Guid socioId);
		public IEnumerable<ItemViewModel> BuscarPorTipoItem(Guid idTipoItem);
        public ItemViewModel BuscarPorCod(string codigo);
        public ItemViewModel BuscarPorId(Guid id);
        public void Atualizar(ItemViewModel item);
        public void Eliminar(Guid id);
    }
}
