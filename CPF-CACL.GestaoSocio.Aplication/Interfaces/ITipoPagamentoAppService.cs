using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoPagamentoAppService 
    {
        
         public void Adicionar(TipoPagamentoViewModel tipoPagamento);
         public IEnumerable<TipoPagamentoViewModel> Buscar();
        public void Atualizar(TipoPagamentoViewModel tipoPagamento);
        public void Eliminar(Guid id);
    }
}
