using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class ItemAppService : IItemAppService
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService;

        public ItemAppService(IItemService itemService, IMapper mapper)
        {
            this.mapper = mapper;
            this.itemService = itemService;
        }

        public void Adicionar(ItemViewModel item)
        {
            itemService.Add(mapper.Map<Item>(item));
        }

        public void Atualizar(ItemViewModel item)
        {
            itemService.Update(mapper.Map<Item>(item));
        }

        public IEnumerable<ItemViewModel> BuscarItemNPago()
        {
            return mapper.Map<IEnumerable<ItemViewModel>>(itemService.BuscarItemNPago());
        }

        public IEnumerable<ItemViewModel> BuscarItemPago()
        {
            return mapper.Map<IEnumerable<ItemViewModel>>(itemService.BuscarItemPago());
        }

		public IEnumerable<ItemViewModel> BuscarItemPorSocio(Guid socioId)
		{
			return mapper.Map<IEnumerable<ItemViewModel>>(itemService.BuscarItemPorSocio(socioId));
		}

		public ItemViewModel BuscarPorCod(string codigo)
        {
            return mapper.Map<ItemViewModel>(itemService.BuscarPorCod(codigo));
        }

        public ItemViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<ItemViewModel>(itemService.GetById(id));
        }
        public IEnumerable<ItemViewModel> BuscarPorTipoItem(Guid idTipoItem)
        {
            return mapper.Map<IEnumerable<ItemViewModel>>(itemService.BuscarPorItemTipo(idTipoItem));
        }

        public IEnumerable<ItemViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<ItemViewModel>>(itemService.BuscarTodos());
        }

        public void Eliminar(Guid id)
        {
            itemService.Eliminar(id);
        }
    }
}
