using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ISolicitacaoApoioAppService
    {
        public void Adicionar(SolicitacaoApoioViewModel solicitacaoApoio);

        public IEnumerable<SolicitacaoApoioViewModel> BuscarTodos();
        IEnumerable<SolicitacaoApoioViewModel> BuscarSAPendentes();
        IEnumerable<SolicitacaoApoioViewModel> BuscarSAConcluidos();
        IEnumerable<SolicitacaoApoioViewModel> BuscarPorTipo(Guid tipoId);
        public SolicitacaoApoioViewModel BuscarPorId(Guid id);
        public void Atualizar(SolicitacaoApoioViewModel solicitacaoApoio);
        public void Eliminar(Guid id);

    }
}
