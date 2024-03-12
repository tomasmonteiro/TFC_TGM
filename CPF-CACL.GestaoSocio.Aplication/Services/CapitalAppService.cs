using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class CapitalAppService : ICapitalAppService
    {
        private readonly IMapper mapper;
        private readonly ICapitalService capitalService;
//
        public CapitalAppService(IMapper mapper, ICapitalService capitalService)
        {
            this.mapper = mapper;
            this.capitalService = capitalService;
        }

        public void Adicionar(CapitalViewModel capitalViewModel)
        {
            capitalService.Add(mapper.Map<Capital>(capitalViewModel));
        }

        public void Atualizar(CapitalViewModel capital)
        {
            capitalService.Update(mapper.Map<Capital>(capital));
        }
        public IEnumerable<CapitalViewModel> BuscarTodosAtivos()
        {
            return mapper.Map<IEnumerable<CapitalViewModel>>(capitalService.BuscarTodos());
        }
        public IEnumerable<CapitalViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<CapitalViewModel>>(capitalService.GetAll());
        }
        public void Inativar(Guid id)
        {
            capitalService.Eliminar(id);
        }
        public void Eliminar(CapitalViewModel capital)
        {
            capitalService.Remove(mapper.Map<Capital>(capital));
        }

        public CapitalViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<CapitalViewModel>(capitalService.GetById(id)); ;
        }
    }
}
