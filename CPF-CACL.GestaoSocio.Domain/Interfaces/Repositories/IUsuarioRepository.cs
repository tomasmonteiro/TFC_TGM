using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
         
        ICollection<Usuario> BuscarPorName(string nome);
        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorEmail(string email);
        IEnumerable<Usuario> BuscarTodos();
        int ContarUsuarios();
    }
}
