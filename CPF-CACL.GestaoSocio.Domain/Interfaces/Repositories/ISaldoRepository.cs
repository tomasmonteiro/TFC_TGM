using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ISaldoRepository : IRepositoryBase<Saldo>
    {
        IEnumerable<Saldo> BuscarTodos();
        IEnumerable<Saldo> BuscarDisponiveis(Guid id);
        Saldo BuscarPorSocio(Guid idSocio);
        List<Saldo> BuscarPagamentosPorIds(List<Guid> saldosIds);
    }
}
