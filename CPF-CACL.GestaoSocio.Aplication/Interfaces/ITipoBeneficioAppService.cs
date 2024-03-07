using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface ITipoBeneficioAppService 
    {
        public void Adicionar(TipoBeneficioViewModel tipoBeneficio);
        public TipoBeneficioViewModel BuscarPorId(Guid id);
        public TipoBeneficioViewModel BuscarPorNome(string nome);
        public IEnumerable<TipoBeneficioViewModel> BuscarTodosAtivos();
        public IEnumerable<TipoBeneficioViewModel> BuscarTodos();
        public void Atualizar(TipoBeneficioViewModel tipoBeneficio);
        public void Inativar(Guid id);

        public void Eliminar(TipoBeneficioViewModel tipoBeneficio);
    }
}
