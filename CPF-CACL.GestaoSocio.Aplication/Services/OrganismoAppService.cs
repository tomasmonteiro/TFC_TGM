using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class OrganismoAppService : IOrganismoAppService
    {
        private readonly IMapper mapper;
        private readonly IOrganismoService organismoService;

        public OrganismoAppService(IMapper mapper, IOrganismoService organismoService)
        {
            this.mapper = mapper;
            this.organismoService = organismoService;
        }

        public void Adicionar(OrganismoViewModel organismoViewModel)
        {
            organismoService.Add(mapper.Map<Organismo>(organismoViewModel));
        }

        public void Atualizar(OrganismoViewModel organismo)
        {
            organismoService.Update(mapper.Map<Organismo>(organismo));
        }

        public IEnumerable<OrganismoViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<OrganismoViewModel>>(organismoService.BuscarTodos());
        }

        public void Eliminar(Guid id)
        {
            organismoService.Eliminar(id);
        }
    }
}
