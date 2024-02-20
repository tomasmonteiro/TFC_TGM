using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ISaldoService : IServiceBase<Saldo>
    {

        public IEnumerable<Saldo> BuscarDisponivel(Guid id);
        void TornarUsado(Guid id);
        void UnirRecibos(List<Guid> saldoIds);
    }
}
