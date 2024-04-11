using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IPagamentoEmolumentoRepository : IRepositoryBase<PagamentoEmolumento>
    {
        IEnumerable<PagamentoEmolumento> BuscarTodos();
        IEnumerable<PagamentoEmolumento> BuscarItemPagamentoPorSocio(Guid socioId);
        void CriarQuota(Socio socio, Periodo periodo);
    }
}
