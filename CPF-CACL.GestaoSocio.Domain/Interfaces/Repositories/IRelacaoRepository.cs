using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IRelacaoRepository : IRepositoryBase<Relacao>
    {
        IEnumerable<Relacao> BuscarTodos();
    }
}
