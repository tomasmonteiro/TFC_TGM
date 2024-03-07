using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class TipoBeneficioAppService : ITipoBeneficioAppService
    {
        private readonly IMapper mapper;
        private readonly ITipoBeneficioService tipoBeneficioService;
//
        public TipoBeneficioAppService(IMapper mapper, ITipoBeneficioService tipoBeneficioService)
        {
            this.mapper = mapper;
            this.tipoBeneficioService = tipoBeneficioService;
        }

        public void Adicionar(TipoBeneficioViewModel tipoBeneficioViewModel)
        {
            tipoBeneficioService.Add(mapper.Map<TipoBeneficio>(tipoBeneficioViewModel));
        }

        public void Atualizar(TipoBeneficioViewModel tipoBeneficio)
        {
            tipoBeneficioService.Update(mapper.Map<TipoBeneficio>(tipoBeneficio));
        }
        public TipoBeneficioViewModel BuscarPorNome(string nome)
        {
            return mapper.Map<TipoBeneficioViewModel>(tipoBeneficioService.BuscarPorNome(nome));
        }
        public IEnumerable<TipoBeneficioViewModel> BuscarTodosAtivos()
        {
            return mapper.Map<IEnumerable<TipoBeneficioViewModel>>(tipoBeneficioService.BuscarTodos());
        }
        public IEnumerable<TipoBeneficioViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<TipoBeneficioViewModel>>(tipoBeneficioService.GetAll());
        }
        public void Inativar(Guid id)
        {
            tipoBeneficioService.Eliminar(id);
        }
        public void Eliminar(TipoBeneficioViewModel tipoBeneficio)
        {
            tipoBeneficioService.Remove(mapper.Map<TipoBeneficio>(tipoBeneficio));
        }

        public TipoBeneficioViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<TipoBeneficioViewModel>(tipoBeneficioService.GetById(id)); ;
        }
    }
}
