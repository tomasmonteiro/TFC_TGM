using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ISaldoAppService
    {
        public void Adicionar(SaldoViewModel saldo);
        public IEnumerable<SaldoViewModel> BuscarTodos();
        public IEnumerable<SaldoViewModel> BuscarDisponivel(Guid id);
        public SaldoViewModel BuscarPorId(Guid id);
        public void Atualizar(SaldoViewModel saldo);
        public void Eliminar(Guid id);
    }
}
