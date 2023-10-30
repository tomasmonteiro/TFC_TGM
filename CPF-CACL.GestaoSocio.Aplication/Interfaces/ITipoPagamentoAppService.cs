using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoPagamentoAppService 
    {
        
         public void Add(TipoPagamentoViewModel tipoPagamentoViewModel);

         //public IEnumerable<TipoPagamentoViewModel>  GetAllTipo();

        public IEnumerable<TipoPagamentoViewModel> BuscarTodosTipo();

    }
}
