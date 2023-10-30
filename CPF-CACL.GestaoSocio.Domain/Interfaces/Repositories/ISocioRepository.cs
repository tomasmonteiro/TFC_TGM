using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ISocioRepository : IRepositoryBase<Socio>
    {
        ICollection<Socio> BuscarPorNome(string nome);
        public Socio BuscarPorId(int id);

        ICollection<Socio> BuscarPorGenero(string genero);



    }
}
