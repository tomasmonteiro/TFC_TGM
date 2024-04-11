using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ITipoApoioRepository : IRepositoryBase<TipoApoio>
    {
        TipoApoio BuscarPorTipo(string tipo);
        IEnumerable<TipoApoio> BuscarTodos();
    }
}
