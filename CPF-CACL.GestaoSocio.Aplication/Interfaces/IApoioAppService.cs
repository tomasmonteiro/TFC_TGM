using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IApoioAppService
    {
        public void Adicionar(ApoioViewModel apoio);
        public void AdicionarApoio(List<DadosApoioViewModel> dadosApoioViewModel);
        public ApoioViewModel BuscarPorId(Guid id);
		public IEnumerable<ApoioViewModel> BuscarItemPorSocio(Guid socioId);
		public IEnumerable<ApoioViewModel> BuscarApoioConcluido();
        public IEnumerable<ApoioViewModel> BuscarApoioPendente();
        public IEnumerable<ApoioViewModel> BuscarTodosAtivos();
        public IEnumerable<ApoioViewModel> BuscarTodos();
        public void Atualizar(ApoioViewModel apoio);
        public void Inativar(Guid id);
        public void Eliminar(ApoioViewModel apoio);
    }
}
