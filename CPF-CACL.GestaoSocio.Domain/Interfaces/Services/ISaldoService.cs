using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ISaldoService : IServiceBase<Saldo>
    {

        public IEnumerable<Saldo> BuscarDisponivel(Guid id);

        Saldo BuscarPorSocio(Guid idSocio);
        void TornarUsado(Guid id);
        void DiminuirSaldo(Guid socioId, double valorPagamento);
        void UnirRecibos(List<Guid> saldoIds);
    }
}
