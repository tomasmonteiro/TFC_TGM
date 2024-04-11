using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class SolicitacaoDeclaracaoAppService : ISolicitacaoDeclaracaoAppService
    {
        private readonly IMapper mapper;
        private readonly ISolicitacaoDeclaracaoService solicitacaoDeclaracaoService;
        public SolicitacaoDeclaracaoAppService(ISolicitacaoDeclaracaoService solicitacaoDeclaracaoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.solicitacaoDeclaracaoService = solicitacaoDeclaracaoService;
        }
        public void Adicionar(SolicitacaoDeclaracaoViewModel solicitacaoDeclaracao)
        {
            solicitacaoDeclaracaoService.Add(mapper.Map<SolicitacaoDeclaracao>(solicitacaoDeclaracao));
        }
        public void Atualizar(SolicitacaoDeclaracaoViewModel solicitacaoDeclaracao)
        {
            solicitacaoDeclaracaoService.Update(mapper.Map<SolicitacaoDeclaracao>(solicitacaoDeclaracao));
        }
        public IEnumerable<SolicitacaoDeclaracaoViewModel> BuscarSDPendentes()
        {
            return mapper.Map<IEnumerable<SolicitacaoDeclaracaoViewModel>>(solicitacaoDeclaracaoService.BuscarSDPendentes());
        }
        public IEnumerable<SolicitacaoDeclaracaoViewModel> BuscarSDConcluidos()
        {
            return mapper.Map<IEnumerable<SolicitacaoDeclaracaoViewModel>>(solicitacaoDeclaracaoService.BuscarSDConcluidos());
        }

        public SolicitacaoDeclaracaoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<SolicitacaoDeclaracaoViewModel>(solicitacaoDeclaracaoService.GetById(id));
        }
        public IEnumerable<SolicitacaoDeclaracaoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<SolicitacaoDeclaracaoViewModel>>(solicitacaoDeclaracaoService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            solicitacaoDeclaracaoService.Eliminar(id);
        }
    }
}
