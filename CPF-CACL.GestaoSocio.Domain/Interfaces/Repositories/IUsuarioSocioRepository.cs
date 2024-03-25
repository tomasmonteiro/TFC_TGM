using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IUsuarioSocioRepository : IRepositoryBase<UsuarioSocio>
    {
        IEnumerable<UsuarioSocio> BuscarTodos();
        UsuarioSocio BuscarPorSocioId(Guid socioId);
        UsuarioSocio BuscarPorUsuarioId(Guid usuarioId);
    }
}
