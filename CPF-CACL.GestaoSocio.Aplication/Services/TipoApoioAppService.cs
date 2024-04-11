using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class TipoApoioAppService : ITipoApoioAppService
    {
        private readonly IMapper mapper;
        private readonly ITipoApoioService tipoApoioService;
        public TipoApoioAppService(ITipoApoioService tipoApoioService, IMapper mapper)
        {
            this.mapper = mapper;
            this.tipoApoioService = tipoApoioService;
        }
        public void Adicionar(TipoApoioViewModel tipoApoio)
        {
            tipoApoioService.Add(mapper.Map<TipoApoio>(tipoApoio));
        }
        public void Atualizar(TipoApoioViewModel tipoApoio)
        {
            tipoApoioService.Update(mapper.Map<TipoApoio>(tipoApoio));
        }
        public TipoApoioViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<TipoApoioViewModel>(tipoApoioService.GetById(id));
        }
        public TipoApoioViewModel BuscarPorTipo(string tipo)
        {
            return mapper.Map<TipoApoioViewModel>(tipoApoioService.BuscarPorTipo(tipo));
        }
        public IEnumerable<TipoApoioViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<TipoApoioViewModel>>(tipoApoioService.BuscarTodos());
        }

        public void Eliminar(TipoApoioViewModel tipoApoio)
        {
            tipoApoioService.Remove(mapper.Map<TipoApoio>(tipoApoio));
        }

        public void Inativar(Guid id)
        {
            tipoApoioService.Eliminar(id);
        }
    }
}
