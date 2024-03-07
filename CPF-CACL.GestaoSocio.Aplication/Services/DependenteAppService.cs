using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class DependenteAppService : IDependenteAppService
    {
        private readonly IMapper mapper;
        private readonly IDependenteService dependenteService;
        private readonly IDependenteRepository dependenteRepository;
        //
        public DependenteAppService(IMapper mapper, IDependenteService dependenteService, IDependenteRepository dependenteRepository)
        {
            this.mapper = mapper;
            this.dependenteService = dependenteService;
            this.dependenteRepository = dependenteRepository;
        }

        public void Adicionar(DependenteViewModel agregadoViewModel)
        {
            dependenteService.Add(mapper.Map<Dependente>(agregadoViewModel));
        }

        public void Atualizar(DependenteViewModel agregadoViewModel)
        {
            dependenteService.Update(mapper.Map<Dependente>(agregadoViewModel));
        }

        public IEnumerable<DependenteViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<DependenteViewModel>>(dependenteService.BuscarTodos());
        }

		public IEnumerable<DependenteViewModel> BuscarDependentePorSocio(Guid socioId)
		{

			return mapper.Map<IEnumerable<DependenteViewModel>>(dependenteService.BuscarAgregadoPorSocio(socioId));
		}

		public void Eliminar(Guid id)
        {
            dependenteService.Eliminar(id);
        }
    }
}
