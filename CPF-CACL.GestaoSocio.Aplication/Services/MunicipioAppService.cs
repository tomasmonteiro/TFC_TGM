using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

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


        public void Adicionar(MunicipioViewModel municipioViewModel)
        {
            municipioService.Add(mapper.Map<Municipio>(municipioViewModel));
        }

        public void Atualizar(MunicipioViewModel municipio)
        {
            municipioService.Update(mapper.Map<Municipio>(municipio));
        }

        public IEnumerable<MunicipioViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<MunicipioViewModel>>(municipioService.BuscarTodos());
        }

        public void Eliminar(Guid id)
        {
            municipioService.Eliminar(id);
        }
    }
}
