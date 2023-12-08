using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Services;

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

        public void Adicionar(TipoPagamentoViewModel tipoPagamentoViewModel)
        {
            tipoPagamentoService.Add(mapper.Map<TipoPagamento>(tipoPagamentoViewModel));
        }

        public void Atualizar(TipoPagamentoViewModel tipoPagamento)
        {
            tipoPagamentoService.Update(mapper.Map<TipoPagamento>(tipoPagamento));
        }

        public IEnumerable<TipoPagamentoViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<TipoPagamentoViewModel>>(tipoPagamentoService.BuscarTipos());
        }
        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
