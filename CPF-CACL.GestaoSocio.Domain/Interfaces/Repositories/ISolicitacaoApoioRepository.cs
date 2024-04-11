using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoApoioRepository : IRepositoryBase<SolicitacaoApoio>
    {
        IEnumerable<SolicitacaoApoio> BuscarSAPendentes();
        IEnumerable<SolicitacaoApoio> BuscarSAConcluidos();
        IEnumerable<SolicitacaoApoio> BuscarPorTipo(Guid TipoId);
        IEnumerable<SolicitacaoApoio> BuscarTodos();
    }
}
