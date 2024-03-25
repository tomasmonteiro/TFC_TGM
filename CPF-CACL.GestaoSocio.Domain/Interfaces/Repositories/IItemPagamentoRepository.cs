﻿using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IItemPagamentoRepository : IRepositoryBase<ItemPagamento>
    {
        IEnumerable<ItemPagamento> BuscarTodos();
        IEnumerable<ItemPagamento> BuscarItemPagamentoPorSocio(Guid socioId);
        void CriarQuota(Socio socio, Periodo periodo);
    }
}
