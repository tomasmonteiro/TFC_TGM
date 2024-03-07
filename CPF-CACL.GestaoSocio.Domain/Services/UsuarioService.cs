using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Add(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarioRepository.BuscarPorEmail(email);
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _usuarioRepository.BuscarPorLogin(login);
        }

        public ICollection<Usuario> BuscarPorName(string nome)
        {
            return _usuarioRepository.BuscarPorName(nome);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _usuarioRepository.BuscarTodos();
        }


        public void Eliminar(Guid id)
        {
            Usuario usuario = GetById(id);
            if (usuario == null)
            {
                Notificar("O Usuário que pretende eliminar não existe.");
                return;
            }
            usuario.Status = false;
            _usuarioRepository.Update(usuario);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetById(Guid id)
        {
            return _usuarioRepository.GetById(id);
        }

        public void Remove(Usuario usuario)
        {
            var novoUsuario = _usuarioRepository.GetById(usuario.Id);
            if (novoUsuario == null)
            {
                Notificar("O Usuario que pretende eliminar não existe.");
                return;
            }
            _usuarioRepository.Remove(novoUsuario);
        }

        public void Update(Usuario novoUsuario)
        {
            Usuario usuario = GetById(novoUsuario.Id);
            if (usuario == null)
            {
                Notificar("O Usuário que pretende atualizar não existe.");
                return;
            }
            usuario.Nome = novoUsuario.Nome;
            usuario.Login = novoUsuario.Login;
            usuario.Perfil = novoUsuario.Perfil;
            usuario.Email = novoUsuario.Email;
            usuario.DataAtualizacao = DateTime.Now;
            _usuarioRepository.Update(usuario);
        }
        public void Dispose()
        {
           _usuarioRepository.Dispose();
        }
    }
}
