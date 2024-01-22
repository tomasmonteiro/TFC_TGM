using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IPagamentoService : IServiceBase<Pagamento>
    {
        Pagamento BuscarPorCod(Guid id);
    }
}
