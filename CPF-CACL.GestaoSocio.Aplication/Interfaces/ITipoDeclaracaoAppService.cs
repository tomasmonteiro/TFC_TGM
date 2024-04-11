using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoDeclaracaoAppService
    {
        public void Adicionar(TipoDeclaracaoViewModel tipoDeclaracao);
        public TipoDeclaracaoViewModel BuscarPorTipo(string tipo);
        public IEnumerable<TipoDeclaracaoViewModel> BuscarTodos();
        public TipoDeclaracaoViewModel BuscarPorId(Guid id);
        public void Atualizar(TipoDeclaracaoViewModel tipoDeclaracao);
        public void Inativar(Guid id);
        public void Eliminar(TipoDeclaracaoViewModel tipoDeclaracao);
    }
}
