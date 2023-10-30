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
        private readonly GSContext _gsContext;

        public SocioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public ICollection<Socio> BuscarPorGenero(string genero)
        {
            return (ICollection<Socio>)_gsContext.Socio.Where(p => p.Genero == genero);
        }

        public Socio BuscarPorId(int id)
        {
            return (Socio)_gsContext.Socio.Where(p => p.Id == id);
        }

        public ICollection<Socio> BuscarPorNome(string nome)
        {
            return (ICollection<Socio>)_gsContext.Socio.Where(p => p.Nome == nome);
        }
    }
}
