﻿using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoDeclaracaoRepository : IRepositoryBase<SolicitacaoDeclaracao>
    {
        IEnumerable<SolicitacaoDeclaracao> BuscarSDPendentes();
        IEnumerable<SolicitacaoDeclaracao> BuscarSDConcluidos();
        IEnumerable<SolicitacaoDeclaracao> BuscarTodos();
    }
}
