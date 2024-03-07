using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        ICollection<Usuario> BuscarPorName(string nome);
        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorEmail(string email);
        IEnumerable<Usuario> BuscarTodos();
    }
}
