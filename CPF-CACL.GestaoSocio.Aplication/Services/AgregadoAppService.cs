using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class AgregadoAppService : IAgregadoAppService
    {
        private readonly IMapper mapper;
        private readonly IAgregadoService agregadoService;
        private readonly IAgregadoRepository agregadoRepository;
        //
        public AgregadoAppService(IMapper mapper, IAgregadoService agregadoService, IAgregadoRepository agregadoRepository)
        {
            this.mapper = mapper;
            this.agregadoService = agregadoService;
            this.agregadoRepository = agregadoRepository;
        }

        public void Adicionar(AgregadoViewModel agregadoViewModel)
        {
            agregadoService.Add(mapper.Map<Agregado>(agregadoViewModel));
        }

        public void Atualizar(AgregadoViewModel agregadoViewModel)
        {
            agregadoService.Update(mapper.Map<Agregado>(agregadoViewModel));
        }

        public IEnumerable<AgregadoViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<AgregadoViewModel>>(agregadoService.BuscarTodos());
        }

        public void Eliminar(Guid id)
        {
            agregadoService.Eliminar(id);
        }
    }
}
