using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ISocioAppService 
    {
        public Guid Adicionar(SocioViewModel socio);
        public IEnumerable<SocioViewModel> Buscar();
        public SocioViewModel BuscarPorId(Guid id);
        public SocioViewModel BuscarPorCod(string codigo);
        public void Atualizar(SocioViewModel socio);
        public void Eliminar(Guid id);
    }
}
