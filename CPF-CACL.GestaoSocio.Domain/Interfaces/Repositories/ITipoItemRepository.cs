using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ITipoItemRepository : IRepositoryBase<TipoItem>
    {
        IEnumerable<TipoItem> BuscarTodos();
        IEnumerable<TipoItem> BuscarPorNome(string nome);
		TipoItem BuscarJoia();
	}
}
