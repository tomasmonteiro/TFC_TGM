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
    
    public class MunicipioService : ServiceBase<Municipio>, IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;
        public MunicipioService(IMunicipioRepository municipioRepository) : base(municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        public IEnumerable<Municipio> BuscarTodos()
        {
            return _municipioRepository.BuscarTodos();
        }
    }
}
