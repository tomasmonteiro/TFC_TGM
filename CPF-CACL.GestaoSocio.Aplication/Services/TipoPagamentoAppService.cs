using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class TipoPagamentoAppService : ITipoPagamentoAppService
    {
        private readonly IMapper mapper;
        private readonly ITipoPagamentoService tipoPagamentoService;
        private readonly ITipoPagamentoRepository tipoPagamentoRepository;
//
        public TipoPagamentoAppService(IMapper mapper, ITipoPagamentoService tipoPagamentoService, ITipoPagamentoRepository tipoPagamentoRepository)
        {
            this.mapper = mapper;
            this.tipoPagamentoService = tipoPagamentoService;
            this.tipoPagamentoRepository = tipoPagamentoRepository;
        }

        public void Add(TipoPagamentoViewModel tipoPagamentoViewModel)
        {
            tipoPagamentoService.Add(mapper.Map<TipoPagamento>(tipoPagamentoViewModel));
        }

        //public  IEnumerable<TipoPagamentoViewModel> GetAllTipo()
        //{

        //    return mapper.Map<IEnumerable<TipoPagamentoViewModel>>(tipoPagamentoRepository.GetAll());
            
        //}

        public IEnumerable<TipoPagamentoViewModel> BuscarTodosTipo()
        {

            return mapper.Map<IEnumerable<TipoPagamentoViewModel>>(tipoPagamentoService.BuscarTipos());

        }
    }
}
