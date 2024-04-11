using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class SolicitacaoApoioRepository : RepositoryBase<SolicitacaoApoio>, ISolicitacaoApoioRepository
    {
        private readonly GSContext _gsContext;
        public SolicitacaoApoioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public IEnumerable<SolicitacaoApoio> BuscarSAPendentes()
        {
            return _gsContext.SolicitacaoApoio.Include(b => b.TipoApoio).Include(b => b.Socio).Where(p => p.EstadoSolicitacao == EEstadoSolicitacao.Pendente && p.Status == true);
        }
        public IEnumerable<SolicitacaoApoio> BuscarSAConcluidos()
        {
            return _gsContext.SolicitacaoApoio.Include(b => b.TipoApoio).Include(b => b.Socio).Where(p => p.EstadoSolicitacao == EEstadoSolicitacao.Concluido && p.Status == true);
        }

        public IEnumerable<SolicitacaoApoio> BuscarPorTipo(Guid TipoId)
        {
            return _gsContext.SolicitacaoApoio.Include(b => b.TipoApoio).Include(b => b.Socio).Where(p => p.TipoApoioId == TipoId && p.Status == true);
        }

        public IEnumerable<SolicitacaoApoio> BuscarTodos()
        {
            return _gsContext.SolicitacaoApoio.Include(b => b.TipoApoio).Include(b => b.Socio).Where(p => p.Status == true);
        }
    }
}
