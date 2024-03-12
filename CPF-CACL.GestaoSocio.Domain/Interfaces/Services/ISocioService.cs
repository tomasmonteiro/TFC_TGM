using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ISocioService : IServiceBase<Socio>
    {
        IEnumerable<Socio> BuscarPorNome(string nome);
        Socio BuscarPorCod(string codigo);
        public Guid Adicionar(Socio socio);
        public string GerarDodigoSocio();
        public double BuscarValorCapital(Guid socioId, Guid beneficioId);
    }
}
