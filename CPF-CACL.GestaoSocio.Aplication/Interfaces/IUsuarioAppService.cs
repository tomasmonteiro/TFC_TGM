using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IUsuarioAppService 
    {
        public void Adicionar(UsuarioViewModel usuario);
        public IEnumerable<UsuarioViewModel> Buscar();
        public UsuarioViewModel BuscarPorId(Guid id);

        UsuarioViewModel BuscarPorLogin(string login);
        UsuarioViewModel BuscarPorEmail(string email);
        ICollection<UsuarioViewModel> BuscarPorName(string nome);
        IEnumerable<UsuarioViewModel> BuscarTodos();
        public void Atualizar(UsuarioViewModel usuario);
        public void Eliminar(UsuarioViewModel usuario);
        public void Inativar(Guid id);
    }
}
