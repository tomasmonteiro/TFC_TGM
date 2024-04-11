using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class PagamentoEmolumentoAppService : IPagamentoEmolumentoAppService
    {
        private readonly IMapper mapper;
        private readonly IPagamentoEmolumentoService pagamentoEmolumentoService;
        public PagamentoEmolumentoAppService(IPagamentoEmolumentoService pagamentoEmolumentoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.pagamentoEmolumentoService = pagamentoEmolumentoService;
        }

        public void Adicionar(PagamentoEmolumentoViewModel pagamentoEmolumento)
        {
            pagamentoEmolumentoService.Add(mapper.Map<PagamentoEmolumento>(pagamentoEmolumento));
        }

        public void Atualizar(PagamentoEmolumentoViewModel pagamentoEmolumento)
        {
            pagamentoEmolumentoService.Update(mapper.Map<PagamentoEmolumento>(pagamentoEmolumento));
        }

        public IEnumerable<PagamentoEmolumentoViewModel> BuscarPagamentoEmolumentoPorSocio(Guid socioId)
        {
            return mapper.Map<IEnumerable<PagamentoEmolumentoViewModel>>(pagamentoEmolumentoService.BuscarItemPorSocio(socioId));
        }

        public PagamentoEmolumentoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<PagamentoEmolumentoViewModel>(pagamentoEmolumentoService.GetById(id));
        }
        public IEnumerable<PagamentoEmolumentoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<PagamentoEmolumentoViewModel>>(pagamentoEmolumentoService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            pagamentoEmolumentoService.Eliminar(id);
        }

    }
}
