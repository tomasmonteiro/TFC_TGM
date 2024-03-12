using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ICapitalAppService
    {
        public void Adicionar(CapitalViewModel capital);
        public CapitalViewModel BuscarPorId(Guid id);
        public IEnumerable<CapitalViewModel> BuscarTodosAtivos();
        public IEnumerable<CapitalViewModel> BuscarTodos();
        public void Atualizar(CapitalViewModel capital);
        public void Inativar(Guid id);
        public void Eliminar(CapitalViewModel capital);
    }
}
