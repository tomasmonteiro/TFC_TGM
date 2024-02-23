using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IUsuarioAppService 
    {
        public void Adicionar(UsuarioViewModel socio);
        public IEnumerable<UsuarioViewModel> Buscar();
        public UsuarioViewModel BuscarPorId(Guid id);

        UsuarioViewModel BuscarPorLogin(string login);
        UsuarioViewModel BuscarPorEmail(string email);
        ICollection<UsuarioViewModel> BuscarPorName(string nome);
        IEnumerable<UsuarioViewModel> BuscarTodos();
        public void Atualizar(UsuarioViewModel socio);
        public void Eliminar(Guid id);
    }
}
