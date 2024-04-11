using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoEmolumentoService : IServiceBase<TipoEmolumento>
    {
        ICollection<TipoEmolumento> BuscarPorNome(string nome);
    }
}
