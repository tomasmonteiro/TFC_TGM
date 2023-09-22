using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class SocioRepository : RepositoryBase<Socio>, ISocioRepository
    {
        public IEnumerable<Socio> BuscarPorNome(string nome)
        {
            return _gsContext.Socio.Where(p => p.Nome == nome);
        }
    }
}
