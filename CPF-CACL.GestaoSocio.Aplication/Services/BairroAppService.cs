using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class BairroAppService : IBairroAppService
    {
        private readonly IMapper mapper;
        private readonly IBairroService bairroService;
        private readonly IBairroRepository bairroRepository;
        //
        public BairroAppService(IMapper mapper, IBairroService bairroService, IBairroRepository bairroRepository)
        {
            this.mapper = mapper;
            this.bairroService = bairroService;
            this.bairroRepository = bairroRepository;
        }

        public void Add(BairroViewModel bairroViewModel)
        {
            bairroService.Add(mapper.Map<Bairro>(bairroViewModel));
        }

        public IEnumerable<BairroViewModel> BuscarBairros()
        {
            return mapper.Map<IEnumerable<BairroViewModel>>(bairroService.BuscarTodos());  
        }
    }
}
