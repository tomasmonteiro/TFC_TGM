using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoItemService : IServiceBase<TipoItem>
    {
        ICollection<TipoItem> BuscarPorNome(string nome);
    }
}
