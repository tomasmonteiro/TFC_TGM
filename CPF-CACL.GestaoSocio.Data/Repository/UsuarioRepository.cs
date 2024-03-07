using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly GSContext _gsContext;
        public UsuarioRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _gsContext.Usuario.Where(p => p.Email == email && p.Status == true).FirstOrDefault();
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _gsContext.Usuario.Where(p => p.Login == login && p.Status == true).FirstOrDefault();
        }

        public ICollection<Usuario> BuscarPorName(string nome)
        {
            return _gsContext.Usuario.Where(p => p.Nome == nome && p.Status == true).ToList();
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _gsContext.Usuario.Where(p => p.Status == true).ToList();
        }

        public int ContarUsuarios()
        {
            return _gsContext.Usuario.Count(p => p.Status == true);
        }
    }
}
