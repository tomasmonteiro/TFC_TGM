using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class SocioService : ServiceBase<Socio>, ISocioService
    {
        private readonly ISocioRepository _socioRepository;
        public SocioService(ISocioRepository socioRepository) 
            : base(socioRepository)
        {
            _socioRepository = socioRepository;
        }

        public IEnumerable<Socio> BuscarPorNome(string nome)
        {
            return _socioRepository.BuscarPorNome(nome);
        }
    }
}
