using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IAgregadoAppService
    {
        public void Adicionar(AgregadoViewModel agregado);

        public IEnumerable<AgregadoViewModel> Buscar();
        public void Atualizar(AgregadoViewModel bairro);
        public void Eliminar(Guid id);
    }
}
