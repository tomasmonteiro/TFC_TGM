using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoEmolumentoAppService 
    {
        public void Adicionar(TipoEmolumentoViewModel tipoItem);
        public IEnumerable<TipoEmolumentoViewModel> BuscarTodos();
        public TipoEmolumentoViewModel BuscarPorNome(string nome);
        public TipoEmolumentoViewModel BuscarPorId(Guid id);
        public void Atualizar(TipoEmolumentoViewModel tipoItem);
        public void Eliminar(Guid id);
    }
}
