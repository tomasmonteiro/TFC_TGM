using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ITipoEmolumentoRepository : IRepositoryBase<TipoEmolumento>
    {
        IEnumerable<TipoEmolumento> BuscarTodos();
        IEnumerable<TipoEmolumento> BuscarPorNome(string nome);
		TipoEmolumento BuscarJoia();
	}
}
