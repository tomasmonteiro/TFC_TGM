using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IPeriodoRepository : IRepositoryBase<Periodo>
    {
        void AdicionarPeriodoEItem(Periodo periodo);
        IEnumerable<Periodo> BuscarTodos();
        Periodo BuscarPorCod(string codigo);
        void SaveChanges();
    }
}
