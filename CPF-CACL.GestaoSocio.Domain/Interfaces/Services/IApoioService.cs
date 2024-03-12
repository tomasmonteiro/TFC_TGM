using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IApoioService : IServiceBase<Apoio>
    {
        IEnumerable<Apoio> BuscarApoioPendente();
        IEnumerable<Apoio> BuscarApoioCocluido();
        public void AdicionarApoio(List<DadosApoio> dadosApoio);
    }
}
