using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IBeneficioService : IServiceBase<Beneficio>
    {
        IEnumerable<Beneficio> BuscarPorTipo(Guid tipoBeneficioId);
    }
}
