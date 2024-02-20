using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoItemAppService
    {
        public void Adicionar(TipoItemViewModel tipoItem);
        public IEnumerable<TipoItemViewModel> BuscarTodos();
        public TipoItemViewModel BuscarPorNome(string nome);
        public TipoItemViewModel BuscarPorId(Guid id);
        public void Atualizar(TipoItemViewModel tipoItem);
        public void Eliminar(Guid id);
    }
}
