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
        public void Add(BairroViewModel bairroViewModel);

        //public IEnumerable<BairroViewModel>  GetAll();

        public IEnumerable<BairroViewModel> BuscarBairros();

    }
}
