using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class EmolumentoAppService : IEmolumentoAppService
    {
        private readonly IMapper mapper;
        private readonly IEmolumentoService emolumentoService;

        public EmolumentoAppService(IEmolumentoService emolumentoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.emolumentoService = emolumentoService;
        }

        public void Adicionar(EmolumentoViewModel item)
        {
            emolumentoService.Add(mapper.Map<Emolumento>(item));
        }

        public void Atualizar(EmolumentoViewModel item)
        {
            emolumentoService.Update(mapper.Map<Emolumento>(item));
        }

        public IEnumerable<EmolumentoViewModel> BuscarItemNPago()
        {
            return mapper.Map<IEnumerable<EmolumentoViewModel>>(emolumentoService.BuscarItemNPago());
        }

        public IEnumerable<EmolumentoViewModel> BuscarItemPago()
        {
            return mapper.Map<IEnumerable<EmolumentoViewModel>>(emolumentoService.BuscarItemPago());
        }

		public IEnumerable<EmolumentoViewModel> BuscarItemPorSocio(Guid socioId)
		{
			return mapper.Map<IEnumerable<EmolumentoViewModel>>(emolumentoService.BuscarItemPorSocio(socioId));
		}

		public EmolumentoViewModel BuscarPorCod(string codigo)
        {
            return mapper.Map<EmolumentoViewModel>(emolumentoService.BuscarPorCod(codigo));
        }

        public EmolumentoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<EmolumentoViewModel>(emolumentoService.GetById(id));
        }
        public IEnumerable<EmolumentoViewModel> BuscarPorTipoItem(Guid idTipoItem)
        {
            return mapper.Map<IEnumerable<EmolumentoViewModel>>(emolumentoService.BuscarPorItemTipo(idTipoItem));
        }

        public IEnumerable<EmolumentoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<EmolumentoViewModel>>(emolumentoService.BuscarTodos());
        }

        public void Eliminar(Guid id)
        {
            emolumentoService.Eliminar(id);
        }
    }
}
