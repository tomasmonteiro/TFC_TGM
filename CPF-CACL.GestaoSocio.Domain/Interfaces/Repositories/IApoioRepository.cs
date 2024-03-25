using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IApoioRepository : IRepositoryBase<Apoio>
    {
        IEnumerable<Apoio> BuscarTodos();
        IEnumerable<Apoio> BuscarApoioPendente();
        IEnumerable<Apoio> BuscarApoioConcluido();
		IEnumerable<Apoio> BuscarApoioPorSocio(Guid socioId);
	}
}
