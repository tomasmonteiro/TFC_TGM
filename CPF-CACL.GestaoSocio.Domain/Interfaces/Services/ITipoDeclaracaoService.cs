using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoDeclaracaoService : IServiceBase<TipoDeclaracao>
    {
        TipoDeclaracao BuscarPorTipo(string tipo);
        IEnumerable<TipoDeclaracao> BuscarTodos();
    }
}
