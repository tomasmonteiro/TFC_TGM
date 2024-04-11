using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ISaldoAppService
    {
        public void Adicionar(SaldoViewModel saldo);
        public IEnumerable<SaldoViewModel> BuscarTodos();
        public SaldoViewModel BuscarPorSocio(Guid idSocio);
        public IEnumerable<SaldoViewModel> BuscarDisponivel(Guid id);
        public SaldoViewModel BuscarPorId(Guid id);
        public void Atualizar(SaldoViewModel saldo);
        public void Eliminar(Guid id);
    }
}
