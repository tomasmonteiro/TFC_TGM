using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ISolicitacaoDeclaracaoService : IServiceBase<SolicitacaoDeclaracao>
    {
        IEnumerable<SolicitacaoDeclaracao> BuscarSDPendentes();
        IEnumerable<SolicitacaoDeclaracao> BuscarSDConcluidos();
        IEnumerable<SolicitacaoDeclaracao> BuscarTodos();
    }
}
