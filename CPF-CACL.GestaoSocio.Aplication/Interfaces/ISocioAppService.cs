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
        public void Adicionar(SocioViewModel socio);
        public IEnumerable<SocioViewModel> Buscar();
        public void Atualizar(SocioViewModel socio);
        public void Eliminar(int id);
    }
}
