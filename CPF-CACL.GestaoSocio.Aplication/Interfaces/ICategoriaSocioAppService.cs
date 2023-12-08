using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ICategoriaSocioAppService
    {
        public void Adicionar(CategoriaSocioViewModel categoria);

        public IEnumerable<CategoriaSocioViewModel> Buscar();

        public void Atualizar(CategoriaSocioViewModel categoria);
        public void Eliminar(int id);
    }
}
