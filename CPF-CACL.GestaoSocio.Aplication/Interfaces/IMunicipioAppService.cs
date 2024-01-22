using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IMunicipioAppService
    {
        public void Adicionar(MunicipioViewModel municipio);
        public IEnumerable<MunicipioViewModel> Buscar();
        public void Atualizar(MunicipioViewModel municipio);
        public void Eliminar(Guid id);

    }
}
