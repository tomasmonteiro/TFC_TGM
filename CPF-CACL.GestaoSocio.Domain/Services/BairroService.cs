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
    public class BairroService : ServiceBase<Bairro>, IBairroService
    {
        private readonly IBairroRepository _bairroRepository;
        public BairroService(IBairroRepository bairroRepository) : base(bairroRepository)
        {
            _bairroRepository = bairroRepository;
        }

        public IEnumerable<Bairro> BuscarTodos()
        {
            return _bairroRepository.BuscarTodos();
        }
    }
}
