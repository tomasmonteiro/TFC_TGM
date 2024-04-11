using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class TipoEmolumentoAppService : ITipoEmolumentoAppService
    {
        private readonly IMapper mapper;
        private readonly ITipoEmolumentoService tipoItemService;
        public TipoEmolumentoAppService(ITipoEmolumentoService tipoItemService, IMapper mapper)
        {
            this.mapper = mapper;
            this.tipoItemService = tipoItemService;
        }
        public void Adicionar(TipoEmolumentoViewModel tipoItem)
        {
            tipoItemService.Add(mapper.Map<TipoEmolumento>(tipoItem));
        }
        public void Atualizar(TipoEmolumentoViewModel tipoItem)
        {
            tipoItemService.Update(mapper.Map<TipoEmolumento>(tipoItem));
        }
        public TipoEmolumentoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<TipoEmolumentoViewModel>(tipoItemService.GetById(id));
        }
        public TipoEmolumentoViewModel BuscarPorNome(string nome)
        {
            return mapper.Map<TipoEmolumentoViewModel>(tipoItemService.BuscarPorNome(nome));
        }
        public IEnumerable<TipoEmolumentoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<TipoEmolumentoViewModel>>(tipoItemService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            tipoItemService.Eliminar(id);
        }
    }
}
