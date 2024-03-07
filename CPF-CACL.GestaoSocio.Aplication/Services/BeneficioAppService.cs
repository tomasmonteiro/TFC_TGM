using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class BeneficioAppService : IBeneficioAppService
    {
        private readonly IMapper mapper;
        private readonly IBeneficioService beneficioService;
//
        public BeneficioAppService(IMapper mapper, IBeneficioService beneficioService)
        {
            this.mapper = mapper;
            this.beneficioService = beneficioService;
        }

        public void Adicionar(BeneficioViewModel beneficioViewModel)
        {
            beneficioService.Add(mapper.Map<Beneficio>(beneficioViewModel));
        }

        public void Atualizar(BeneficioViewModel beneficio)
        {
            beneficioService.Update(mapper.Map<Beneficio>(beneficio));
        }
        public IEnumerable<BeneficioViewModel> BuscarPorTipo(Guid tipoBeneficioId)
        {
            return mapper.Map<IEnumerable<BeneficioViewModel>>(beneficioService.BuscarPorTipo(tipoBeneficioId));
        }
        public IEnumerable<BeneficioViewModel> BuscarTodosAtivos()
        {
            return mapper.Map<IEnumerable<BeneficioViewModel>>(beneficioService.BuscarTodos());
        }
        public IEnumerable<BeneficioViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<BeneficioViewModel>>(beneficioService.GetAll());
        }
        public void Inativar(Guid id)
        {
            beneficioService.Eliminar(id);
        }
        public void Eliminar(BeneficioViewModel beneficio)
        {
            beneficioService.Remove(mapper.Map<Beneficio>(beneficio));
        }

        public BeneficioViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<BeneficioViewModel>(beneficioService.GetById(id)); ;
        }
    }
}
