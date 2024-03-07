using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class TipoItemAppService : ITipoItemAppService
    {
        private readonly IMapper mapper;
        private readonly ITipoItemService tipoItemService;
        public TipoItemAppService(ITipoItemService tipoItemService, IMapper mapper)
        {
            this.mapper = mapper;
            this.tipoItemService = tipoItemService;
        }
        public void Adicionar(TipoItemViewModel tipoItem)
        {
            tipoItemService.Add(mapper.Map<TipoItem>(tipoItem));
        }
        public void Atualizar(TipoItemViewModel tipoItem)
        {
            tipoItemService.Update(mapper.Map<TipoItem>(tipoItem));
        }
        public TipoItemViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<TipoItemViewModel>(tipoItemService.GetById(id));
        }
        public TipoItemViewModel BuscarPorNome(string nome)
        {
            return mapper.Map<TipoItemViewModel>(tipoItemService.BuscarPorNome(nome));
        }
        public IEnumerable<TipoItemViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<TipoItemViewModel>>(tipoItemService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            tipoItemService.Eliminar(id);
        }
    }
}
