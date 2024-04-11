using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ISolicitacaoDeclaracaoAppService
    {
        public void Adicionar(SolicitacaoDeclaracaoViewModel solicitacaoDeclaracao);

        public IEnumerable<SolicitacaoDeclaracaoViewModel> BuscarTodos();
        IEnumerable<SolicitacaoDeclaracaoViewModel> BuscarSDPendentes();
        IEnumerable<SolicitacaoDeclaracaoViewModel> BuscarSDConcluidos();
        public SolicitacaoDeclaracaoViewModel BuscarPorId(Guid id);
        public void Atualizar(SolicitacaoDeclaracaoViewModel solicitacaoDeclaracao);
        public void Eliminar(Guid id);

    }
}
