using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IOrganismoRepository: IRepositoryBase<Organismo>
    {
        IEnumerable<Organismo> BuscarTodos();
    }
}
