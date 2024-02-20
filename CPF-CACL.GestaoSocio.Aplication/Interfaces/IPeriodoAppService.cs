using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IPeriodoAppService
    {
        public void Adicionar(PeriodoViewModel periodo);
        public void AdicionarPeriodoEItem(PeriodoViewModel periodo);
        public IEnumerable<PeriodoViewModel> BuscarTodos();
        public PeriodoViewModel BuscarPorCod(string codigo);
        public PeriodoViewModel BuscarPorId(Guid id);
        public void Atualizar(PeriodoViewModel periodo);
        public void Eliminar(Guid id);
    }
}
