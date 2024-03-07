using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class ItemPagamentoAppService : IItemPagamentoAppService
    {
        private readonly IMapper mapper;
        private readonly IItemPagamentoService itemPagamentoService;
        public ItemPagamentoAppService(IItemPagamentoService itemPagamentoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.itemPagamentoService = itemPagamentoService;
        }

        public void Adicionar(ItemPagamentoViewModel itemPagamento)
        {
            itemPagamentoService.Add(mapper.Map<ItemPagamento>(itemPagamento));
        }

        public void Atualizar(ItemPagamentoViewModel itemPagamento)
        {
            itemPagamentoService.Update(mapper.Map<ItemPagamento>(itemPagamento));
        }

        public IEnumerable<ItemPagamentoViewModel> BuscarItemPagamentoPorSocio(Guid socioId)
        {
            return mapper.Map<IEnumerable<ItemPagamentoViewModel>>(itemPagamentoService.BuscarItemPorSocio(socioId));
        }

        public ItemPagamentoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<ItemPagamentoViewModel>(itemPagamentoService.GetById(id));
        }
        public IEnumerable<ItemPagamentoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<ItemPagamentoViewModel>>(itemPagamentoService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            itemPagamentoService.Eliminar(id);
        }

    }
}
