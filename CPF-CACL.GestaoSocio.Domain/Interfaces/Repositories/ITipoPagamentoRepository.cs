﻿using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ITipoPagamentoRepository : IRepositoryBase<TipoPagamento>
    {
        //Método para adicionar
        //TipoPagamento Adicionar(TipoPagamento tipoPagamento);
        IEnumerable<TipoPagamento> BuscarTodos();
    }
}
