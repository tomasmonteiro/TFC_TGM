using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ITipoBeneficioRepository : IRepositoryBase<TipoBeneficio>
    {
        TipoBeneficio BuscarPorNome(string nome);
        IEnumerable<TipoBeneficio> BuscarTodos();
    }
}
