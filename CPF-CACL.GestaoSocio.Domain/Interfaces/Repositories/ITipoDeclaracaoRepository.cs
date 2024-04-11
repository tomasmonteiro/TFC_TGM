using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ITipoDeclaracaoRepository : IRepositoryBase<TipoDeclaracao>
    {
        TipoDeclaracao BuscarPorTipo(string tipo);
        IEnumerable<TipoDeclaracao> BuscarTodos();
    }
}
