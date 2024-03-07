using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class CategoriaSocioAppService : ICategoriaSocioAppService
    {
        private readonly IMapper mapper;
        private readonly ICategoriaSocioService categoriaSocioService;
        private readonly ICategoriaSocioRepository categoriaSocioRepository;
        //
        public CategoriaSocioAppService(IMapper mapper, ICategoriaSocioService categoriaSocioService, ICategoriaSocioRepository categoriaSocioRepository)
        {
            this.mapper = mapper;
            this.categoriaSocioService = categoriaSocioService;
            this.categoriaSocioRepository = categoriaSocioRepository;
        }

        public void Adicionar(CategoriaSocioViewModel categoriaSocioViewModel)
        {
            categoriaSocioService.Add(mapper.Map<CategoriaSocio>(categoriaSocioViewModel));
        }

        public void Atualizar(CategoriaSocioViewModel categoria)
        {
            categoriaSocioService.Update(mapper.Map<CategoriaSocio>(categoria));
        }

        public IEnumerable<CategoriaSocioViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<CategoriaSocioViewModel>>(categoriaSocioService.BuscarTodos());
        }

        public void Eliminar(Guid id)
        {
            categoriaSocioService.Eliminar(id);
        }
    }
}
