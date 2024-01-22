using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IBairroAppService
    {
        public void Adicionar(BairroViewModel bairro);

        public IEnumerable<BairroViewModel> Buscar();
        public void Atualizar(BairroViewModel bairro);
        public void Eliminar(Guid id);

    }
}
