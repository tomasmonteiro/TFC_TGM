using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IBeneficioAppService
    {
        public void Adicionar(BeneficioViewModel beneficio);
        public BeneficioViewModel BuscarPorId(Guid id);
        public IEnumerable<BeneficioViewModel> BuscarPorTipo(Guid tipoBeneficioId);
        public IEnumerable<BeneficioViewModel> BuscarTodosAtivos();
        public IEnumerable<BeneficioViewModel> BuscarTodos();
        public void Atualizar(BeneficioViewModel beneficio);
        public void Inativar(Guid id);
        public void Eliminar(BeneficioViewModel beneficio);
    }
}
