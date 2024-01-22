using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IRelacaoAppService
    {
        public void Adicionar(RelacaoViewModel relacaoViewModel);
        public IEnumerable<RelacaoViewModel> Buscar();
        public RelacaoViewModel BuscarPorId(Guid id);
        public void Atualizar(RelacaoViewModel relacaoViewModel);
        public void Eliminar(Guid id);
    }
}
