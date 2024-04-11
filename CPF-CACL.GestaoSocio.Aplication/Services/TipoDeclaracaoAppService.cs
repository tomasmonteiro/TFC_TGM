using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class TipoDeclaracaoAppService : ITipoDeclaracaoAppService
    {
        private readonly IMapper mapper;
        private readonly ITipoDeclaracaoService tipoDeclaracaoService;
        public TipoDeclaracaoAppService(ITipoDeclaracaoService tipoDeclaracaoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.tipoDeclaracaoService = tipoDeclaracaoService;
        }
        public void Adicionar(TipoDeclaracaoViewModel tipoDeclaracao)
        {
            tipoDeclaracaoService.Add(mapper.Map<TipoDeclaracao>(tipoDeclaracao));
        }
        public void Atualizar(TipoDeclaracaoViewModel tipoDeclaracao)
        {
            tipoDeclaracaoService.Update(mapper.Map<TipoDeclaracao>(tipoDeclaracao));
        }
        public TipoDeclaracaoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<TipoDeclaracaoViewModel>(tipoDeclaracaoService.GetById(id));
        }
        public TipoDeclaracaoViewModel BuscarPorTipo(string tipo)
        {
            return mapper.Map<TipoDeclaracaoViewModel>(tipoDeclaracaoService.BuscarPorTipo(tipo));
        }
        public IEnumerable<TipoDeclaracaoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<TipoDeclaracaoViewModel>>(tipoDeclaracaoService.BuscarTodos());
        }

        public void Eliminar(TipoDeclaracaoViewModel tipoDeclaracao)
        {
            tipoDeclaracaoService.Remove(mapper.Map<TipoDeclaracao>(tipoDeclaracao));
        }

        public void Inativar(Guid id)
        {
            tipoDeclaracaoService.Eliminar(id);
        }
    }
}
