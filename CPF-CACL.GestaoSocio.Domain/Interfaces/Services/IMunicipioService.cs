using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IMunicipioService : IServiceBase<Municipio>
    {
        IEnumerable<Municipio> BuscarTodos();

    }
}
