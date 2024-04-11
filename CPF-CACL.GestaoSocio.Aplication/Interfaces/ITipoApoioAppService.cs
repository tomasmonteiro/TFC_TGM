using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoApoioAppService
    {
        public void Adicionar(TipoApoioViewModel tipoApoio);
        public TipoApoioViewModel BuscarPorTipo(string tipo);
        public IEnumerable<TipoApoioViewModel> BuscarTodos();
        public TipoApoioViewModel BuscarPorId(Guid id);
        public void Atualizar(TipoApoioViewModel tipoApoio);
        public void Inativar(Guid id);
        public void Eliminar(TipoApoioViewModel tipoApoio);
    }
}
