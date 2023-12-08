using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IOrganismoAppService
    {
        public void Adicionar(OrganismoViewModel organismo);
        public IEnumerable<OrganismoViewModel> Buscar();
        public void Atualizar(OrganismoViewModel organismo);
        public void Eliminar(int id);
    }
}
