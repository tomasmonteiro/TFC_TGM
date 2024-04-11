using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class SolicitacaoDeclaracaoRepository : RepositoryBase<SolicitacaoDeclaracao>, ISolicitacaoDeclaracaoRepository
    {
        private readonly GSContext _gsContext;
        public SolicitacaoDeclaracaoRepository( GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<SolicitacaoDeclaracao> BuscarSDPendentes()
        {
            return _gsContext.SolicitacaoDeclaracao.Include(b => b.TipoDeclaracao).Include(b => b.Socio).Where(p => p.EstadoSolicitacao == EEstadoSolicitacao.Pendente && p.Status == true);
        }
        public IEnumerable<SolicitacaoDeclaracao> BuscarSDConcluidos()
        {
            return _gsContext.SolicitacaoDeclaracao.Include(b => b.TipoDeclaracao).Include(b => b.Socio).Where(p => p.EstadoSolicitacao == EEstadoSolicitacao.Concluido && p.Status == true);
        }

        public IEnumerable<SolicitacaoDeclaracao> BuscarTodos()
        {
            return _gsContext.SolicitacaoDeclaracao.Include(b => b.TipoDeclaracao).Include(b => b.Socio).Where(p => p.Status == true);
        }

    }
}
