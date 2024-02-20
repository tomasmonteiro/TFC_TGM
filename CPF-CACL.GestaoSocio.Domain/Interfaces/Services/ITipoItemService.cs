using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoItemService : IServiceBase<TipoItem>
    {
        ICollection<TipoItem> BuscarPorNome(string nome);
    }
}
