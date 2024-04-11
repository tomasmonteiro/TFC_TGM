using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class SolicitacaoApoioAppService : ISolicitacaoApoioAppService
    {
        private readonly IMapper mapper;
        private readonly ISolicitacaoApoioService solicitacaoApoioService;
        public SolicitacaoApoioAppService(ISolicitacaoApoioService solicitacaoApoioService, IMapper mapper)
        {
            this.mapper = mapper;
            this.solicitacaoApoioService = solicitacaoApoioService;
        }
        public void Adicionar(SolicitacaoApoioViewModel solicitacaoApoio)
        {
            solicitacaoApoioService.Add(mapper.Map<SolicitacaoApoio>(solicitacaoApoio));
        }
        public void Atualizar(SolicitacaoApoioViewModel solicitacaoApoio)
        {
            solicitacaoApoioService.Update(mapper.Map<SolicitacaoApoio>(solicitacaoApoio));
        }

        public IEnumerable<SolicitacaoApoioViewModel> BuscarSAPendentes()
        {
            return mapper.Map<IEnumerable<SolicitacaoApoioViewModel>>(solicitacaoApoioService.BuscarSAPendentes());
        }
        public IEnumerable<SolicitacaoApoioViewModel> BuscarSAConcluidos()
        {
            return mapper.Map<IEnumerable<SolicitacaoApoioViewModel>>(solicitacaoApoioService.BuscarSAConcluidos());
        }

        public SolicitacaoApoioViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<SolicitacaoApoioViewModel>(solicitacaoApoioService.GetById(id));
        }
        public IEnumerable<SolicitacaoApoioViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<SolicitacaoApoioViewModel>>(solicitacaoApoioService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            solicitacaoApoioService.Eliminar(id);
        }

        IEnumerable<SolicitacaoApoioViewModel> ISolicitacaoApoioAppService.BuscarPorTipo(Guid tipoId)
        {
            return mapper.Map<IEnumerable<SolicitacaoApoioViewModel>>(solicitacaoApoioService.BuscarPorTipo(tipoId));
        }
    }
}
