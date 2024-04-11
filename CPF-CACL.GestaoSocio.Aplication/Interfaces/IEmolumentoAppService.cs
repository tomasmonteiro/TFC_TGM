using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IEmolumentoAppService 
    {
        public void Adicionar(EmolumentoViewModel item);
        public IEnumerable<EmolumentoViewModel> BuscarTodos();
        public IEnumerable<EmolumentoViewModel> BuscarItemNPago();
        public IEnumerable<EmolumentoViewModel> BuscarItemPago();
		public IEnumerable<EmolumentoViewModel> BuscarItemPorSocio(Guid socioId);
		public IEnumerable<EmolumentoViewModel> BuscarPorTipoItem(Guid idTipoItem);
        public EmolumentoViewModel BuscarPorCod(string codigo);
        public EmolumentoViewModel BuscarPorId(Guid id);
        public void Atualizar(EmolumentoViewModel item);
        public void Eliminar(Guid id);
    }
}
