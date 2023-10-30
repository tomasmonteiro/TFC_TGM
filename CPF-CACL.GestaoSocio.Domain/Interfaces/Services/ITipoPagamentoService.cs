using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoPagamentoService : IServiceBase<TipoPagamento>
    {
        //TipoPagamento Adicionar(TipoPagamento tipoPagamento);

        IEnumerable<TipoPagamento> BuscarTipos();

    }
}
