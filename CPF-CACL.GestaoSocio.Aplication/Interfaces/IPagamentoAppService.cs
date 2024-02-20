using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IPagamentoAppService
    {
        public void Adicionar(PagamentoViewModel pagamento);
        public IEnumerable<PagamentoViewModel> BuscarTodos();
        public IEnumerable<PagamentoViewModel> BuscarDisponivel(Guid id);
        public PagamentoViewModel BuscarPorCod(string codigo);
        public PagamentoViewModel BuscarPorId(Guid id);
        public void Atualizar(PagamentoViewModel pagamento);
        public void Eliminar(Guid id);
    }
}
