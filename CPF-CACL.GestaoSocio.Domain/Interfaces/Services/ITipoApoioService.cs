using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoApoioService : IServiceBase<TipoApoio>
    {
        TipoApoio BuscarPorTipo(string tipo);
        IEnumerable<TipoApoio> BuscarTodos();
    }
}
