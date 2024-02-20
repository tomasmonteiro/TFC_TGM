using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IMapper mapper;
        private readonly IPagamentoService pagamentoService;
        public PagamentoAppService(IPagamentoService pagamentoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.pagamentoService = pagamentoService;
        }
        public void Adicionar(PagamentoViewModel pagamento)
        {
            pagamentoService.Add(mapper.Map<Pagamento>(pagamento));
        }
        public void Atualizar(PagamentoViewModel pagamento)
        {
            pagamentoService.Update(mapper.Map<Pagamento>(pagamento));
        }

        public IEnumerable<PagamentoViewModel> BuscarDisponivel(Guid id)
        {
            return mapper.Map<IEnumerable<PagamentoViewModel>>(pagamentoService.BuscarDisponivel(id));
        }

        public PagamentoViewModel BuscarPorCod(string codigo)
        {
            return mapper.Map<PagamentoViewModel>(pagamentoService.BuscarPorCod(codigo));
        }
        public PagamentoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<PagamentoViewModel>(pagamentoService.GetById(id));
        }
        public IEnumerable<PagamentoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<PagamentoViewModel>>(pagamentoService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            pagamentoService.Eliminar(id);
        }
    }
}