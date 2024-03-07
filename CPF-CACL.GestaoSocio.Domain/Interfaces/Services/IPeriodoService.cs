using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IPeriodoService : IServiceBase<Periodo>
    {
        void AdicionarPeriodoEItem(Periodo periodo);
        Periodo BuscarPorCod(string codigo);
        string GerarCodigoPeriodo(DateTime data);

	}
}
