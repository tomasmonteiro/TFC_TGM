using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper mapper;
        private readonly IUsuarioService usuarioService;
        //
        public UsuarioAppService(IMapper mapper, IUsuarioService usuarioService)
        {
            this.mapper = mapper;
            this.usuarioService = usuarioService;
        }

        public void Adicionar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = mapper.Map<Usuario>(usuarioViewModel);
            usuarioService.Add(usuario);
        }

        public void Atualizar(UsuarioViewModel usuario)
        {
            usuarioService.Update(mapper.Map<Usuario>(usuario));
        }

        public IEnumerable<UsuarioViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioService.BuscarTodos());
        }

        public UsuarioViewModel BuscarPorEmail(string email)
        {
            return mapper.Map<UsuarioViewModel>(usuarioService.BuscarPorEmail(email));
        }

        public UsuarioViewModel BuscarPorId(Guid id)
		{ 
            var usuario = usuarioService.GetById(id);
			return mapper.Map<UsuarioViewModel>(usuario);
		}

        public UsuarioViewModel BuscarPorLogin(string login)
        {
            return mapper.Map<UsuarioViewModel>(usuarioService.BuscarPorLogin(login));
        }

        public ICollection<UsuarioViewModel> BuscarPorName(string nome)
        {
            return mapper.Map<ICollection<UsuarioViewModel>>(usuarioService.BuscarPorName(nome));
        }

        public void Eliminar(Guid id)
        {
            usuarioService.Eliminar(id);
        }

        public IEnumerable<UsuarioViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioService.GetAll());
        }
    }
}
