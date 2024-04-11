using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IPagamentoEmolumentoService : IServiceBase<PagamentoEmolumento>
    {

        public IEnumerable<PagamentoEmolumento> BuscarItemPorSocio(Guid socioId);
    }
}
