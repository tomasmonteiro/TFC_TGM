using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class SocioAppService : ISocioAppService
    {
        private readonly IMapper mapper;
        private readonly ISocioService socioService;
        //
        public SocioAppService(IMapper mapper, ISocioService municipioService)
        {
            this.mapper = mapper;
            this.socioService = municipioService;
        }

        public void Adicionar(SocioViewModel socioViewModel)
        {
            socioService.Add(mapper.Map<Socio>(socioViewModel));
        }

        public void Atualizar(SocioViewModel socio)
        {
            socioService.Update(mapper.Map<Socio>(socio));
        }

        public IEnumerable<SocioViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<SocioViewModel>>(socioService.BuscarTodos());
        }

        public void Eliminar(int id)
        {
            socioService.Eliminar(id);
        }
    }
}
