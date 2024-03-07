using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ICategoriaSocioRepository : IRepositoryBase<CategoriaSocio>
    {
        IEnumerable<CategoriaSocio> BuscarTodos();
    }
}
