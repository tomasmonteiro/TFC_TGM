using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class MunicipioAppService : IMunicipioAppService
    {
        private readonly IMapper mapper;
        private readonly IMunicipioService municipioService;
        private readonly IMunicipioRepository municipioRepository;
        //
        public MunicipioAppService(IMapper mapper, IMunicipioService municipioService, IMunicipioRepository municipioRepository)
        {
            this.mapper = mapper;
            this.municipioService = municipioService;
            this.municipioRepository = municipioRepository;
        }


        public void Add(MunicipioViewModel municipioViewModel)
        {
            municipioService.Add(mapper.Map<Municipio>(municipioViewModel));
        }

        public IEnumerable<MunicipioViewModel> BuscarMunicipios()
        {
            return mapper.Map<IEnumerable<MunicipioViewModel>>(municipioService.BuscarTodos());
        }
    }
}
