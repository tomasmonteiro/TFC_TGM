using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoBeneficioService : IServiceBase<TipoBeneficio>
    {
        TipoBeneficio BuscarPorNome(string nome);
        IEnumerable<TipoBeneficio> BuscarTodos();
    }
}
