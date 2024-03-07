using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IBairroRepository : IRepositoryBase<Bairro>
    {
        IEnumerable<Bairro> BuscarTodos();
        IEnumerable<Bairro> BuscarPorMunicipio(Guid idMunicipio);
    }
}
